/*
商铺会员信息
*/
CREATE TABLE [dbo].[Membership]
(
	[ShopId]	BIGINT		NOT NULL,
	[WeChatId]	BIGINT		NOT NULL,
	CONSTRAINT [PK_Membership] PRIMARY KEY ([ShopId], [WeChatId])	
)
