
IF OBJECT_ID('dbo.Training_TrainingCenter', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Training_TrainingCenter];

GO
CREATE TABLE [dbo].[Training_TrainingCenter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Avatar] [nvarchar](250) NULL,
	[TaxCode] [varchar](20) NULL,
	[Phone] [varchar](20) NULL,
	[Description] [nvarchar](250) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Training_TrainingCenter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Training_TrainingCenter] ADD  CONSTRAINT [DF_Training_TrainingCenter_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Training_TrainingCenter] ADD  CONSTRAINT [DF_Training_TrainingCenter_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Training_TrainingCenter] ADD  CONSTRAINT [DF_Training_TrainingCenter_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO