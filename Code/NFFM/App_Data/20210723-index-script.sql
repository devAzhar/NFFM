﻿CREATE NONCLUSTERED INDEX [IX_tblReceivingInfo_LineItems_1]
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