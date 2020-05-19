
IF OBJECT_ID('dbo.EmployeeDiscipline', 'u') IS NOT NULL 
  DROP TABLE [dbo].[EmployeeDiscipline];

GO
CREATE TABLE [dbo].[EmployeeDiscipline](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Money] [money] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Comment] [nvarchar](250) NULL,
	[DisciplineId] [int] NOT NULL,
	[ProposerId] [int] NOT NULL,
	[ProposeDate] [datetime] NOT NULL,
	[ApprovedBy] [int] NULL,
	[ApprovedDate] [datetime] NULL,
	[ApprovedStatusId] [int] NULL,
	[ExpirationDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedBy] [int] NULL,
 CONSTRAINT [PK_EmployeeDiscipline] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeDiscipline] ADD  CONSTRAINT [DF_EmployeeDiscipline_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeDiscipline] ADD  CONSTRAINT [DF_EmployeeDiscipline_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[EmployeeDiscipline] ADD  CONSTRAINT [DF_EmployeeDiscipline_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
GO
EXEC sys.sp_addextendedproperty 
@name=N'MS_Description', 
@value=N'Get From CodeType table.' ,
@level0type=N'SCHEMA',
@level0name=N'dbo', 
@level1type=N'TABLE',
@level1name=N'EmployeeDiscipline',
@level2type=N'COLUMN',
@level2name=N'ApprovedStatusId'
GO