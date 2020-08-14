
IF OBJECT_ID('dbo.Security_RoleDetail', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Security_RoleDetail];

GO
CREATE TABLE [dbo].[Security_RoleDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[CommandId] [int] NOT NULL,
 CONSTRAINT [PK_Security_RoleDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
