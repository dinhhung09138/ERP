
IF OBJECT_ID('dbo.HR_Employee', 'u') IS NOT NULL 
  DROP TABLE [dbo].[HR_Employee];

GO
CREATE TABLE [dbo].[HR_Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeCode] [varchar](15) NOT NULL,
	[AvatarFileId] [int] NULL,
	[ProbationDate] [datetime] NULL,
	[StartWorkingDate] [datetime] NULL,
	[BadgeCardNumber] [varchar](10) NULL,
	[DateApplyBadge] [datetime] NULL,
	[FingerSignNumber] [varchar](10) NULL,
	[DateApplyFingerSign] [datetime] NULL,
	[WorkingEmail] [varchar](50) NULL,
	[WorkingPhone] [varchar](20) NULL,
	[EmployeeWorkingStatusId] [int] NOT NULL,
	[BasicSalary] [money] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_HR_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HR_Employee] ADD  CONSTRAINT [HR_Employee_DF_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[HR_Employee] ADD  CONSTRAINT [HR_Employee_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[HR_Employee] ADD  CONSTRAINT [HR_Employee_DF_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
EXEC sys.sp_addextendedproperty 
@name=N'MS_Description', 
@value=N'Mã thẻ từ nhân viên Employee Badges, For each employee have a badge card' ,
@level0type=N'SCHEMA',
@level0name=N'dbo', 
@level1type=N'TABLE',
@level1name=N'HR_Employee', 
@level2type=N'COLUMN',
@level2name=N'BadgeCardNumber'
GO
CREATE UNIQUE INDEX HR_Employee_Uidx_Code ON [dbo].[HR_Employee]([EmployeeCode])