
IF OBJECT_ID('dbo.HR_Commendation', 'u') IS NOT NULL 
  DROP TABLE [dbo].[HR_Commendation];

GO
CREATE TABLE [dbo].[HR_Commendation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Money] [money] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_HR_Commendation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HR_Commendation] ADD  CONSTRAINT [HR_Commendation_DF_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[HR_Commendation] ADD  CONSTRAINT [HR_Commendation_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[HR_Commendation] ADD  CONSTRAINT [HR_Commendation_DF_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO