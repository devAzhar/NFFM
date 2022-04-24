CREATE NONCLUSTERED INDEX [IX_tblReceivingInfo_LineItems_1]
ON [dbo].[tblReceivingInfo_LineItems] ([receivingID],[deleted])
GO
CREATE NONCLUSTERED INDEX [IX_tblLineItems_Receiving_1]
ON [dbo].[tblLineItems_Receiving] ([Quantity])
INCLUDE ([lineItemID])
GO
CREATE NONCLUSTERED INDEX [IX_tblLineItems_Receiving_2]
ON [dbo].[tblLineItems_Receiving] ([lineItemID])
INCLUDE ([BillOfLadingNumber],[customerID],[shipperID],[salesCodeID],[Quantity])
GO
GO
CREATE NONCLUSTERED INDEX [IX_tblReceivingInfo_Report_1]
ON [dbo].[tblReceivingInfo] ([deleted],[ReceivedDate])

GO

CREATE NONCLUSTERED INDEX [IX_tblReceivingInfo_Report_2]
ON [dbo].[tblReceivingInfo] ([deleted],[BatchID])
GO

--exec [BillOfLading_Report_GetAll] '2013-08-01 00:00:00.000','',null,'','',0
ALTER procedure [dbo].[BillOfLading_Report_GetAll] --'1/1/2019', 'q'
( 
	@receivedDate datetime = '',
	@batchId nvarchar(50) = '',
	@invoiceNumber nvarchar(50) = null,
	@billOfLadingNumber nvarchar(50) = '',
	@customerName nvarchar(200) = '',
	@ExportToExcel bit = 0
)

As Begin

--if (@receivedDate = '')
--BEGIN
--	--set @receivedDate = (select max(ReceivedDate) from tblReceivingInfo where Deleted = 0 and ReceivedDate is not null)
--END

if(@ExportToExcel = 0)
BEGIN
select top 500 --info.receivingID,info.lineitemid,
ReceivedDate,BatchID,
RIGHT('0' + RTRIM(MONTH([WeekEndingDate])), 2)
+ RIGHT('0' + RTRIM(DAY([WeekEndingDate])), 2)
+ Right(LTRIM(RTrim([Customer No])),2) 
+ SUBSTRING([Customer No],4,1) As InvoiceNumber,

BillOfLadingNumber,cust.Name As CustomerName,

 Shipper,sc.[Sales Code] As SalesCode, sc.Description, sc.[Unit of Measure] As UnitOfMeasure, lineitem.Quantity As Qty, 
-- table3
sc.Price, lineitem.Quantity * Isnull(sc.Price, 0) As Ext from tblLineItems_Receiving lineitem
inner join tblReceivingInfo_LineItems info on info.lineItemID = lineitem.lineItemID
inner join tblReceivingInfo on tblReceivingInfo.receivingID = info.receivingID
Left join tblCustomers cust on cust.customerID = lineitem.customerID
left join tblShippers ship on ship.shipperID = lineitem.shipperID
left join tblSalesCodes sc on sc.salesCodeID = lineitem.salesCodeID
where
	lineitem.Quantity > 0
	AND (@receivedDate = '' or ReceivedDate = @receivedDate)
	AND (@batchId = '' or BatchID = @batchId)
	AND (@invoiceNumber is null ) --or invoi = @invoiceNumber)
	AND (@billOfLadingNumber = '' or BillOfLadingNumber = @billOfLadingNumber)
	AND (@customerName = '' or Name = @customerName)
	AND info.deleted = 0
--order by lineitemId
--where lineItemID in (select lineItemid from tblReceivingInfo_LineItems where receivingId = 110544)
END
ELSE
BEGIN
select RIGHT('0' + RTRIM(MONTH([WeekEndingDate])), 2)
+ RIGHT('0' + RTRIM(DAY([WeekEndingDate])), 2)
+ Right(LTRIM(RTrim([Customer No])),2) 
+ SUBSTRING([Customer No],4,1) As InvoiceNumber,
lineitem.lineitemId As LineItemId,
cAST(WeekEndingDate as date) As InvoiceDate,
cAST(ReceivedDate as date) AS ReceivedDate,

BillOfLadingNumber, cust.[Customer No] + ' ' + cust.Name As CustomerName, Shipper, Trucker,

 sc.[Sales Code] As SalesCode, sc.Description, sc.[Unit of Measure] As UnitOfMeasure, lineitem.Quantity As Quantity, 
 --BatchID, 
-- table3
sc.Price, 
lineitem.Quantity * Isnull(sc.Price, 0) As Total 
from tblLineItems_Receiving lineitem
inner join tblReceivingInfo_LineItems info on info.lineItemID = lineitem.lineItemID
inner join tblReceivingInfo on tblReceivingInfo.receivingID = info.receivingID
left join tblTruckers truck on truck.truckerID = tblReceivingInfo.truckerID
Left join tblCustomers cust on cust.customerID = lineitem.customerID
left join tblShippers ship on ship.shipperID = lineitem.shipperID
left join tblSalesCodes sc on sc.salesCodeID = lineitem.salesCodeID
where 
	lineitem.Quantity > 0
	AND (@receivedDate = '' or ReceivedDate = @receivedDate)
	AND (@batchId = '' or BatchID = @batchId)
	AND (@invoiceNumber is null ) --or invoi = @invoiceNumber)
	AND (@billOfLadingNumber = '' or BillOfLadingNumber = @billOfLadingNumber)
	AND (@customerName = '' or Name = @customerName)
	AND info.deleted = 0
END

Exec ReceivedDate_GetAll -- table 2

Exec Batches_GetAll -- table 3

Exec BillOfLadingNumbers_GetAll -- table 4

Exec Customers_GetAll @ShowAll = 0 -- table 5

END

GO

--###############

CREATE TABLE [dbo].[tblLineItems_Receiving_InvoiceNumber](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[lineItemId] [int] NOT NULL,
	[invoiceNumber] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblLineItems_Receiving_InvoiceNumber] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)
)

CREATE NONCLUSTERED INDEX [IX_tblReceivingInfo_LineItems]
ON [dbo].[tblReceivingInfo_LineItems] ([lineItemID])
INCLUDE ([receivingID])

GO
CREATE NONCLUSTERED INDEX [IX_tblReceivingInfo_Date]
ON [dbo].[tblReceivingInfo] ([receivingID],[WeekEndingDate])
GO
CREATE NONCLUSTERED INDEX [IX_tblReceivingInfo_Batch]
ON [dbo].[tblReceivingInfo] ([BatchID])
CREATE NONCLUSTERED INDEX [IX_tblLineItems_Receiving_BOL]
ON [dbo].[tblLineItems_Receiving] ([BillOfLadingNumber])
INCLUDE ([customerID])
GO
CREATE NONCLUSTERED INDEX [IX_tblLineItems_Receiving_CustBOL]
ON [dbo].[tblLineItems_Receiving] ([customerID],[BillOfLadingNumber])

GO

CREATE NONCLUSTERED INDEX [IX_tblLineItems_Receiving_deleted]
ON [dbo].[tblLineItems_Receiving] ([deleted])
INCLUDE ([customerID])


GO

CREATE NONCLUSTERED INDEX [IX_tblLineItems_Receiving_Deleted_BOL]
ON [dbo].[tblLineItems_Receiving] ([deleted],[BillOfLadingNumber])
INCLUDE ([customerID])

GO
CREATE NONCLUSTERED INDEX tblLineItems_Receiving_cdb
ON [dbo].[tblLineItems_Receiving] ([customerID],[deleted],[BillOfLadingNumber])

GO

ALTER TRIGGER tblLineItems_Receiving_Insert
ON dbo.tblLineItems_Receiving
FOR INSERT AS  
BEGIN
	declare @InvoiceNumber varchar(100) = ''
	declare @ID INT = 0
	select @ID = lineItemID
	FROM inserted  

	select top 1 @InvoiceNumber = RIGHT('0' + RTRIM(MONTH([WeekEndingDate])), 2)        
		+ RIGHT('0' + RTRIM(DAY([WeekEndingDate])), 2)        
		+ Right(LTRIM(RTrim([Customer No])),2)         
		+ SUBSTRING([Customer No],4,1) 
	from tblLineItems_Receiving lineitem with(nolock)
		inner join tblReceivingInfo_LineItems info on info.lineItemID = lineitem.lineItemID    and info.deleted = 0     
		inner join tblReceivingInfo on tblReceivingInfo.receivingID = info.receivingID         and tblReceivingInfo.deleted = 0
		inner join tblCustomers cust with(nolock) on cust.customerID = lineitem.customerID and cust.[Name] is not null and Len(cust.[Name]) > 0 and [Customer No] is not null and cust.Deleted = 0
	where info.lineItemID = @ID and info.deleted = 0

	if(@InvoiceNumber <> '' and @ID > 0) 
	begin
	   insert into tblLineItems_Receiving_InvoiceNumber values (@ID, @InvoiceNumber)
	end
END;  
GO
ALTER TRIGGER tblLineItems_Receiving_Update
ON dbo.tblLineItems_Receiving
AFTER UPDATE
AS  
BEGIN
	declare @InvoiceNumber varchar(100) = ''
	declare @ID INT = 0
	select @ID = lineItemID
	FROM inserted  

	select top 1 @InvoiceNumber = RIGHT('0' + RTRIM(MONTH([WeekEndingDate])), 2)        
		+ RIGHT('0' + RTRIM(DAY([WeekEndingDate])), 2)        
		+ Right(LTRIM(RTrim([Customer No])),2)         
		+ SUBSTRING([Customer No],4,1) 
	from tblLineItems_Receiving lineitem with(nolock)
		inner join tblReceivingInfo_LineItems info on info.lineItemID = lineitem.lineItemID and info.deleted = 0
		inner join tblReceivingInfo on tblReceivingInfo.receivingID = info.receivingID and tblReceivingInfo.deleted = 0
		inner join tblCustomers cust with(nolock) on cust.customerID = lineitem.customerID and cust.[Name] is not null and Len(cust.[Name]) > 0 and [Customer No] is not null and cust.Deleted = 0
	where info.lineItemID = @ID and info.deleted = 0

	if(@InvoiceNumber <> '' and @ID > 0) 
	begin
	   update tblLineItems_Receiving_InvoiceNumber set  invoiceNumber = @InvoiceNumber where lineItemId=@ID
	end
END;  

GO

ALTER TRIGGER tblReceivingInfo_Update
ON dbo.tblReceivingInfo
AFTER UPDATE
AS  
BEGIN
	declare @InvoiceNumber varchar(100) = ''
	declare @ID INT = 0
	select @ID = receivingID
	FROM inserted  

	update t1
	SET
		InvoiceNumber = RIGHT('0' + RTRIM(MONTH([WeekEndingDate])), 2)        
		+ RIGHT('0' + RTRIM(DAY([WeekEndingDate])), 2)        
		+ Right(LTRIM(RTrim([Customer No])),2)         
		+ SUBSTRING([Customer No],4,1) 
	FROM
		tblLineItems_Receiving_InvoiceNumber t1
		inner join tblLineItems_Receiving lineitem(nolock) on lineitem.lineItemID = t1.lineItemId and lineitem.deleted=0
		inner join tblReceivingInfo_LineItems info(nolock) on info.lineItemID = lineitem.lineItemID and info.deleted = 0
		inner join tblReceivingInfo(nolock) on tblReceivingInfo.receivingID = info.receivingID and tblReceivingInfo.deleted = 0 
		inner join tblCustomers cust with(nolock) on cust.customerID = lineitem.customerID and cust.[Name] is not null and Len(cust.[Name]) > 0 and [Customer No] is not null and cust.Deleted=0
	where
		tblReceivingInfo.receivingID = @ID
END;  

GO

CREATE TRIGGER tblCustomers_Update
ON dbo.tblCustomers
AFTER UPDATE
AS  
BEGIN
	declare @ID INT = 0
	select @ID = customerID
	FROM inserted  

	update t1
	SET
		InvoiceNumber = RIGHT('0' + RTRIM(MONTH([WeekEndingDate])), 2)        
		+ RIGHT('0' + RTRIM(DAY([WeekEndingDate])), 2)        
		+ Right(LTRIM(RTrim([Customer No])),2)         
		+ SUBSTRING([Customer No],4,1) 
	FROM
		tblLineItems_Receiving_InvoiceNumber t1
		inner join tblLineItems_Receiving lineitem(nolock) on lineitem.lineItemID = t1.lineItemId and lineitem.deleted=0
		inner join tblReceivingInfo_LineItems info(nolock) on info.lineItemID = lineitem.lineItemID and info.deleted = 0
		inner join tblReceivingInfo(nolock) on tblReceivingInfo.receivingID = info.receivingID and tblReceivingInfo.deleted = 0 
		inner join tblCustomers cust with(nolock) on cust.customerID = lineitem.customerID and cust.[Name] is not null and Len(cust.[Name]) > 0 and [Customer No] is not null and cust.Deleted=0
	where
		cust.customerID = @ID
END;  


GO

/****** Object:  StoredProcedure [dbo].[BillOfLading_Report_GetAll]    Script Date: 4/25/2022 12:35:55 AM ******/
DROP PROCEDURE [dbo].[BillOfLading_Report_GetAll]
GO

/****** Object:  StoredProcedure [dbo].[BillOfLading_Report_GetDropDowns]    Script Date: 4/25/2022 12:35:55 AM ******/
DROP PROCEDURE [dbo].[BillOfLading_Report_GetDropDowns]
GO

/****** Object:  StoredProcedure [dbo].[BillOfLading_Report_GetDropDowns]    Script Date: 4/25/2022 12:35:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[BillOfLading_Report_GetDropDowns]
AS
BEGIN
	SET NOCOUNT ON;

	select distinct cust.customerID, [Customer No] as customerNumber, [Name] as customerName  from tblLineItems_Receiving lineitem with(nolock)
		inner join tblCustomers cust with(nolock) on cust.customerID = lineitem.customerID and cust.[Name] is not null and Len(cust.[Name]) > 0 and [Customer No] is not null and cust.Deleted = 0
	where
		lineitem.deleted = 0
	order by customerName asc


	select distinct info.BatchID from tblReceivingInfo info with(nolock) where
		info.BatchID is not null and Len(info.BatchID) > 0
		and info.deleted = 0
	order by 1 

	--select distinct lineitem.BillOfLadingNumber from tblLineItems_Receiving lineitem with(nolock)
	--	inner join tblCustomers cust with(nolock) on cust.customerID = lineitem.customerID and cust.[Name] is not null and Len(cust.[Name]) > 0 and [Customer No] is not null and cust.Deleted = 0
	--where
	--	lineitem.BillOfLadingNumber is not null and Len(lineitem.BillOfLadingNumber) > 0
	--	and lineitem.deleted = 0
	--order by 1 

	select distinct InvoiceNumber from tblLineItems_Receiving_InvoiceNumber(nolock) order by 1 
 --  select distinct RIGHT('0' + RTRIM(MONTH([WeekEndingDate])), 2)        
	--   + RIGHT('0' + RTRIM(DAY([WeekEndingDate])), 2)        
	--   + Right(LTRIM(RTrim([Customer No])),2)         
	--   + SUBSTRING([Customer No],4,1) As InvoiceNumber
	--from tblLineItems_Receiving lineitem with(nolock)
	--   inner join tblReceivingInfo_LineItems info on info.lineItemID = lineitem.lineItemID        
	--   inner join tblReceivingInfo on tblReceivingInfo.receivingID = info.receivingID        
	--   inner join tblCustomers cust with(nolock) on cust.customerID = lineitem.customerID and cust.[Name] is not null and Len(cust.[Name]) > 0 and [Customer No] is not null
	--where
	--	[WeekEndingDate] is not null
	--order by 1
END
GO

/****** Object:  StoredProcedure [dbo].[BillOfLading_Report_GetAll]    Script Date: 4/25/2022 12:35:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--exec [BillOfLading_Report_GetAll] '2013-08-01','',null,'','',0, 1, 10       
CREATE procedure [dbo].[BillOfLading_Report_GetAll] --'1/1/2019', 'q'        
(    
 @receivedDate datetime = '',  
 @batchId nvarchar(50) = '',  
 @invoiceNumber nvarchar(50) = null,  
 @billOfLadingNumber nvarchar(50) = '',  
 @customerName nvarchar(200) = '',  
 @ExportToExcel bit = 0,  
 @pageNumber INT = 1,  
 @pageSize INT = 30,    
 @weekEndingDate datetime = '',
 @currentRecordId INT = NULL
)  
AS  
BEGIN  
 SET NOCOUNT ON;        
 SET @invoiceNumber = ISNULL(@invoiceNumber, '');  
 SET @currentRecordId = NULLIF(@currentRecordId, 0);
   
 if(@ExportToExcel = 0)        
 BEGIN        
  select *        
  , CEILING((count(*) over ())*1.0/@pageSize) AS TotalPages      
  , (count(*) over ()) AS TotalCount        
  FROM        
  (        
   select        
    RIGHT('0' + RTRIM(MONTH([WeekEndingDate])), 2)        
    + RIGHT('0' + RTRIM(DAY([WeekEndingDate])), 2)        
    + Right(LTRIM(RTrim([Customer No])),2)         
    + SUBSTRING([Customer No],4,1) As InvoiceNumber        
 , tblReceivingInfo.BatchID  
    , CAST(WeekEndingDate as date) As [Date]        
    , CAST(ReceivedDate as date) AS ReceivedDate        
    , BillOfLadingNumber as [BOL#]        
    , cust.[Customer No] + ' ' + cust.Name As CustomerName        
    , Shipper        
    , Trucker        
    , sc.[Sales Code] As SalesCode        
    , sc.[Description]        
    , sc.[Unit of Measure] As UnitOfMeasure        
    , lineitem.Quantity As Qty        
    , sc.Price        
    , lineitem.Quantity * Isnull(sc.Price, 0) As Total         
    --, lineitem.lineitemId As LineItemId  
   from tblLineItems_Receiving lineitem        
    inner join tblReceivingInfo_LineItems info on info.lineItemID = lineitem.lineItemID        
    inner join tblReceivingInfo on tblReceivingInfo.receivingID = info.receivingID        
    left join tblTruckers truck on truck.truckerID = tblReceivingInfo.truckerID        
    Left join tblCustomers cust on cust.customerID = lineitem.customerID        
    left join tblShippers ship on ship.shipperID = lineitem.shipperID        
    left join tblSalesCodes sc on sc.salesCodeID = lineitem.salesCodeID        
   where    
	tblReceivingInfo.receivingID = ISNULL(@currentRecordId, tblReceivingInfo.receivingID)
 AND (@receivedDate = '' or ReceivedDate = @receivedDate)        
 AND (@weekEndingDate = '' or WeekEndingDate = @weekEndingDate)  
 AND (@batchId = '' OR tblReceivingInfo.BatchID like '%' + @batchId + '%')  
 AND (  
  @invoiceNumber = '' OR   
   (RIGHT('0' + RTRIM(MONTH([WeekEndingDate])), 2)        
   + RIGHT('0' + RTRIM(DAY([WeekEndingDate])), 2)        
   + Right(LTRIM(RTrim([Customer No])),2)         
   + SUBSTRING([Customer No],4,1)) like '%' + @invoiceNumber + '%'  
 )  
 AND (  
  @customerName = ''  
  OR  
  (cust.[Customer No] + ' ' + cust.Name) like '%' + @customerName + '%'  
 )  
 AND (  
  @billOfLadingNumber = ''  
  OR  
  (BillOfLadingNumber like '%' + @billOfLadingNumber + '%')  
 )  
 AND info.deleted = 0        
 AND [Customer No] IS NOT NULL        
  ) d        
  Order By InvoiceNumber, 3, 4     
  Offset (@pageNumber - 1) * @pageSize Rows        
  Fetch Next @pageSize Rows Only       
 END        
 ELSE        
 BEGIN        
   select RIGHT('0' + RTRIM(MONTH([WeekEndingDate])), 2)        
   + RIGHT('0' + RTRIM(DAY([WeekEndingDate])), 2)        
   + Right(LTRIM(RTrim([Customer No])),2)         
   + SUBSTRING([Customer No],4,1) As InvoiceNumber,        
   tblReceivingInfo.BatchID,   
   lineitem.lineitemId As LineItemId,        
   cAST(WeekEndingDate as date) As InvoiceDate,        
   cAST(ReceivedDate as date) AS ReceivedDate,        
        
   BillOfLadingNumber, cust.[Customer No] + ' ' + cust.Name As CustomerName, Shipper, Trucker,        
        
    sc.[Sales Code] As SalesCode, sc.Description, sc.[Unit of Measure] As UnitOfMeasure, lineitem.Quantity As Quantity,         
    --BatchID,         
   -- table3        
   sc.Price,         
   lineitem.Quantity * Isnull(sc.Price, 0) As Total         
   from tblLineItems_Receiving lineitem        
   inner join tblReceivingInfo_LineItems info on info.lineItemID = lineitem.lineItemID        
   inner join tblReceivingInfo on tblReceivingInfo.receivingID = info.receivingID        
   left join tblTruckers truck on truck.truckerID = tblReceivingInfo.truckerID        
   Left join tblCustomers cust on cust.customerID = lineitem.customerID        
   left join tblShippers ship on ship.shipperID = lineitem.shipperID        
   left join tblSalesCodes sc on sc.salesCodeID = lineitem.salesCodeID        
   where
	tblReceivingInfo.receivingID = ISNULL(@currentRecordId, tblReceivingInfo.receivingID)
		AND (@receivedDate = '' or ReceivedDate = @receivedDate)        
		AND (@weekEndingDate = '' or WeekEndingDate = @weekEndingDate)     
		AND info.deleted = 0        
		AND [Customer No] IS NOT NULL        
 AND (@batchId = '' OR tblReceivingInfo.BatchID like '%' + @batchId + '%')  
 AND (  
  @invoiceNumber = '' OR   
   (RIGHT('0' + RTRIM(MONTH([WeekEndingDate])), 2)        
   + RIGHT('0' + RTRIM(DAY([WeekEndingDate])), 2)        
   + Right(LTRIM(RTrim([Customer No])),2)         
   + SUBSTRING([Customer No],4,1)) like '%' + @invoiceNumber + '%'  
 )  
 AND (  
  @customerName = ''  
  OR  
  (cust.[Customer No] + ' ' + cust.Name) like '%' + @customerName + '%'  
 )  
 AND (  
  @billOfLadingNumber = ''  
  OR  
  (BillOfLadingNumber like '%' + @billOfLadingNumber + '%')  
 )  
 END             
END 
GO

