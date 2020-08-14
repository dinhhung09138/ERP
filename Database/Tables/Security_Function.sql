
IF OBJECT_ID('dbo.Security_Function', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Security_Function];

GO
CREATE TABLE [dbo].[Security_Function](
	[Code] [VARCHAR](20) PRIMARY KEY,
	[Name] [NVARCHAR](50) NOT NULL,
	[Url] [VARCHAR](255) NULL,
	[Icon] [VARCHAR](255) NULL,
	[ParentCode] [VARCHAR](20) NULL,
	[Precedence] [int] NOT NULL,
	[ModuleCode] [VARCHAR](20) NOT NULL
)
