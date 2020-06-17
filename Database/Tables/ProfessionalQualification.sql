
IF OBJECT_ID('dbo.ProfessionalQualification', 'u') IS NOT NULL 
  DROP TABLE [dbo].[ProfessionalQualification];

GO
CREATE TABLE [dbo].[ProfessionalQualification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Precedence] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ProfessionalQualification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProfessionalQualification] ADD  CONSTRAINT [DF_ProfessionalQualification_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ProfessionalQualification] ADD  CONSTRAINT [DF_ProfessionalQualification_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[ProfessionalQualification] ADD  CONSTRAINT [DF_ProfessionalQualification_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO