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