
IF OBJECT_ID('dbo.Training_TrainingCourse', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Training_TrainingCourse];

GO
CREATE TABLE [dbo].[Training_TrainingCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[StartDate] [datetime] NOT NULL,
	[CompleteDate] [datetime] NOT NULL,
	[LecturerId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Training_TrainingCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Training_TrainingCourse] ADD  CONSTRAINT [DF_Training_TrainingCourse_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Training_TrainingCourse] ADD  CONSTRAINT [DF_Training_TrainingCourse_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Training_TrainingCourse] ADD  CONSTRAINT [DF_Training_TrainingCourse_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO