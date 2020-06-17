
IF OBJECT_ID('dbo.EmployeeIdentification', 'u') IS NOT NULL 
  DROP TABLE [dbo].[EmployeeIdentification];

GO
CREATE TABLE [dbo].[EmployeeIdentification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Code] [varchar](15) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[PlaceId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[Notes] [nvarchar](255) NULL,
	[ExpirationDate] [date] NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_EmployeeIdentification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeIdentification] ADD  CONSTRAINT [EmployeeIdentification_DF_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeIdentification] ADD  CONSTRAINT [EmployeeIdentification_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[EmployeeIdentification] ADD  CONSTRAINT [EmployeeIdentification_DF_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO