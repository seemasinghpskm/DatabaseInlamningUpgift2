CREATE PROCEDURE [dbo].[UpdateProductPrice]
	(@ProductID nchar(4)
      ,@UnitPrice money)
AS
UPDATE [dbo].[Products]
   SET 
      [UnitPrice] = @UnitPrice 
      
 WHERE ProductID=@ProductID
GO

