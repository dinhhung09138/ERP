
IF OBJECT_ID('dbo.EmployeeInfo', 'u') IS NOT NULL 
  DROP TABLE [dbo].[EmployeeInfo];

GO
CREATE TABLE [dbo].[EmployeeInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
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
 CONSTRAINT [PK_EmployeeInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [EmployeeInfo_DF_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [EmployeeInfo_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [EmployeeInfo_DF_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO