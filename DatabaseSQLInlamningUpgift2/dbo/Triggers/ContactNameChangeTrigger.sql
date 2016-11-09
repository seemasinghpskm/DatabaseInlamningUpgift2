CREATE TRIGGER [ContactNameChangeTrigger]
	ON [dbo].[Customers]
FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON
    INSERT INTO [dbo].[ContactNameChange]
           ([CustomerID]
           ,[CompanyName]
           ,[OldContactName]
           ,[NewContactName]
           ,[ChangedDate])
        SELECT i.[CustomerID], i.[CompanyName] ,d.[ContactName], i.[ContactName], GETDATE() 
		            FROM inserted i
              INNER JOIN deleted d ON i.[CustomerID]=d.[CustomerID]
            WHERE d.[ContactName] <> i.[ContactName]
END