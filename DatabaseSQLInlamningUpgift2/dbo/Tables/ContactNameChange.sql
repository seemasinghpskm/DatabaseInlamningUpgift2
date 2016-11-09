CREATE TABLE [dbo].[ContactNameChange]
(	[ContactNameChangeID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [nchar](5) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[OldContactName] [nvarchar](30) NULL,
	[NewContactName] [nvarchar](30) NULL,
	[ChangedDate] [datetime] NOT NULL,
  PRIMARY KEY CLUSTERED 
    (
        [ContactNameChangeID] ASC
    )
)
Go 
