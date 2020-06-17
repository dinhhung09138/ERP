
IF OBJECT_ID('dbo.EmployeeContact', 'u') IS NOT NULL 
  DROP TABLE [dbo].[EmployeeContact];

GO
CREATE TABLE [dbo].[EmployeeContact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Phone] [varchar](15) NULL,
	[Mobile] [varchar](15) NULL,
	[Email] [varchar](100) NULL,
	[Skyper] [varchar](50) NULL,
	[TemporaryAddress] [varchar](250) NULL,
	[TemporaryWardId] [int] NULL,
	[TemporaryDistrictId] [int] NULL,
	[TemporaryCityId] [int] NULL,
	[PermanentAddress] [varchar](250) NULL,
	[PermanentWardId] [int] NULL,
	[PermanentDistrictId] [int] NULL,
	[PermanentCityId] [int] NULL,
	[ExpirationDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_EmployeeContact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeContact] ADD  CONSTRAINT [EmployeeContact_DF_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeContact] ADD  CONSTRAINT [EmployeeContact_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[EmployeeContact] ADD  CONSTRAINT [EmployeeContact_DF_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO