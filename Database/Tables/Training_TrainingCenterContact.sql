
IF OBJECT_ID('dbo.Training_TrainingCenterContact', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Training_TrainingCenterContact];

GO
CREATE TABLE [dbo].[Training_TrainingCenterContact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Position] [nvarchar](200) NULL,
	[Phone] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[TrainingCenterId] [int] NOT NULL,
	[Precedence] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Training_TrainingCenterContact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Training_TrainingCenterContact] ADD  CONSTRAINT [DF_Training_TrainingCenterContact_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Training_TrainingCenterContact] ADD  CONSTRAINT [DF_Training_TrainingCenterContact_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Training_TrainingCenterContact] ADD  CONSTRAINT [DF_Training_TrainingCenterContact_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO