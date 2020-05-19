
IF OBJECT_ID('dbo.File', 'u') IS NOT NULL 
  DROP TABLE [dbo].[File];

GO
CREATE TABLE [dbo].[File](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](150) NOT NULL,
	[SystemFileName] [varchar](100) NOT NULL,
	[FilePath] [nvarchar](300) NOT NULL,
	[Size] [decimal](12, 0) NOT NULL,
	[Type] [varchar](12) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[File] ADD  CONSTRAINT [File_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO