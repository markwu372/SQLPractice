-- How many products can you find in the Production.Product table?
SELECT COUNT(*) FROM Production.Product; -- RETURNS 504

-- Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(*) FROM Production.Product WHERE ProductSubcategoryID IS NOT NULL; --RETURNS 295

-- How many Products reside in each SubCategory? Write a query to display the results with the following titles.
SELECT ProductSubcategoryID, COUNT(ProductID) AS CountedProducts FROM Production.Product GROUP BY ProductSubcategoryID;

--  How many products that do not have a product subcategory.
SELECT COUNT(*) FROM Production.Product WHERE ProductSubcategoryID IS NULL; --RETURNS 209

--  Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT SUM(Quantity) FROM Production.ProductInventory;

-- Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
SELECT ProductID,SUM(Quantity) AS TheSum FROM Production.ProductInventory WHERE LocationID=40 GROUP BY ProductID HAVING SUM(Quantity) < 100;

-- Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
SELECT ProductID, Shelf, SUM(Quantity) AS TheSum FROM Production.ProductInventory WHERE LocationID=40 GROUP BY ProductID, Shelf HAVING SUM(Quantity) < 100;

-- Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT AVG(Quantity) AS TheAvg FROM Production.ProductInventory WHERE LocationID=10; --RETURNS 295

-- Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg FROM Production.ProductInventory GROUP BY ProductID, Shelf;

-- Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg FROM Production.ProductInventory WHERE Shelf <> 'N/A' GROUP BY ProductID, Shelf;

-- List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
SELECT Color, Class, COUNT(*), AVG(ListPrice) FROM Production.Product WHERE Color IS NOT NULL AND Class IS NOT NULL GROUP BY GROUPING SETS ((Color), (Class))

-- Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following
SELECT c.Name as COUNTRY, s.Name AS PROVINCE FROM Person.CountryRegion c JOIN Person.StateProvince s on c.CountryRegionCode=s.CountryRegionCode;

-- Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
SELECT c.Name as COUNTRY, s.Name AS PROVINCE FROM Person.CountryRegion c JOIN Person.StateProvince s on c.CountryRegionCode=s.CountryRegionCode WHERE c.Name in ('Germany', 'Canada') ORDER BY COUNTRY;

-- List all Products that has been sold at least once in last 25 years.
SELECT DISTINCT od.ProductID FROM dbo.Orders o join dbo.[Order Details] od on o.OrderID=od.OrderID 
WHERE o.OrderDate BETWEEN '1998-02-16' AND '2023-02-15' ORDER BY od.ProductID;

-- List top 5 locations (Zip Code) where the products sold most.
SELECT TOP 5 o.ShipPostalCode, count(*) as num FROM dbo.Orders o GROUP BY o.ShipPostalCode ORDER BY num DESC;

-- List top 5 locations (Zip Code) where the products sold most in last 25 years.
SELECT TOP 5 ShipPostalCode, count(*) as num FROM dbo.Orders o WHERE OrderDate BETWEEN '1998-02-16' AND '2023-02-15' GROUP BY ShipPostalCode ORDER BY num DESC;

--  List all city names and number of customers in that city. 
SELECT City, COUNT(CustomerID) AS NUM FROM dbo.Customers GROUP BY City;

--  List city names which have more than 2 customers, and number of customers in that city
SELECT City, COUNT(CustomerID) AS NUM FROM dbo.Customers GROUP BY City HAVING COUNT(CustomerID)>2;

-- List the names of customers who placed orders after 1/1/98 with order date.
SELECT DISTINCT c.ContactName FROM dbo.Orders o JOIN dbo.Customers c on o.CustomerID=c.CustomerID WHERE OrderDate > '1998-01-01';

--  List the names of all customers with most recent order dates
SELECT c.ContactName, MAX(o.OrderDate) 'most recent' FROM dbo.Orders o JOIN dbo.Customers c on o.CustomerID=c.CustomerID WHERE OrderDate > '1998-01-01' GROUP BY c.ContactName;

--  Display the names of all customers  along with the  count of products they bought
select c.Contactname,cp.s 'COUNT OF PRODUCTS' from customers c inner join (select customerid,sum(quantity) s from [Order Details] od inner join
orders o on od.OrderID=o.OrderID group by CustomerID)cp on c.CustomerID=cp.customerid

-- Display the customer ids who bought more than 100 Products with count of products.
select c.CustomerID,cp.s 'COUNT OF PRODUCTS' from customers c inner join (select customerid,sum(quantity) s from [Order Details] od inner join
orders o on od.OrderID=o.OrderID group by CustomerID)cp on c.CustomerID=cp.customerid WHERE cp.s > 100;

-- List all of the possible ways that suppliers can ship their products. Display the results as below
select s.CompanyName 'Supplier Company Name', sh.CompanyName 'Shipping Company Name' from Suppliers s CROSS JOIN Shippers sh ORDER BY s.CompanyName;

-- Display the products order each day. Show Order date and Product Name.
select o.OrderDate,r.ProductName from (SELECT od.OrderID,p.ProductName FROM [Order Details] od JOIN products p on od.ProductID=p.ProductID) r join Orders o on r.OrderID=o.OrderID ORDER BY o.OrderDate;

-- Displays pairs of employees who have the same job title.
select e1.FirstName + ' ' + e1.LastName 'Employee1', e2.FirstName + ' ' + e2.LastName 'Employee2' from Employees e1 join Employees e2 on e1.title=e2.title where e1.FirstName <> e2.FirstName OR e1.LastName <> e2.LastName;

-- Display all the Managers who have more than 2 employees reporting to them.
SELECT e.FirstName + ' '+e.LastName 'Name' from Employees e where ReportsTo > 2;

-- Display the customers and suppliers by city. The results should have the following columns
-- City Name Contact Name, Type (Customer or Supplier)
( SELECT c.City, c.ContactName, 'Customer' as 'Type' FROM Customers c)
UNION ALL 
( SELECT s.City, s.ContactName, 'Supplier' as 'Type' FROM suppliers s)
ORDER BY City