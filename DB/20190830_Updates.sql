
/****** Object:  StoredProcedure [dbo].[Truckers_GetAll]    Script Date: 8/30/19 00:44:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[Truckers_GetAll] 
(@SortBy nvarchar(100) = Null)
AS BEGIN
	if (@SortBy IS NULL)
	BEGIN
		select truckerID, [Trucker] from tblTruckers where deleted = 0  order by 2 
	END
	ELSE
	BEGIN
		select truckerID, [Trucker] from tblTruckers where deleted = 0  
		Order by [Trucker]
	END
END

GO

/****** Object:  StoredProcedure [dbo].[Customers_GetAll]    Script Date: 8/30/19 00:44:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[Customers_GetAll] 
(
@ShowAll int = 1
)
AS BEGIN
--select CustomerID, [Customer No], Name, CoOpMember As [CoOp Member], FF_Tier As [FF Tier] ,CustomerPricing As Price from tblCustomers where deleted = 0  order by customerId desc
select CustomerID, [Customer No], Isnull(Name, '') as Name, CoOpMember As [CoOp Member], FF_Tier As [FF Tier],CustomerPricing As Price from tblCustomers where deleted = 0  and Name is not null
AND(@ShowAll = 1 or (@ShowAll = 0 AND CoOpMember = 1))
--AND (name like '%Emerald Seafood%' or name like '%Lockwood%' or name like '%slavin%' )
order by 3
END

GO

/****** Object:  StoredProcedure [dbo].[Shippers_GetAll]    Script Date: 8/30/19 00:44:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[Shippers_GetAll]
AS BEGIN
--select CustomerID, [Customer No], Name, CoOpMember As [CoOp Member], FF_Tier As [FF Tier] ,CustomerPricing As Price from tblCustomers where deleted = 0  order by customerId desc
select ShipperID, [Shipper] from tblShippers where deleted = 0  and Shipper is not null order by [Shipper] asc
END


GO

