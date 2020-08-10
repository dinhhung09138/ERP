
IF OBJECT_ID('dbo.HR_EmployeeInfo', 'u') IS NOT NULL 
  DROP TABLE [dbo].[HR_EmployeeInfo];

GO
CREATE TABLE [dbo].[HR_EmployeeInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [bit] NULL,
	[DateOfBirth] [datetime] NULL,
	[MaterialStatusId] [int] NULL,
	[ReligionId] [int] NULL,
	[NationId] [int] NULL,
	[NationalityId] [int] NULL,
	[AcademicLevelId] [int] NULL,
	[ProfessionalQualificationId] [int] NULL,
	[ExpirationDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_HR_EmployeeInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HR_EmployeeInfo] ADD  CONSTRAINT [HR_EmployeeInfo_DF_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[HR_EmployeeInfo] ADD  CONSTRAINT [HR_EmployeeInfo_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[HR_EmployeeInfo] ADD  CONSTRAINT [HR_EmployeeInfo_DF_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO