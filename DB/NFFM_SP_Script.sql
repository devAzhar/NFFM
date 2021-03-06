﻿USE [NFFM]
GO
Alter table tblTruckers
Add deleted bit not null default 0
GO
Alter table tblCustomers
Add Deleted bit not null default 0
GO
Alter table tblSalesCodes
Add deleted bit not null default 0
GO
Alter table tblShippers
Add deleted bit not null default 0
GO
Alter table tblLineItems_Receiving
Add deleted bit not null default 0
GO
Alter table tblReceivingInfo
Add deleted bit not null default 0
GO
Alter table tblReceivingInfo_LineItems
Add deleted bit not null default 0
GO
/****** Object:  StoredProcedure [dbo].[BillOfLading_AddUpdate]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[BillOfLading_AddUpdate]
(
@receivingId  As nvarchar(50),
@lineItemId   As nvarchar(50),
@billOfLading As nvarchar(50),
@customerName As nvarchar(200),
@shipper 	  As nvarchar(50),
@salesCode 	  As nvarchar(50),
@quantity     As nvarchar(10),
@receivedDate As nvarchar(20),
@weekEndingDate As nvarchar(20),
@truckerId    As nvarchar(10) = 0,
@batchId	  As nvarchar(50) = ''
)
As
BEGIN

Declare @customerId as int = 0,
@shipperId as int = 0,
@salesCodeId as int = 0,
@newCustomerId as int = 0,
@newShipperId as int = 0,
@newSalesCodeId as int = 0

Set @newCustomerId = (select Distinct top 1 CustomerId From tblCustomers where name = @customerName)
Set @newShipperId = (select Distinct top 1 ShipperId From tblShippers where Shipper = @shipper)
Set @newSalesCodeId = (Select Distinct top 1 SalesCodeId from tblSalesCodes where [Sales Code] = @salesCode)

If @truckerId > 0 AND @receivingId = '0'
BEGIN


set @receivingId = (select max(receivingID) from tblReceivingInfo) + 1

Insert into tblReceivingInfo
values(@receivingId, @truckerId, @receivedDate, @weekEndingDate, @batchId, 0)

END
ELSE If @truckerId > 0 AND @receivingId <> '0'
BEGIN

Update tblReceivingInfo 
set truckerID = @truckerId 
where receivingID = @receivingId

END
ELSE IF @batchId <> ''
BEGIN

Update tblReceivingInfo 
set BatchID = @batchId 
where receivingID = @receivingId

END
ELSE IF (@receivedDate <> '' or @weekEndingDate <> '')
BEGIN

Update tblReceivingInfo 
set ReceivedDate = @receivedDate, 
	WeekEndingDate = @weekEndingDate
where receivingID = @receivingId

END
ELSE IF (@receivingId <> '' AND @lineItemId = '')
BEGIN

set @lineItemId = (select max(lineItemId) from tblLineItems_Receiving) + 1

insert into tblReceivingInfo_LineItems
values(@receivingId, @lineItemId, 0) 

insert into tblLineItems_Receiving
values(@lineItemId, @billOfLading, ISNULL(@newCustomerId, -1), ISNULL(@newShipperId, -1), ISNULL(@newSalesCodeId, -1), ISNULL(@quantity, -1), 0)

--delete from tblLineItems_Receiving where lineitemId > 1421522
--delete from tblReceivingInfo_LineItems where lineitemId > 1421522
END
ELSE
BEGIN 

select @customerId = customerId, @shipperId = shipperID, @salesCodeId = salesCodeID From tblLineItems_Receiving lineitem
inner join tblReceivingInfo_LineItems info on info.lineItemID = lineitem.lineItemID where lineitem.lineItemID = @lineItemId ANd receivingID = @receivingId;



BEGIN TRANSACTION;

update tblLineItems_Receiving
set BillOfLadingNumber = @billOfLading,
	Quantity = @quantity,
	CustomerId = @newCustomerId,
	ShipperId = @newShipperId,
	SalesCodeId = @newSalesCodeId
where lineItemID = @lineItemId --AND customerID = @CustomerId

COMMIT;

END
END


--110550	1421521


GO
/****** Object:  StoredProcedure [dbo].[BillOfLading_Delete]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[BillOfLading_Delete]
(
@receivingId nvarchar(100) = 0
)
As BEGIN

Update tblLineItems_Receiving set Deleted = 1 where lineitemId in (select lineitemId from tblReceivingInfo_LineItems where receivingID = @receivingId)
Update tblReceivingInfo set Deleted = 1 where receivingID = @receivingId
Update tblReceivingInfo_LineItems set Deleted = 1 where receivingID = @receivingId

END
GO
/****** Object:  StoredProcedure [dbo].[BillOfLading_GetAll]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[BillOfLading_GetAll]
(
@receivingId nvarchar(100) = Null
)

As Begin
Declare @TotalRecords as int = 0;
Exec Truckers_GetAll -- table1

IF ISNULL(@receivingId, 0) = 0
BEGIN
Set @receivingId = (Select max(receivingId) from tblReceivingInfo Where Deleted = 0)
END

select Distinct ROW_NUMBER() OVER (Order by receivingId) AS CurrentRecord, r.receivingID, r.truckerID, r.ReceivedDate, r.WeekEndingDate,r.BatchID,t.Trucker 
into #tempReceivingInfo
from tblReceivingInfo r -- table2
inner join tblTruckers t on t.truckerID = r.truckerID
Where  r.Deleted = 0

--********

Declare @CurrentRow as int, @firstReceivingId as int, @previousReceivingId as int, @nextReceivingId as int,  @lastReceivingId as int
IF @receivingId IS NULL
BEGIN
Set @receivingId = (Select max(receivingId) from tblReceivingInfo Where Deleted = 0)
END

--select * from #tempReceivingInfo where receivingId = @receivingId

set @CurrentRow = (select currentRecord from #tempReceivingInfo where receivingId = @receivingId)
set @firstReceivingId = (select receivingId from #tempReceivingInfo where currentRecord = 1)
set @previousReceivingId = (select receivingId from #tempReceivingInfo where currentRecord =  @CurrentRow - 1)
set @nextReceivingId = (select receivingId from #tempReceivingInfo where currentRecord =  @CurrentRow + 1)
set @lastReceivingId = (select max(receivingId) from #tempReceivingInfo)


--*******

Set @TotalRecords = (select count(1) From #tempReceivingInfo)

select @TotalRecords As TotalRecords, @firstReceivingId as firstReceivingId, Isnull(@previousReceivingId, 0) aS previousReceivingId, Isnull(@nextReceivingId, 0) aS nextReceivingId, @lastReceivingId As lastReceivingId, * from #tempReceivingInfo r
where (r.receivingID = @receivingId)
 --where batchId like '%cw050505%' and r.truckerID = '540' and r.WeekEndingDate = '2019-01-03 00:00:00.000'

select  receivingId,info.lineitemid,BillOfLadingNumber,cust.Name As CustomerName, Shipper,sc.[Sales Code] As SalesCode, sc.Description, sc.[Unit of Measure] As UnitOfMeasure, lineitem.Quantity As Qty, -- table3
sc.Price, lineitem.Quantity * Isnull(sc.Price, 0) As Ext from tblLineItems_Receiving lineitem
inner join tblReceivingInfo_LineItems info on info.lineItemID = lineitem.lineItemID
Left join tblCustomers cust on cust.customerID = lineitem.customerID
left join tblShippers ship on ship.shipperID = lineitem.shipperID
left join tblSalesCodes sc on sc.salesCodeID = lineitem.salesCodeID
where receivingId = @receivingId and info.deleted = 0
order by lineitemId
--where lineItemID in (select lineItemid from tblReceivingInfo_LineItems where receivingId = 110544)

Exec Customers_GetAll -- table 3

Exec Shippers_GetAll -- table 4

Exec SalesCode_GetAll -- table 5


select  @receivingId receivingId, '' lineitemid, '' BillOfLadingNumber, '' As CustomerName, '' Shipper,'' As SalesCode, '' [Description], '' As UnitOfMeasure, 0 As Qty, -- table6
0 As Price, 0 As Ext

END
GO
/****** Object:  StoredProcedure [dbo].[Customers_Add]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Customers_Add]
(
@CustomerNo nvarchar(50) = null,
@Name nvarchar(50) = Null,
@FFTier nvarchar(50) = Null,
@IsCoop bit = 0,
@Price nvarchar(50)
)
As begin
Declare @ID as int = (select max(customerID) from tblCustomers)
Set @ID = @ID + 1;

Insert into tblCustomers
values(@ID,@CustomerNo,@Name,@FFTier,@IsCoop,@Price, 0)
END

GO
/****** Object:  StoredProcedure [dbo].[Customers_AddUpdate]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Customers_AddUpdate]
(
@CustomerId int = 0,
@CustomerNo nvarchar(50) = null,
@Name nvarchar(50) = Null,
@FFTier nvarchar(50) = Null,
@IsCoop bit = 0,
@Price nvarchar(50)
)
As begin
IF (@CustomerId = 0) 
BEGIN
set @CustomerId = (select max(customerID) from tblCustomers)
Set @CustomerId = @CustomerId + 1;

Insert into tblCustomers
values(@CustomerId,@CustomerNo,@Name,@FFTier,@IsCoop,@Price, 0)
END
ELSE
BEGIN
Update tblCustomers set [Customer No] = @CustomerNo, Name = @Name, FF_Tier = @FFTier, coOpMember = @IsCoop, CustomerPricing = @Price where CustomerID = @CustomerId
END
END

GO
/****** Object:  StoredProcedure [dbo].[Customers_Delete]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Customers_Delete]
(
@CustomerId int = 0
)
As begin
Update tblCustomers set deleted = 1 where CustomerID = @CustomerId
END

GO
/****** Object:  StoredProcedure [dbo].[Customers_GetAll]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Customers_GetAll]
AS BEGIN
--select CustomerID, [Customer No], Name, CoOpMember As [CoOp Member], FF_Tier As [FF Tier] ,CustomerPricing As Price from tblCustomers where deleted = 0  order by customerId desc
select CustomerID, [Customer No], Isnull(Name, '') as Name, CoOpMember As [CoOp Member], FF_Tier As [FF Tier],CustomerPricing As Price from tblCustomers where deleted = 0  and Name is not null
--AND (name like '%Emerald Seafood%' or name like '%Lockwood%' or name like '%slavin%' )
--order by customerId desc
END

GO
/****** Object:  StoredProcedure [dbo].[LineItem_Delete]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[LineItem_Delete]
(
@lineItemId   As nvarchar(50) = 0
)
As BEGIN

Update tblReceivingInfo_LineItems set Deleted = 1 where lineItemID = @lineItemId
Update tblLineItems_Receiving set Deleted = 1 where lineItemID = @lineItemId

END
GO
/****** Object:  StoredProcedure [dbo].[SalesCode_AddUpdate]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SalesCode_AddUpdate]
(
@SalesCodeID int = 0,
@SalesCode nvarchar(50) = null,
@Description nvarchar(500) = Null,
@UnityOfMeasure nvarchar(500) = Null,
@Price nvarchar(50) = 0,
@FFTier1 nvarchar(50) = Null,
@FFTier2 nvarchar(50) = Null,
@FFTier3 nvarchar(50) = Null
)
As begin
IF (@SalesCodeID = 0) 
BEGIN
set @SalesCodeID = (select max(SalesCodeID) from tblSalesCodes)
Set @SalesCodeID = @SalesCodeID + 1;

Insert into tblSalesCodes
values(@SalesCodeID,@SalesCode,@Description,@UnityOfMeasure,@Price,@FFTier1,@FFTier2,@FFTier3, 0)
END
ELSE
BEGIN
Update tblSalesCodes set [Sales Code] = @SalesCode, [Description] = @Description, [Unit of Measure] = @UnityOfMeasure, Price = @Price, FF_Tier_1 = @FFTier1, FF_Tier_2 = @FFTier2, FF_Tier_3 = @FFTier3 
where SalesCodeID = @SalesCodeID
END
END
GO
/****** Object:  StoredProcedure [dbo].[SalesCode_Delete]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SalesCode_Delete]
(
@SalesCodeID int = 0
)
As begin
Update tblSalesCodes set deleted = 1 where SalesCodeID = @SalesCodeID
END

GO
/****** Object:  StoredProcedure [dbo].[SalesCode_GetAll]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SalesCode_GetAll]
AS BEGIN
--select CustomerID, [Customer No], Name, CoOpMember As [CoOp Member], FF_Tier As [FF Tier] ,CustomerPricing As Price from tblCustomers where deleted = 0  order by customerId desc
select SalesCodeID, [Sales Code] , Description, [Unit of Measure] , Price, FF_Tier_1 As [FF Tier 1], FF_Tier_2 As [FF Tier 2], FF_Tier_3 As [FF Tier 3] from tblSalesCodes where deleted = 0  
END

GO
/****** Object:  StoredProcedure [dbo].[Shippers_AddUpdate]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Shippers_AddUpdate]
(
@ShipperID int = 0,
@Shipper nvarchar(150) = null
)
As begin
IF (@ShipperID = 0) 
BEGIN
set @ShipperID = (select max(ShipperID) from tblShippers)
Set @ShipperID = @ShipperID + 1;

Insert into tblShippers
values(@ShipperID,@Shipper, 0)
END
ELSE
BEGIN
Update tblShippers set [Shipper] = @Shipper
where ShipperID = @ShipperID
END
END
GO
/****** Object:  StoredProcedure [dbo].[Shippers_Delete]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Shippers_Delete]
(
@ShipperID int = 0
)
As begin
Update tblShippers set deleted = 1 where ShipperID = @ShipperID
END
GO
/****** Object:  StoredProcedure [dbo].[Shippers_GetAll]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Shippers_GetAll]
AS BEGIN
--select CustomerID, [Customer No], Name, CoOpMember As [CoOp Member], FF_Tier As [FF Tier] ,CustomerPricing As Price from tblCustomers where deleted = 0  order by customerId desc
select ShipperID, [Shipper] from tblShippers where deleted = 0  and Shipper is not null
END

GO
/****** Object:  StoredProcedure [dbo].[Truckers_AddUpdate]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Truckers_AddUpdate]
(
@TruckerID int = 0,
@Trucker nvarchar(150) = null
)
As begin
IF (@TruckerID = 0) 
BEGIN
set @TruckerID = (select max(TruckerID) from tblTruckers)
Set @TruckerID = @TruckerID + 1;

Insert into tblTruckers
values(@TruckerID,@Trucker, 0)
END
ELSE
BEGIN
Update tblTruckers set [Trucker] = @Trucker
where TruckerID = @TruckerID
END
END
GO
/****** Object:  StoredProcedure [dbo].[Truckers_Delete]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Truckers_Delete]
(
@TruckerID int = 0
)
As begin
Update tblTruckers set deleted = 1 where TruckerID = @TruckerID
END
GO
/****** Object:  StoredProcedure [dbo].[Truckers_GetAll]    Script Date: 4/2/2019 12:29:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Truckers_GetAll]
AS BEGIN
select truckerID, [Trucker] from tblTruckers where deleted = 0  
END

GO
CREATE Procedure BillOfLading_Report_GetAll --'1/1/2019', 'q'
(
@receivedDate datetime = '',
@batchId nvarchar(50) = '',
@invoiceNumber nvarchar(50) = null,
@billOfLadingNumber nvarchar(50) = '',
@customerName nvarchar(200) = ''
)

As Begin

if (@receivedDate = '')
BEGIN
set @receivedDate = (select max(ReceivedDate) from tblReceivingInfo where Deleted = 0 and ReceivedDate is not null)
END

select top 20 ReceivedDate,BatchID,0 As InvoiceNumber, info.receivingID,info.lineitemid,BillOfLadingNumber,cust.Name As CustomerName, Shipper,sc.[Sales Code] As SalesCode, sc.Description, sc.[Unit of Measure] As UnitOfMeasure, lineitem.Quantity As Qty, 
-- table3
sc.Price, lineitem.Quantity * Isnull(sc.Price, 0) As Ext from tblLineItems_Receiving lineitem
inner join tblReceivingInfo_LineItems info on info.lineItemID = lineitem.lineItemID
inner join tblReceivingInfo on tblReceivingInfo.receivingID = info.receivingID
Left join tblCustomers cust on cust.customerID = lineitem.customerID
left join tblShippers ship on ship.shipperID = lineitem.shipperID
left join tblSalesCodes sc on sc.salesCodeID = lineitem.salesCodeID
where (@receivedDate = '' or ReceivedDate = @receivedDate)
	AND (@batchId = '' or BatchID = @batchId)
	AND (@invoiceNumber is null ) --or invoi = @invoiceNumber)
	AND (@billOfLadingNumber = '' or BillOfLadingNumber = @billOfLadingNumber)
	AND (@customerName = '' or Name = @customerName)
	AND info.deleted = 0
order by lineitemId
--where lineItemID in (select lineItemid from tblReceivingInfo_LineItems where receivingId = 110544)


Exec ReceivedDate_GetAll -- table 2

Exec Batches_GetAll -- table 3

Exec BillOfLadingNumbers_GetAll -- table 4

Exec Customers_GetAll -- table 5

END
