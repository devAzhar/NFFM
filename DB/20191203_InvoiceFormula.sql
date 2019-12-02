-- Updated Invoice # formula (11/03/2019)
--declare @WeekEndingDate as date='2019-12-3'; select RIGHT('0'+cast(datepart(mm, @WeekEndingDate) as varchar(2)), 2)+Right('00'+cast(datepart(dd, @WeekEndingDate) as varchar(4)), 2)
--select cast(datepart(yy, '2019-12-03') as varchar(2)), datepart(yy, '2019-1-1'), cast(2019 as varchar(2))
--select cast(2019 as varchar(3))
GO

ALTER procedure [dbo].[BillOfLading_Report_GetAll] --'1/1/2019', 'q'
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

select top 100
	ReceivedDate,BatchID
	--Formula the Unloading  left to right   month(00), day(00) of the week ending date, (00)(00) 
    --Last 2 digits of customer # (00)
	--Beginning letter of customer # (0)
	--, cast(Right(Format([WeekEndingDate],'yy'),1) as nvarchar) +  cast(datepart(dayofyear, [WeekEndingDate]) as nvarchar)  + Right(LTRIM(RTrim([Customer No])),2)	 + SUBSTRING([Customer No],4,1) As InvoiceNumber_Old
	, RIGHT('0'+cast(datepart(mm, [WeekEndingDate]) as varchar(2)), 2)+Right('00'+cast(datepart(dd, [WeekEndingDate]) as varchar(2)), 2)+Right('NA'+LTRIM(RTrim([Customer No])),2)+SUBSTRING([Customer No],4,1) As InvoiceNumber
	--, [Customer No]
	--, [WeekEndingDate]

	, info.receivingID,info.lineitemid,BillOfLadingNumber,cust.Name As CustomerName
	, Shipper,sc.[Sales Code] As SalesCode, sc.Description, sc.[Unit of Measure] As UnitOfMeasure, lineitem.Quantity As Qty
	-- table3
	, sc.Price, lineitem.Quantity * Isnull(sc.Price, 0) As Ext
	from tblLineItems_Receiving lineitem
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

Exec Customers_GetAll @ShowAll = 0 -- table 5

END
