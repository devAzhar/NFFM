
ALTER procedure [dbo].[BillOfLading_AddUpdate]
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
	DECLARE @CreatedLineID INT = 0

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
		SET @CreatedLineID = @lineItemId
		insert into tblReceivingInfo_LineItems
		values(@receivingId, @lineItemId, 0) 

		insert into tblLineItems_Receiving
		values(@lineItemId, @billOfLading, ISNULL(@newCustomerId, -1), ISNULL(@newShipperId, -1), ISNULL(@newSalesCodeId, -1), ISNULL(@quantity, -1), 0)

		--delete from tblLineItems_Receiving where lineitemId > 1421522
		--delete from tblReceivingInfo_LineItems where lineitemId > 1421522
	END
	ELSE
	BEGIN 
		SET @CreatedLineID = @lineItemId
		
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

	select @CreatedLineID as CreatedLineID

END


--110550	1421521


--select top 10 * from tblLineItems_Receiving(nolock) order by 1 desc