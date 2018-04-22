CREATE TABLE [dbo].[WeChatUser]
(
	[Id]		 BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,	
	[Mobile]	 NVARCHAR(20) NOT NULL, 
	[NickName]	 BIGINT NOT NULL,
	[Gender]	 INT NULL,
	[City]		 NVARCHAR(50) NULL,
	[Province]	 NVARCHAR(50) NULL,
	[Country]	 NVARCHAR(50) NULL,	
	[AvatarUrl]	 NVARCHAR(500) NOT NULL,
	[FromWechat] BIT,
	CONSTRAINT [UK_MobileNumber] UNIQUE ([Mobile])
)

