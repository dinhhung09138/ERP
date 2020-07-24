
IF OBJECT_ID('dbo.Training_Lecturer', 'u') IS NOT NULL 
  DROP TABLE [dbo].[Training_Lecturer];

GO
CREATE TABLE [dbo].[Training_Lecturer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NOT NULL,
	[Avatar] [nvarchar](250) NULL,
	[Gender] [bit] NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Phone] [varchar](20) NULL,
	[mobile] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[Rating] [int] NULL,
	[IsWorkInCenter] [bit] NOT NULL,
	[TrainingCenterId] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Training_Lecturer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Training_Lecturer] ADD  CONSTRAINT [DF_Training_Lecturer_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Training_Lecturer] ADD  CONSTRAINT [DF_Training_Lecturer_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Training_Lecturer] ADD  CONSTRAINT [DF_Training_Lecturer_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO