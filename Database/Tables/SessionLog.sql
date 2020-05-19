
IF OBJECT_ID('dbo.SessionLog', 'u') IS NOT NULL 
  DROP TABLE [dbo].[SessionLog];

GO
CREATE TABLE [dbo].[SessionLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[token] [nvarchar](500) NOT NULL,
	[LoginTime] [datetime] NOT NULL,
	[LogOutTime] [datetime] NULL,
	[ExpirationTime] [datetime] NOT NULL,
	[IsOnline] [bit] NOT NULL,
	[IPAddress] [varchar](50) NULL,
	[Platform] [varchar](100) NULL,
	[Browser] [varchar](100) NULL,
	[OSName] [varchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteBy] [varchar](50) NULL,
 CONSTRAINT [PK_SessionLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SessionLog] ADD  CONSTRAINT [SessionLog_DF_LoginTime]  DEFAULT (getdate()) FOR [LoginTime]
GO
ALTER TABLE [dbo].[SessionLog] ADD  CONSTRAINT [SessionLog_DF_IsOnline]  DEFAULT ((1)) FOR [IsOnline]
GO
ALTER TABLE [dbo].[SessionLog] ADD  CONSTRAINT [SessionLog_DF_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[SessionLog] ADD  CONSTRAINT [SessionLog_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[SessionLog] ADD  CONSTRAINT [SessionLog_DF_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO