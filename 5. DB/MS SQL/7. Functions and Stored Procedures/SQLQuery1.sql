-- 1. Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
  SELECT FirstName, LastName
  FROM Employees
  WHERE Salary > 35000;
END
GO

-- 2. Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@Number DECIMAL(18,4))
AS
BEGIN
   SELECT FirstName, LastName
   FROM Employees
   WHERE Salary >= @Number
END
GO

EXEC usp_GetEmployeesSalaryAboveNumber @Number = 481000

-- 3. Town Names Starting With
CREATE PROC usp_GetTownsStartingWith (@Text VARCHAR(10))
AS
BEGIN
   SELECT [Name]
   FROM Towns
   WHERE [Name] LIKE @Text + '%'
END
GO

-- 4. Employees from Town
CREATE PROC usp_GetEmployeesFromTown (@townName VARCHAR(20))
AS
BEGIN
   SELECT e.FirstName AS [First Name],
          e.LastName AS [Last NAME]
   FROM Employees AS e
        JOIN Addresses AS a ON e.AddressID = a.AddressID
		JOIN Towns AS t ON a.TownID = t.TownID
   WHERE t.[Name] = @townName
END
GO





--5. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@Salary MONEY) 
RETURNS NVARCHAR(20)
AS
BEGIN
    DECLARE @Level VARCHAR(20)

    IF (@Salary < 30000)
        SET @Level = 'Low'
    ELSE IF (@Salary <= 50000)
        SET @Level = 'Average'
    ELSE IF (@Salary > 50000)
        SET @Level = 'High'

    RETURN @Level
END

-- 6. Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel VARCHAR(20))
AS
BEGIN
   SELECT e.FirstName, e.LastName
   FROM Employees e
   WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLevel
END
GO

-- 7. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVCHAR(30), @word NVCHAR(30)) 
RETURNS BIT
AS
BEGIN
  DECLARE @isTrue BIT = 1
  DECLARE @i INT = 1

  WHILE @i <= LEN(@word)
  BEGIN
     IF CHARINDEX(SUBSTRING(@word, @i, 1), @setOfLetters) = 0
        BEGIN
            SET @isTrue = 0 
            BREAK            
        END

		SET @i = @i + 1
	END

	RETURN @isTrue
END

-- 8. Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN 
  DELETE FROM Employees
  WHERE DepartmentID = @departmentId

  UPDATE Departments
  SET ManagerID = NULL
  WHERE DepartmentID = @departmentId

  DELETE FROM Departments
  WHERE DepartmentID = @departmentId;

  SELECT COUNT(*) AS RemainingEmployees
  FROM Employees
  WHERE DepartmentID = @departmentId
END

-- 9. Find Full Name
CREATE PROC usp_GetHoldersFullName 
AS 
BEGIN
  SELECT FirstName + ' ' + LastName
  AS [Full Name]
  FROM AccountHolders
END

-- 10. People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(19, 4))
AS
BEGIN
  SELECT FirstName, LastName
  FROM AccountHolders as e
  JOIN Accounts AS a ON e.ID = a.AccountHolderID
  GROUP BY e.FirstName, e.LastName
  HAVING SUM(a.Balance) > @number
  ORDER BY FirstName, LastName
END

-- 11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(19, 4), 
@yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(19,4)
AS
BEGIN
DECLARE @futureValue DECIMAL(19, 4) = @sum * (POWER((1 + @yearlyInterestRate), @numberOfYears))  
RETURN @futureValue
END

-- 12. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount(@AccountId INT, @InterestRate FLOAT)
AS
BEGIN
  SELECT 
  e.ID AS [Account Id],
  e.FirstName AS [First Name],
  e.LastName AS [Last Name],
  a.Balance AS [Current Balance],
  dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years]
  FROM AccountHolders as e
  INNER JOIN Accounts AS a ON e.ID = a.AccountHolderId
  WHERE e.ID = @AccountId
END

-- 13. *Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(255))
RETURNS @ResultTable TABLE
(
   TotalCash DECIMAL(19, 4)
)
AS
BEGIN
  INSERT INTO @ResultTable
  SELECT SUM(Cash)
  FROM (
      SELECT
	       ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNum,
		   ug.Cash
	  FROM UsersGames AS ug
	  INNER JOIN Games AS g ON ug.GameId = g.Id
	  WHERE g.Name = @GameName
	) AS OrderedRows
	WHERE RowNum % 2 = 1
RETURN
END
