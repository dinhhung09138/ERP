
IF OBJECT_ID('dbo.HR_Ethnicity', 'u') IS NOT NULL 
  DROP TABLE [dbo].[HR_Ethnicity];

GO
CREATE TABLE [dbo].[HR_Ethnicity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Precedence] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_HR_Ethnicity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HR_Ethnicity] ADD  CONSTRAINT [DF_HR_Ethnicity_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[HR_Ethnicity] ADD  CONSTRAINT [DF_HR_Ethnicity_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[HR_Ethnicity] ADD  CONSTRAINT [DF_HR_Ethnicity_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO