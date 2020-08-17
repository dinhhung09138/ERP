
IF OBJECT_ID('dbo.HR_EmployeeWorkingStatus', 'u') IS NOT NULL 
  DROP TABLE [dbo].[HR_EmployeeWorkingStatus];

GO
CREATE TABLE [dbo].[HR_EmployeeWorkingStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Precedence] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_HR_EmployeeWorkingStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HR_EmployeeWorkingStatus] ADD  CONSTRAINT [DF_HR_EmployeeWorkingStatus_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[HR_EmployeeWorkingStatus] ADD  CONSTRAINT [DF_HR_EmployeeWorkingStatus_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[HR_EmployeeWorkingStatus] ADD  CONSTRAINT [DF_HR_EmployeeWorkingStatus_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
CREATE UNIQUE INDEX HR_EmployeeWorkingStatus_Uidx_Code ON [dbo].[HR_EmployeeWorkingStatus]([Code])