
IF OBJECT_ID('dbo.EmployeeEducation', 'u') IS NOT NULL 
  DROP TABLE [dbo].[EmployeeEducation];

GO
CREATE TABLE [dbo].[EmployeeEducation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[SchoolId] [int] NOT NULL,
	[SpecializedTrainingId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[TrainingTypeId] [int] NOT NULL,
	[RankingId] [int] NOT NULL,
	[ModelOfStudyId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedBy] [int] NULL,
 CONSTRAINT [PK_EmployeeEducation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeEducation] ADD  CONSTRAINT [EmployeeEducation_DF_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeEducation] ADD  CONSTRAINT [EmployeeEducation_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[EmployeeEducation] ADD  CONSTRAINT [EmployeeEducation_DF_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
EXEC sys.sp_addextendedproperty 
@name=N'MS_Description', 
@value=N'Education, Cetificated ' , 
@level0type=N'SCHEMA',
@level0name=N'dbo', 
@level1type=N'TABLE',
@level1name=N'EmployeeEducation', 
@level2type=N'COLUMN',
@level2name=N'TrainingTypeId'
GO