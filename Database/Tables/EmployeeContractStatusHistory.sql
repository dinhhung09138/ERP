
IF OBJECT_ID('dbo.EmployeeContractStatusHistory', 'u') IS NOT NULL 
  DROP TABLE [dbo].[EmployeeContractStatusHistory];

GO
CREATE TABLE [dbo].[EmployeeContractStatusHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[SignId] [int] NOT NULL,
	[Reason] [nvarchar](255) NULL,
	[Date] [datetime] NULL,
	[GrossSalary] [money] NOT NULL,
	[NetSalary] [money] NOT NULL,
	[ExpirationDate] [datetime] NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
 CONSTRAINT [PK_EmployeeContractStatusHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeContractStatusHistory] ADD  CONSTRAINT [EmployeeContractStatusHistory_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
EXEC sys.sp_addextendedproperty 
@name=N'MS_Description', 
@value=N'Get From CodeType table.' , 
@level0type=N'SCHEMA',
@level0name=N'dbo', 
@level1type=N'TABLE',
@level1name=N'EmployeeContractStatusHistory', 
@level2type=N'COLUMN',
@level2name=N'StatusId'
GO