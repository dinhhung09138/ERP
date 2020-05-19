
IF OBJECT_ID('dbo.CodeType', 'u') IS NOT NULL 
  DROP TABLE [dbo].[CodeType];

GO
CREATE TABLE [dbo].[CodeType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[TypeCode] [varchar](30) NOT NULL,
	[TypeName] [nvarchar](100) NOT NULL,
	[ModuleCode] [varchar](30) NOT NULL,
	[ModuleName] [nvarchar](100) NOT NULL,
	[Precedence] [int] NOT NULL,
 CONSTRAINT [PK_CodeType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO