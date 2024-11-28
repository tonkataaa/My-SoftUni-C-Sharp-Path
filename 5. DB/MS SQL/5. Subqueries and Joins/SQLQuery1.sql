-- 1. Employee Address
SELECT TOP (5) 
Employees.EmployeeID, 
Employees.JobTitle,
Employees.AddressID,
Addresses.AddressText
FROM Employees
INNER JOIN Addresses ON Employees.AddressID = Addresses.AddressID
ORDER BY AddressID ASC

-- 2. Addresses with Towns
SELECT TOP(50)
Employees.FirstName,
Employees.LastName,
Towns.[Name] AS Town,
Addresses.AddressText
FROM Employees
INNER JOIN Addresses ON Employees.AddressID = Addresses.AddressID
INNER JOIN Towns ON Addresses.TownID = Towns.TownID
ORDER BY FirstName ASC, LastName ASC	

-- 3. Sales Employee
SELECT 
Employees.EmployeeID,
Employees.FirstName,
Employees.LastName,
Departments.[Name] AS DepartmentName
FROM Employees
INNER JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
WHERE Departments.[Name] = 'Sales'
ORDER BY EmployeeID ASC	

-- 4. Employee Departments
SELECT TOP(5)
Employees.EmployeeID,
Employees.FirstName,
Employees.Salary,
Departments.[Name] AS DepartmentName
FROM Employees
INNER JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
WHERE Salary > 15000
ORDER BY Departments.DepartmentID ASC

-- 5. Employees Without Project
SELECT TOP(3)
Employees.EmployeeID,
Employees.FirstName
FROM Employees
LEFT JOIN EmployeesProjects
ON Employees.EmployeeID = EmployeesProjects.EmployeeID
WHERE EmployeesProjects.ProjectID IS NULL
ORDER BY Employees.EmployeeID ASC

-- 6. Employees Hired After
SELECT 
Employees.FirstName,
Employees.LastName,
Employees.HireDate,
Departments.[Name] AS DeptName
FROM Employees
INNER JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
WHERE HireDate > '1.1.1999' AND Departments.[Name] = 'Sales' OR Departments.[Name] = 'Finance' 
ORDER BY Employees.HireDate ASC

-- 7. Employees with Project
SELECT TOP(5)
Employees.EmployeeID,
Employees.FirstName,
Projects.[Name] AS ProjectName
FROM Employees
FULL JOIN EmployeesProjects
ON Employees.EmployeeID = EmployeesProjects.EmployeeID
FULL JOIN Projects
ON EmployeesProjects.ProjectID = Projects.ProjectID
WHERE Projects.StartDate > '2002-08-13' 
    AND Projects.EndDate IS NULL
ORDER BY Employees.EmployeeID ASC

-- 8. Employee 24
SELECT
Employees.EmployeeID,
Employees.FirstName,
CASE
	WHEN Projects.StartDate >= '2005-01-01' THEN NULL
	ELSE Projects.[Name] 
	END AS ProjectName
FROM Employees
FULL JOIN EmployeesProjects
ON Employees.EmployeeID = EmployeesProjects.EmployeeID
FULL JOIN Projects
ON EmployeesProjects.ProjectID = Projects.ProjectID
WHERE Employees.EmployeeID = 24 

-- 9. Employee Manager
SELECT
Employees.EmployeeID,
Employees.FirstName,
Departments.ManagerID 
FROM Employees
INNER JOIN Departments
ON Departments.ManagerID = Employees.EmployeeID
WHERE Departments.ManagerID = 3 OR Departments.ManagerID = 7
ORDER BY Employees.EmployeeID ASC


-- 10. Employee Summary
SELECT TOP(50)
Employees.EmployeeID,
Employees.FirstName + ' ' + Employees.LastName AS EmployeeName,
Departments.[Name] AS DepartmentName
FROM Employees
INNER JOIN Departments
ON Departments.DepartmentID = Employees.EmployeeID
ORDER BY Employees.EmployeeID ASC

-- 11. Min Avg Salary
SELECT 
    MIN(AvgSalary) AS LowestAverageSalary
FROM (
    SELECT 
        DepartmentID, 
        AVG(Salary) AS AvgSalary
    FROM 
        Employees
    GROUP BY 
        DepartmentID
) DepartmentAverages;

-- 12. Highest Peaks in Bulgaria
SELECT 
    MountainsCountries.CountryCode,
    Mountains.MountainRange,
    Peaks.PeakName,
    Peaks.Elevation
FROM Mountains
INNER JOIN Peaks
    ON Mountains.Id = Peaks.MountainId
INNER JOIN MountainsCountries
    ON Mountains.Id = MountainsCountries.MountainID
WHERE MountainsCountries.CountryCode = 'BG' 
    AND Peaks.Elevation > 2835
ORDER BY Peaks.Elevation DESC;

SELECT * FROM Mountains

-- 13. Count Mountains Range
SELECT 
MountainsCountries.CountryCode,
COUNT(MountainsCountries.CountryCode)
FROM MountainsCountries
INNER JOIN MountainsCountries.CountryCode ON Mountains.Id = MountainsCountries.MountainId
WHERE MountainsCountries.CountryCode = 'BG' 
OR MountainsCountries.CountryCode = 'RU'
OR MountainsCountries.CountryCode = 'US'
GROUP BY MountainsCountries.CountryCode

-- 14. Countries with Rivers
SELECT TOP(5)
Countries.CountryName,
Rivers.RiverName
FROM CountriesRivers
FULL JOIN Countries ON
Countries.CountryCode = CountriesRivers.CountryCode
FULL JOIN Rivers ON
Rivers.Id = CountriesRivers.RiverId
WHERE Countries.ContinentCode = 'AF'
ORDER BY Countries.CountryName ASC

-- 15. *Continents and Currencies
WITH CurrencyUsageCounts AS (
    SELECT 
        Countries.ContinentCode,
        Countries.CurrencyCode,
        COUNT(Countries.CountryCode) AS CountryCount
    FROM Countries
    GROUP BY Countries.ContinentCode, Countries.CurrencyCode
),
FilteredCurrencies AS (
    SELECT 
        ContinentCode,
        CurrencyCode,
        CountryCount
    FROM CurrencyUsageCounts
    WHERE CountryCount > 1
),
MostUsedCurrencies AS (
    SELECT 
        ContinentCode,
        CurrencyCode,
        MAX(CountryCount) AS MaxUsage
    FROM FilteredCurrencies
    GROUP BY ContinentCode, CurrencyCode
)
SELECT 
    ContinentCode,
    CurrencyCode,
    MaxUsage AS CurrencyUsage
FROM MostUsedCurrencies
ORDER BY ContinentCode;

-- 16. Countries without any mountains
SELECT 
COUNT(Countries.CountryCode) AS [Count]
FROM Countries
LEFT JOIN MountainsCountries 
ON Countries.CountryCode = MountainsCountries.CountryCode
WHERE Mountains.Id IS NULL	

-- 17. Highest Peak and Longest River by Country
SELECT TOP(5) 
Countries.CountryName, 
MAX(Peaks.Elevation) AS [HighestPeakElevation], 
MAX(Rivers.Length) AS [LongestRiverLength]
FROM Countries
LEFT OUTER JOIN MountainsCountries
ON Countries.CountryCode = MountainsCountries.CountryCode
LEFT OUTER JOIN Peaks 
ON Peaks.MountainId = MountainsCountries.MountainId
LEFT OUTER JOIN CountriesRivers 
ON CountriesRivers.CountryCode = CountriesRivers.CountryCode
LEFT OUTER JOIN Rivers 
ON CountriesRivers.RiverId = Rivers.Id
GROUP BY Countries.CountryName
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, Countries.CountryName

-- 18. Highest Peak Name and Elevation by Country
SELECT TOP (5) 
WITH TIES Countries.CountryName, 
ISNULL(Peaks.PeakName, '(no highest peak)') AS 'HighestPeakName', 
ISNULL(MAX(Peaks.Elevation), 0) AS 'HighestPeakElevation', 
ISNULL(Mountains.MountainRange, '(no mountain)')
FROM Countries
LEFT JOIN MountainsCountries ON Countries.CountryCode = MountainsCountries.CountryCode
LEFT JOIN Mountains ON MountainsCountries.MountainId = Mountains.Id
LEFT JOIN Peaks ON Mountains.Id = Peaks.MountainId
GROUP BY Countries.CountryName, Peaks.PeakName, Mountains.MountainRange
ORDER BY Countries.CountryName, Peaks.PeakName