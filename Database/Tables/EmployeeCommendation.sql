
IF OBJECT_ID('dbo.EmployeeCommendation', 'u') IS NOT NULL 
  DROP TABLE [dbo].[EmployeeCommendation];

GO
CREATE TABLE [dbo].[EmployeeCommendation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Money] [money] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Comment] [nvarchar](250) NULL,
	[CommendationId] [int] NOT NULL,
	[ProposerId] [int] NOT NULL,
	[ProposeDate] [datetime] NOT NULL,
	[ApprovedStatus] [int] NULL,
	[ApprovedDate] [datetime] NOT NULL,
	[ApprovedBy] [int] NOT NULL,
	[ExpirationDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedBy] [int] NULL,
 CONSTRAINT [PK_EmployeeCommendation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeCommendation] ADD  CONSTRAINT [DF_EmployeeCommendation_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeCommendation] ADD  CONSTRAINT [DF_EmployeeCommendation_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[EmployeeCommendation] ADD  CONSTRAINT [DF_EmployeeCommendation_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',
@value=N'Get from CodeType table' ,
@level0type=N'SCHEMA',
@level0name=N'dbo', 
@level1type=N'TABLE',
@level1name=N'EmployeeCommendation', 
@level2type=N'COLUMN',
@level2name=N'ApprovedStatus'
GO