
-- 1. One-To-One Relationship
CREATE TABLE Passports
(
PassportId INT PRIMARY KEY IDENTITY(101,1),
PassportNumber VARCHAR(10)
)

INSERT INTO Passports  (PassportNumber)
       VALUES
	   ('N34FG21B'),
	   ('K65LO4R7'),
	   ('ZE657QP2')

CREATE TABLE Persons 
(
PersonID INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
Salary DECIMAL(10,2),
PassportID INT FOREIGN KEY REFERENCES Passports(PassportId)
)

INSERT INTO Persons (FirstName, Salary, PassportID)
       VALUES
	   ('Roberto', 43300.00, 102),
	   ('Tom', 56100.00, 103),
	   ('Yana', 60200.00, 101)

-- 2. One-To-Many Relationship
CREATE TABLE Manufacturers
(
ManufacturerID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
EstablishedOn DATE
)

INSERT INTO Manufacturers ([Name], EstablishedOn)
VALUES
     ('BMW', '07/03/1916'),
	 ('Tesla', '01/01/2003'),
	 ('Lada', '01/05/1966')

CREATE TABLE Models 
(
ModelID INT PRIMARY KEY IDENTITY(101, 1),
[Name] VARCHAR(50) NOT NULL,
ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models ([Name], ManufacturerID)
VALUES
     ('X1', 1),
	 ('i6', 1),
	 ('Model S', 2),
	 ('Model X', 2),
	 ('Model 3', 2),
	 ('Nova', 3)

-- 3. Many-To-Many Relationship
CREATE TABLE Students
(
StudentID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

INSERT INTO Students ([Name])
VALUES
     ('Mila'),
	 ('Toni'),
	 ('Ron')

CREATE TABLE Exams
(
ExamID INT PRIMARY KEY IDENTITY (101, 1),
[Name] VARCHAR(50) NOT NULL
)

INSERT INTO Exams ([Name]) 
VALUES
     ('SpringMVC'),
	 ('Neo4j'),
	 ('Oracle 11g')

CREATE TABLE StudentsExams
(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
ExamID INT FOREIGN KEY REFERENCES Exams(ExamID)
)

INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
     (1, 101),
	 (1, 102),
	 (2, 101),
	 (3, 103),
	 (2, 102),
	 (2, 103)

-- 4. Self-Referencing 
CREATE TABLE Managers
(
ManagerID INT PRIMARY KEY IDENTITY(101, 1),
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Teachers
(
TeacherID INT PRIMARY KEY IDENTITY(101, 1),
[Name] VARCHAR(50) NOT NULL,
ManagerID INT FOREIGN KEY REFERENCES Managers(ManagerID)
)

INSERT INTO Teachers ([Name], ManagerID)
VALUES
     ('John', NULL),
	 ('Maya', 106),
	 ('Silvia', 106),
	 ('Ted', 105),
	 ('Mark', 101),
	 ('Greta', 101)

-- 5. Online Store Database
CREATE TABLE ItemTypes 
(
ItemTypeID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50)
)

CREATE TABLE Items
(
ItemID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50),
ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Cities
(
CityID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50)
)

CREATE TABLE Customers
(
CustomerID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50),
Birthday DATE,
CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
OrderID INT PRIMARY KEY IDENTITY NOT NULL,
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems
(
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
ItemID INT FOREIGN KEY REFERENCES Items(ItemID)
CONSTRAINT PK_OrdersItemId PRIMARY KEY (OrderID, ItemId)
)

-- 6. University Database
CREATE TABLE Subjects
(
SubjectID INT PRIMARY KEY IDENTITY NOT NULL,
SubjectName VARCHAR(50)
)

CREATE TABLE Majors
(
MajorID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50)
)

CREATE TABLE Students
(
StudentID INT PRIMARY KEY IDENTITY NOT NULL,
StudentNumber INT,
StudentName VARCHAR(50),
MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda
(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
CONSTRAINT PK_StudentsSubjectsId PRIMARY KEY (StudentID, SubjectID)
)

CREATE TABLE Payments
(
PaymentID INT PRIMARY KEY IDENTITY NOT NULL,
PaymentDate DATE,
PaymentAmount DECIMAL(10, 2),
StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)


--  9. *Peaks in Rila
SELECT Mountains.MountainRange, Peaks.PeakName, Peaks.Elevation
FROM Mountains
JOIN Peaks ON Peaks.MountainId = Mountains.Id
WHERE Mountains.MountainRange = 'Rila'
ORDER BY Peaks.Elevation DESC




