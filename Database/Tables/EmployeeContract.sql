
IF OBJECT_ID('dbo.EmployeeContract', 'u') IS NOT NULL 
  DROP TABLE [dbo].[EmployeeContract];

GO
CREATE TABLE [dbo].[EmployeeContract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractNumber] [varchar](20) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[EmployeeProcessId] [int] NOT NULL,
	[ContractTypeId] [int] NOT NULL,
	[FromDate] [datetime] NOT NULL,
	[ToDate] [datetime] NULL,
	[SignOn] [datetime] NOT NULL,
	[Comment] [nvarchar](255) NULL,
	[GrossSalary] [money] NOT NULL,
	[NetSalary] [money] NOT NULL,
	[ContractStatusId] [int] NULL,
	[ContractStatusSignId] [int] NULL,
	[ContractStatusReason] [nvarchar](255) NULL,
	[ContractStatusDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedBy] [int] NULL,
 CONSTRAINT [PK_EmployeeContract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeContract] ADD  CONSTRAINT [EmployeeContract_DF_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeContract] ADD  CONSTRAINT [EmployeeContract_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[EmployeeContract] ADD  CONSTRAINT [EmployeeContract_DF_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
EXEC sys.sp_addextendedproperty 
@name=N'MS_Description', 
@value=N'Get From CodeType table.' , 
@level0type=N'SCHEMA',
@level0name=N'dbo', 
@level1type=N'TABLE',
@level1name=N'EmployeeContract', 
@level2type=N'COLUMN',
@level2name=N'ContractStatusId'
GO