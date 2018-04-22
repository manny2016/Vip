CREATE TABLE [dbo].[ShopAdmin]
(
	[ShopId] BIGINT NOT NULL,
	[WeChatId] BIGINT NOT NULL, 
    CONSTRAINT [PK_ShopAdmin] PRIMARY KEY ([ShopId], [WeChatId])	
)
