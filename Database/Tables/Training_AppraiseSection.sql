
IF OBJECT_ID('dbo.Training_AppraiseSection', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Training_AppraiseSection];

GO
CREATE TABLE [dbo].[Training_AppraiseSection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppraiseId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Training_AppraiseSection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Training_AppraiseSection] ADD  CONSTRAINT [DF_Training_AppraiseSection_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Training_AppraiseSection] ADD  CONSTRAINT [DF_Training_AppraiseSection_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Training_AppraiseSection] ADD  CONSTRAINT [DF_Training_AppraiseSection_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO