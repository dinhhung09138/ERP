
IF OBJECT_ID('dbo.Training_AppraiseAnswer', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Training_AppraiseAnswer];

GO
CREATE TABLE [dbo].[Training_AppraiseAnswer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppraiseQuestionId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Point] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Training_AppraiseAnswer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Training_AppraiseAnswer] ADD  CONSTRAINT [DF_Training_AppraiseAnswer_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Training_AppraiseAnswer] ADD  CONSTRAINT [DF_Training_AppraiseAnswer_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Training_AppraiseAnswer] ADD  CONSTRAINT [DF_Training_AppraiseAnswer_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO