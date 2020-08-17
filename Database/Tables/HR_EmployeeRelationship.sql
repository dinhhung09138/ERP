
IF OBJECT_ID('dbo.HR_EmployeeRelationship', 'u') IS NOT NULL 
  DROP TABLE [dbo].[HR_EmployeeRelationship];

GO
CREATE TABLE [dbo].[HR_EmployeeRelationship](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[RelationshipTypeId] [int] NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Mobile] [varchar](15) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_HR_EmployeeRelationship] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HR_EmployeeRelationship] ADD  CONSTRAINT [HR_EmployeeRelationship_DF_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[HR_EmployeeRelationship] ADD  CONSTRAINT [HR_EmployeeRelationship_DF_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[HR_EmployeeRelationship] ADD  CONSTRAINT [HR_EmployeeRelationship_DF_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO