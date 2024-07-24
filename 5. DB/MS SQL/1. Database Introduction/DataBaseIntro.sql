-- 2. Create Tables
CREATE TABLE Minions
(
    Id INT PRIMARY KEY,
    [Name] NVARCHAR(30),
    Age INT
);

CREATE TABLE Towns
(
    Id INT PRIMARY KEY,
    [Name] NVARCHAR(30)
);

-- 3. Alter Minions Table
ALTER TABLE Minions
ADD TownId INT;

ALTER TABLE Minions
ADD CONSTRAINT FK_Minions_Towns
FOREIGN KEY (TownId) REFERENCES Towns(Id);

-- 4. Insert Records In Both Tables
INSERT INTO Towns (Id, Name) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna');

INSERT INTO Minions (Id, Name, Age, TownId)
VALUES 
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2);

-- 5. Truncate Table Minions
DELETE FROM Minions

-- 6. Drop All Tables
DROP TABLE Minions
DROP TABLE Towns

-- 7. Create Table People
CREATE TABLE People
(
Id INT PRIMARY KEY IDENTITY,
[Name] NCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height DECIMAL (10, 2),
[Weight] DECIMAL (10, 2),
Gender CHAR(1) NOT NULL,
Birthdate DATETIME2 NOT NULL,
Biography NVARCHAR(MAX)
);

INSERT INTO People ([Name], Gender, Birthdate) VALUES
('Anton', 'm', '1999-07-28'),
('Petur', 'm', '1999-03-21'),
('Nikola', 'm', '1999-07-22'),
('Iliqn', 'm', '1999-07-21'),
('Georgi', 'm', '1999-06-29');

-- 8. Create Table Users
CREATE TABLE Users
(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATETIME2,
IsDeleted BIT
);

INSERT INTO Users (Username, [Password], IsDeleted) VALUES
('Anton', '1231', 0),
('Petur', '1231', 1),
('Nikola', '1231', 1),
('Iliqn', '1231', 0),
('Georgi', '1231', 1);

-- 9. Change Primary Key
ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username);

-- 10. Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordLength CHECK (LEN([Password]) >= 5);

-- 11. Set Default Value Of A Field
ALTER TABLE Users
ADD CONSTRAINT DF_Users DEFAULT GETDATE() FOR LastLoginTime;

-- 12. Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id);

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameLength CHECK (LEN(Username) >= 3);

-- 13. Movies Database
CREATE DATABASE Movies -- това не се пуска в JUDGE!
CREATE TABLE Directors 
(
    Id INT PRIMARY KEY IDENTITY,
    DirectorName NVARCHAR(30) NOT NULL,
    Notes VARCHAR(MAX)
);

CREATE TABLE Genres 
(
    Id INT PRIMARY KEY IDENTITY,
    GenreName NVARCHAR(30) NOT NULL,
    Notes VARCHAR(MAX)
);

CREATE TABLE Categories 
(
    Id INT PRIMARY KEY IDENTITY,
    CategoryName NVARCHAR(30) NOT NULL,
    Notes VARCHAR(MAX)
);

CREATE TABLE Movies 
(
    Id INT PRIMARY KEY IDENTITY,
    Title VARCHAR(50) NOT NULL,
    DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
    CopyrightYear INT NOT NULL,
    [Length] TIME(0) NOT NULL,
    GenreId INT FOREIGN KEY REFERENCES Genres(Id),
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
    Rating DECIMAL(2,1) NOT NULL,
    Notes VARCHAR(MAX)
);

INSERT INTO Directors (DirectorName) VALUES
('Kiro'),
('Svetlio'),
('Dimitur'),
('Antoan'),
('Kalin');

INSERT INTO Genres (GenreName) VALUES
('Horror'),
('Adventure'),
('Funny'),
('Drama'),
('Romance');

INSERT INTO Categories (CategoryName) VALUES
('Fantasy'),
('Thriller'),
('Western'),
('Comedy'),
('Bulgarian');

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating) VALUES 
('SpiderMan', 1, 2000, '01:37:21', 1, 1, 9.9),
('Rocky', 2, 2000, '01:37:21', 2, 2, 9.9),
('SuperMan', 3, 2000, '01:37:21', 3, 3, 9.9),
('Minions', 4, 2000, '01:37:21', 4, 4, 9.9),
('SuperBad', 5, 2000, '01:37:21', 5, 5, 9.9);

-- 14. Car Rental Database
CREATE DATABASE CarRental 
USE CarRental

CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY,
CategoryName VARCHAR(50) NOT NULL,
DailyRate DECIMAL(10,2) NOT NULL,
WeeklyRate DECIMAL(10,2) NOT NULL,
MonthlyRate DECIMAL(10,2) NOT NULL,
WeekendRate DECIMAL(10,2) NOT NULL
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
    ('Economy', 30.00, 180.00, 600.00, 50.00),
    ('Compact', 40.00, 240.00, 800.00, 60.00),
    ('SUV', 50.00, 300.00, 1000.00, 70.00);

CREATE TABLE Cars
(
Id INT PRIMARY KEY IDENTITY,
PlateNumber VARCHAR(20) NOT NULL,
Manufacter VARCHAR(50) NOT NULL,
Model VARCHAR(50) NOT NULL,
CarYear INT NOT NULL,
CategoryId INT FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
Doors INT NOT NULL,
Picture VARBINARY(MAX),
Condition VARCHAR(50),
Available BIT NOT NULL
);

INSERT INTO Cars (PlateNumber, Manufacter, Model, CarYear, CategoryId, Doors, Available) 
VALUES 
    ('PA2314', 'Ford', 'Mustang', 2022, 1, 2, 1),
    ('PB2314', 'Toyota', 'Avensis', 2017, 2, 4, 1),
    ('CB2314', 'Opel', 'Corsa', 2018, 3, 4, 1);


CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Title VARCHAR(50) NOT NULL,
Notes VARCHAR(MAX)
);

INSERT INTO Employees (FirstName, LastName, Title) 
VALUES
    ('Anton', 'Kenderov', 'Manufacter'),
	('Iliqn', 'Lupov', 'Manager'),
	('Dimitar', 'Grigorov', 'Manfucater')

CREATE TABLE Customers
(
Id INT PRIMARY KEY IDENTITY,
DriverLicenseNumber VARCHAR(20) NOT NULL,
FullName VARCHAR(50) NOT NULL,
[Address] VARCHAR(50) NOT NULL,
City VARCHAR(30) NOT NULL,
ZIPCode VARCHAR(10) NOT NULL,
Notes VARCHAR(MAX)
);

INSERT INTO Customers (DriverLicenseNumber, FullName, [Address], City, ZIPCode)
VALUES
    ('PA9444', 'Kaloyan Kotinov', 'Purvenec', 'Lozen', '3421'),
	('PA9434', 'Dimitur Kotinov', 'Purvenec', 'Sofia', '7521'),
	('PA9424', 'Petur Kotinov', 'Purvenec', 'Burgas', '5312');

CREATE TABLE RentalOrders 
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
CustomerId INT FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
CarId INT FOREIGN KEY (CarId) REFERENCES Cars(Id),
TankLevel DECIMAL (5,2),
KilometrageStart INT,
KilometrageEnd INT,
TotalKilometrage INT,
StartDate DATETIME2,
EndDate DATETIME2,
TotalDays INT,
RateApllied DECIMAL(10,2),
TaxRate DECIMAL(5,2),
OrderStatus VARCHAR(20),
Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel)
VALUES
    (1, 2, 1, 3.00),
	(2, 1, 2, 4.00),
	(3, 3, 3, 5.00);


-- 15. Hotel Database
CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Title VARCHAR(50) NOT NULL,
Notes VARCHAR(MAX)
);

INSERT INTO Employees (FirstName, LastName, Title) 
VALUES
    ('Dimitur', 'Kopernikov', 'Receptionist'),
	('Ivo', 'Bojanov', 'Life Guard'),
	('Boyko', 'Boqnov', 'Cleaner');

CREATE TABLE Customers
(
AccountNumber INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(10),
EmergencyName VARCHAR(100),
EmergencyNumber VARCHAR(20),
Notes VARCHAR(MAX)
);

INSERT INTO Customers (FirstName, LastName, PhoneNumber) 
VALUES 
    ('Stoqn', 'Tzokov', '0887387664'),
	('Georgi', 'Shopov', '0879538787'),
	('Petko', 'Georgiev', '0894218454');

CREATE TABLE RoomStatus
(
RoomStatus VARCHAR(20) PRIMARY KEY,
Notes VARCHAR(MAX)
);

INSERT INTO RoomStatus (RoomStatus)
VALUES 
    ('Available'),
	('Under maintance'),
	('UnAvailable');

CREATE TABLE RoomTypes
(
RoomType VARCHAR(20) PRIMARY KEY,
Notes VARCHAR(MAX)
);

INSERT INTO RoomTypes (RoomType)
VALUES
    ('Flat'),
	('Studio'),
	('One bedroom');

CREATE TABLE BedTypes
(
BedType VARCHAR(20) PRIMARY KEY,
Notes VARCHAR(MAX)
);

INSERT INTO BedTypes (BedType)
VALUES
    ('big bed'),
	('small bed'),
	('no bed ha ha')

CREATE TABLE Rooms 
(
RoomNumber INT PRIMARY KEY IDENTITY,
RoomType VARCHAR(20) FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
BedType VARCHAR(20) FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
Rate DECIMAL(10,2),
RoomStatus VARCHAR(20) FOREIGN KEY (RoomStatus) REFERENCES RoomStatus(RoomStatus),
Notes VARCHAR(MAX)
);

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus)
VALUES
    ('Flat', 'big bed', 6.00, 'Available'),
    ('One bedroom', 'small bed', 5.00, 'UnAvailable'),
    ('Studio', 'no bed ha ha', 4.00, 'Under maintance');

CREATE TABLE Payments
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
PaymentDate DATETIME,
AccountNumber INT FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber),
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays INT,
AmountCharged DECIMAL(10, 2),
TaxRate DECIMAL(5, 2),
TaxAmount DECIMAL(10, 2),
PaymentTotal DECIMAL(10, 2),
Notes VARCHAR(MAX)
);

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES
    (2, '2023-09-01', 2, '2023-11-01', '2023-11-05', 6, 500.00, 10.00, 50.00, 550.00),
    (1, '2023-09-02', 1, '2023-11-02', '2023-11-06', 7, 1000.00, 12.00, 72.00, 672.00),
    (3, '2023-09-03', 3, '2023-11-03', '2023-11-07', 4, 750.00, 15.00, 150.00, 1150.00);

CREATE TABLE Occupancies
(
    Id INT PRIMARY KEY IDENTITY,
    EmployeeId INT,
    DateOccupied DATETIME,
    AccountNumber INT,
    RoomNumber INT,
    RateApplied DECIMAL(10, 2),
    PhoneCharge DECIMAL(10, 2),
    Notes VARCHAR(MAX),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber),
    FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber)
);

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES
    (1, '2024-02-01', 1, 1, 50.00, 5.00),
    (2, '2024-02-02', 2, 2, 100.00, 10.00),
    (3, '2024-02-03', 3, 3, 150.00, 15.00);

-- 16. Create SoftUni Database
CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(20) NOT NULL
);

CREATE TABLE Addresses
(
Id INT PRIMARY KEY IDENTITY,
AddressText VARCHAR(50) NOT NULL,
TownId INT FOREIGN KEY (TownId) REFERENCES Towns(Id)
);

CREATE TABLE Departments 
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(20) NOT NULL
);

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(20) NOT NULL,
MiddleName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
JobTitle VARCHAR(40) NOT NULL,
DepartmentId INT FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
HireDate DATE,
Salary DECIMAL(10,2),
AddressId INT FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

-- 17. Backup Database
BACKUP DATABASE SoftUni TO DISK = 'C:\Program Files\Microsoft SQL Server\Backupsoftuni-backup.bak' WITH INIT;
DROP DATABASE SoftUni
RESTORE DATABASE SoftUni FROM DISK = 'C:\Program Files\Microsoft SQL Server\Backupsoftuni-backup.bak' WITH REPLACE;

-- 18. Basic Insert
INSERT INTO Towns([Name]) 
VALUES
    ('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas');

INSERT INTO Departments ([Name])
VALUES 
    ('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance');
SELECT * FROM Departments

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
    ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
    ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
    ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
    ('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
    ('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88);

-- 19. Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

-- 20. Basic Select All Fields and Order Them
SELECT * FROM Towns ORDER BY [Name] ASC
SELECT * FROM Departments ORDER BY [Name] ASC
SELECT * FROM Employees ORDER BY Salary DESC	

-- 21. Basic Select Some Fields
SELECT [Name] FROM Towns ORDER BY [Name] ASC
SELECT [Name] FROM Departments ORDER BY [Name] ASC
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

-- 22. Increase Employees Salary
UPDATE Employees SET Salary = Salary * 1.1
SELECT Salary FROM Employees

-- 23.Decrease Tax Rate
USE Hotel
UPDATE Payments SET TaxRate = TaxRate * 0.97
SELECT TaxRate FROM Payments

-- 24. Delete All Records
DELETE FROM Occupancies