
IF OBJECT_ID('dbo.Common_File', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Common_File];

GO
CREATE TABLE [dbo].[Common_File](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](250) NOT NULL,
	[Size] [decimal](12, 0) NOT NULL,
	[MineType] [varchar](50) NOT NULL,
	[Extension] [varchar](10) NOT NULL,
	[SystemFileName] [varchar](100) NOT NULL,
	[FilePath] [varchar](300) NOT NULL,
	[FilePath32] [varchar](300) NULL,
	[FilePath64] [varchar](300) NULL,
	[FilePath128] [varchar](300) NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
 CONSTRAINT [PK_Common_File] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Common_File] ADD  CONSTRAINT [Common_File_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO