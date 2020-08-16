
IF OBJECT_ID('dbo.HR_ApproveStatus', 'u') IS NOT NULL 
  DROP TABLE [dbo].[HR_ApproveStatus];

GO
CREATE TABLE [dbo].[HR_ApproveStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Precedence] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_HR_ApproveStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HR_ApproveStatus] ADD  CONSTRAINT [DF_HR_ApproveStatus_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[HR_ApproveStatus] ADD  CONSTRAINT [DF_HR_ApproveStatus_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[HR_ApproveStatus] ADD  CONSTRAINT [DF_HR_ApproveStatus_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
CREATE UNIQUE INDEX HR_ApproveStatus_Uidx_Code ON [dbo].[HR_ApproveStatus]([Code])