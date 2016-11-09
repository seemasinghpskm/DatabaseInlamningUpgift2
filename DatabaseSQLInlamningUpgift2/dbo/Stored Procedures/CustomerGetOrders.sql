CREATE PROCEDURE CustomerGetOrders (@CustomerID NCHAR(5))   
AS

 SELECT  Customers.ContactName, Customers.CompanyName, Orders.OrderDate
FROM            Customers INNER JOIN
                         Orders ON Customers.CustomerID = Orders.CustomerID
WHERE Customers.CustomerID=@CustomerID
