
IF OBJECT_ID('dbo.Training_SpecializedTraining', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Training_SpecializedTraining];

GO
CREATE TABLE [dbo].[Training_SpecializedTraining](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Training_SpecializedTraining] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Training_SpecializedTraining] ADD  CONSTRAINT [DF_Training_SpecializedTraining_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Training_SpecializedTraining] ADD  CONSTRAINT [DF_Training_SpecializedTraining_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Training_SpecializedTraining] ADD  CONSTRAINT [DF_Training_SpecializedTraining_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO