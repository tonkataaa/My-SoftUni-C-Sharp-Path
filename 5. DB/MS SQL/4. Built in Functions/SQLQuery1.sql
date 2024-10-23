-- 1. Find Names of All Employees by First Name
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'Sa%'

-- 2. Find Names of All Employees by Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

-- 3. Find First Names of All Employees
SELECT FirstName
FROM Employees
WHERE (DepartmentID = 3 OR DepartmentID = 10) 
AND HireDate BETWEEN '1995-01-01' AND '2005-12-31'

-- 4. Find All Employees Except Engineers
SELECT FirstName, LastName
FROM Employees
WHERE NOT (JobTitle LIKE '%engineer%')

-- 5. Find Towns with Name Length
SELECT [Name]
FROM Towns 
WHERE LEN([Name]) >= 5 AND LEN([Name]) <= 6
ORDER BY [Name]

-- 6. Find Towns Starting With
SELECT *
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

-- 7. Find Towns Not Starting With
SELECT *
FROM Towns
WHERE NOT [Name] LIKE '[RBD]%'
ORDER BY [Name]

-- 8. Create View Employees Hired After 2000 Year
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE HireDate > '2000-12-31'

-- 9. Length of Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

-- 10. Rank Employees by Salary
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

-- 11. Find All Employees with RANK 2 *
WITH RankedEmployees AS (
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
)
SELECT EmployeeId, FirstName, LastName, Salary, [Rank]
FROM RankedEmployees
WHERE [Rank] = 2
ORDER BY Salary DESC


-- 12. Countries Holding ‘A’ 3 or More Times
SELECT CountryName, IsoCode
FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(LOWER(CountryName), 'a', '')) >= 3
ORDER BY ISOCode

-- 13. Mix of Peak and River Names
SELECT PeakName, RiverName, 
       LOWER(CONCAT(PeakName, RiverName)) AS Mix
FROM Peaks
JOIN Rivers
  ON RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix;

-- 14. Games from 2011 and 2012 year
SELECT TOP 50 [Name], [Start]
FROM Games
WHERE [Start] >= '2011-01-01' AND [Start] <= '2012-12-31' 
ORDER BY [Start]

-- 15. User Email Providers
SELECT Username,
SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS Email_Provider
FROM Users
ORDER BY Email_Provider 

-- 16. Get Users with IPAdress Like Pattern
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

-- 17. Show All Games with Duration and Part of the Day
SELECT 
    [Name], 
    CASE 
        WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
        WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
        ELSE 'Evening'
    END AS PartOfDay,
    CASE 
        WHEN Duration IS NULL THEN 'Extra Long'
        WHEN Duration <= 3 THEN 'Extra Short'
        WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
        ELSE 'Long'
    END AS DurationCategory
FROM Games
ORDER BY 
    [Name] ASC, 
    DurationCategory ASC, 
    PartOfDay ASC;

-- 18. Orders Table
SELECT 
ProductName, 
OrderDate,
DATEADD(DAY, 3, OrderDate) AS Pay_Due,
DATEADD(MONTH, 1, OrderDate) AS Deliver_Due
FROM Orders

-- 19. People Table
SELECT 
[Name],
DATEDIFF(YEAR, Birthdate GETDATE()) AS Age_in_Years,               
DATEDIFF(MONTH, Birthdate, GETDATE()) % 12 AS Age_in_Months,       
DATEDIFF(DAY, DATEADD(MONTH, DATEDIFF(MONTH, Birthdate, GETDATE()), Birthdate), GETDATE()) AS Age_in_Days,  
DATEDIFF(MINUTE, Birthdate, GETDATE()) AS Age_in_Minutes 
FROM Original_Table