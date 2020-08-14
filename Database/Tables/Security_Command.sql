
IF OBJECT_ID('dbo.Security_FunctionCommand', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Security_FunctionCommand];

GO
CREATE TABLE [dbo].[Security_FunctionCommand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FunctionCode] [VARCHAR](20),
	[Name] [NVARCHAR](50) NOT NULL,
	[ModuleName] [VARCHAR](50) NULL,
	[ControllerName] [VARCHAR](50) NOT NULL,
	[ActionName] [VARCHAR](50) NOT NULL,
	[Precedence] [int] NOT NULL,
 CONSTRAINT [PK_Security_FunctionCommand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO