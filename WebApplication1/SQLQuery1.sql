--CREATE DATABASE AzMB101_Jafar_Testing1

USE AzMB101_Jafar_Testing1

--DROP TABLE Workers
--DROP TABLE Office
--DROP TABLE Positions

CREATE TABLE Positions(
	ID INT IDENTITY PRIMARY KEY,
	Describtion NVARCHAR(31),
)

CREATE TABLE Office(
	ID INT IDENTITY PRIMARY KEY,
	Title NVARCHAR(31),
)

CREATE TABLE Workers(
	ID INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(31),
	Age INT,
	[Start_Date] Date DEFAULT CURRENT_TIMESTAMP,
	Salary Money,
	Position_ID INT FOREIGN KEY REFERENCES Positions(ID),
	Office_ID INT FOREIGN KEY REFERENCES Office(ID),
)

INSERT INTO Office VALUES
('f1'),('f2'),('f3')

INSERT INTO Positions VALUES
('p1'),('p2'),('p3')

INSERT INTO Workers VALUES
('w1',11,DEFAULT,111,1,1),('w2',11,DEFAULT,111,2,1),('w3',11,DEFAULT,111,2,2)

ALTER VIEW WorkerSheet AS
SELECT w.Name, p.Describtion as Position, o.Title as Office, w.Age, w.Start_Date AS 'Start Date', w.Salary FROM Workers as w
JOIN Office as o ON w.Office_ID = o.ID
JOIN Positions as p ON w.Position_ID = p.ID

SELECT * FROM WorkerSheet