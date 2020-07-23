
IF OBJECT_ID('dbo.Training_TrainingCourseDocument', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Training_TrainingCourseDocument];

GO
CREATE TABLE [dbo].[Training_TrainingCourseDocument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[FileId] [int] NOT NULL,
	[TrainingCourseId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Training_TrainingCourseDocument] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Training_TrainingCourseDocument] ADD  CONSTRAINT [DF_Training_TrainingCourseDocument_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Training_TrainingCourseDocument] ADD  CONSTRAINT [DF_Training_TrainingCourseDocument_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Training_TrainingCourseDocument] ADD  CONSTRAINT [DF_Training_TrainingCourseDocument_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO