/*
商务信息
*/
CREATE TABLE [dbo].[Shop]
(
	[Id]			BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name]			NVARCHAR(50)	UNIQUE NOT NULL,	
	[License]		NVARCHAR(50)	NULL,
	[Category]		INT  NULL,
	[Contact]		NVARCHAR(50)	NULL,
	[ContactNo]		NVARCHAR(100)	NULL,	
	[Coordinate]	VARCHAR(100)	NULL,
	[Address]		NVARCHAR(100)	NULL,
	[Description]	NVARCHAR(500)	NULL,	
	[Extend]		NVARCHAR(MAX)	NULL	DEFAULT('{}')
)
