-- 1.      List all cities that have both Employees and Customers.
SELECT distinct City FROM Customers where city IN (SELECT City FROM Employees);

-- 2.      List all cities that have Customers but no Employee.
-- a.      Use sub-query
SELECT distinct City FROM Customers where city NOT IN (SELECT City FROM Employees);

-- b.      Do not use sub-query
SELECT distinct City FROM Customers EXCEPT (SELECT City FROM Employees);

-- 3.      List all products and their total order quantities throughout all orders.
SELECT p.ProductName, pd.td as 'Total Quantites' FROM Products p LEFT JOIN 
(SELECT ProductID, SUM(Quantity) as td FROM [Order Details] 
GROUP BY ProductID) pd on p.ProductID=pd.ProductID

-- 4.      List all Customer Cities and total products ordered by that city.
SELECT o.ShipCity, SUM(Quantity) FROM Orders o join [Order Details] od on o.OrderID=od.OrderID GROUP BY o.ShipCity

-- 5.      List all Customer Cities that have at least two customers.
-- a.      Use union
SELECT City from customers INTERSECT (SELECT City FROM Customers GROUP BY City HAVING COUNT(*)>1)

-- b.      Use sub-query and no union
SELECT City FROM Customers GROUP BY City HAVING COUNT(*)>1

-- 6.      List all Customer Cities that have ordered at least two different kinds of products.
SELECT c.City FROM Customers c JOIN
(SELECT o.OrderID, od.ProductID, o.CustomerID FROM [Order Details] od join Orders o on od.OrderID=o.OrderID) r
on c.CustomerID=r.CustomerID GROUP by c.City HAVING COUNT(distinct r.ProductID)>1

-- 7.      List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
SELECT distinct c.CustomerID,c.ContactName FROM Customers c, Orders o
where c.CustomerID=o.CustomerID and c.City != o.ShipCity

-- 8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
WITH PopularProduct (ProductID, avgPrice, Quantity) AS
(SELECT TOP 5 ProductID, AVG(UnitPrice * (1 - Discount)) AS avgPrice, COUNT(*) AS Quantity
FROM [Order Details] GROUP BY ProductID ORDER BY COUNT(*) DESC)
SELECT p.ProductID, p.avgPrice, tb.City
FROM (
SELECT o2.ProductID, c.City, COUNT(*) AS cnt, RANK() OVER(PARTITION BY o2.ProductID ORDER BY COUNT(*) DESC) RNK
FROM Orders o, Customers c, [Order Details] o2
WHERE o.CustomerID = c.CustomerID AND o.OrderID = o2.OrderID
GROUP BY o2.ProductID, c.City) tb, PopularProduct p
WHERE tb.ProductID = p.ProductID AND RNK = 1

-- 9.      List all cities that have never ordered something but we have employees there.
-- a.      Use sub-query
SELECT distinct City FROM Employees e where City not in (SELECT ShipCity FROM [Orders])

-- b.      Do not use sub-query
SELECT distinct City FROM Employees e EXCEPT (SELECT ShipCity FROM [Orders])

-- 10.     List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
SELECT top 1 ShipCity AS City FROM
(SELECT ShipCity, COUNT(*) AS Occurence, RANK() OVER(ORDER BY COUNT(*)DESC) RNK
FROM Orders GROUP BY ShipCity) d
INTERSECT
SELECT top 1 OrderCity FROM
(SELECT c.City AS OrderCity, COUNT(*) as Occurence, RANK() OVER(ORDER BY COUNT(*) DESC) RNK
FROM Orders o, Customers c WHERE o.CustomerID = c.CustomerID
GROUP BY c.City) dt2

-- 11.     How do you remove the duplicates record of a table?

-- main idea :
-- Find duplicate rows using GROUP BY clause or ROW_NUMBER() function.
-- Use DELETE statement to remove the duplicate rows.
-- DELETE FROM [Table]
--     WHERE [Primary Key] NOT IN
--     (
--         SELECT MIN([Primary Key])
--         FROM [Table]
--         GROUP BY [All other fields]
--     )
