
IF OBJECT_ID('dbo.HR_ContractType', 'u') IS NOT NULL 
  DROP TABLE [dbo].[HR_ContractType];

GO
CREATE TABLE [dbo].[HR_ContractType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[AllowInsurance] [bit] NOT NULL,
	[AllowLeaveDate] [bit] NOT NULL,
	[Precedence] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_HR_ContractType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HR_ContractType] ADD  CONSTRAINT [HR_ContractType_DF_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[HR_ContractType] ADD  CONSTRAINT [HR_ContractType_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[HR_ContractType] ADD  CONSTRAINT [HR_ContractType_DF_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO