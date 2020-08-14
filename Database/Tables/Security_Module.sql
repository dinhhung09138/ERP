
IF OBJECT_ID('dbo.Security_Module', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Security_Module];

GO
CREATE TABLE [dbo].[Security_Module](
	[Code] [VARCHAR](20) PRIMARY KEY,
	[Name] [NVARCHAR](50) NOT NULL,
	[Url] [VARCHAR](255) NULL,
	[Icon] [VARCHAR](255) NULL,
	[ParentCode] [VARCHAR](20) NULL,
	[Precedence] [int] NOT NULL,
)
GO