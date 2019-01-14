
-- Reset Tables

TRUNCATE TABLE RotationDetails;

TRUNCATE TABLE LocationSkills;

TRUNCATE TABLE EmployeeSkills;

TRUNCATE TABLE BoardDetails;
--DBCC CHECKIDENT ('BoardDetails', RESEED, 1);

DELETE FROM Boards;
DBCC CHECKIDENT ('Boards', RESEED, 1);

DELETE FROM Employees;
DBCC CHECKIDENT ('Employees', RESEED, 1);

DELETE FROM Locations;
DBCC CHECKIDENT ('Locations', RESEED, 1);

DELETE FROM Rotations;
DBCC CHECKIDENT ('Rotations', RESEED, 1);

DELETE FROM Shifts;
DBCC CHECKIDENT ('Shifts', RESEED, 1);

DELETE FROM Departments;
DBCC CHECKIDENT ('Departments', RESEED, 1);

DELETE FROM Skills;
DBCC CHECKIDENT ('Skills', RESEED, 1);


 -- Add Test Data

INSERT INTO Skills(Name)
VALUES('Cash');


INSERT INTO Departments(Name)
VALUES('Guest Service');


INSERT INTO Shifts(Name)
VALUES('AM');


INSERT INTO Rotations(Name)
VALUES('East Desk');


INSERT INTO Locations(Name, RotationId)
VALUES('East Desk', 1);


INSERT INTO Employees(FirstName, LastName, UserId, DepartmentId)
VALUES('John', 'Doe', '1234', 1);


INSERT INTO Boards(Id, BoardDate, DepartmentId, IsLock, LockBy)
VALUES(1, DATEFROMPARTS(2019, 1, 1), 1, 0, NULL);


INSERT INTO RotationDetails(RotationId, LocationId, DepartmentId)
VALUES(1, 1, 1);


INSERT INTO LocationSkills(LocationId, SkillId)
VALUES(1, 1);


INSERT INTO EmployeeSkills(EmployeeId, SkillId)
VALUES(1, 1);


INSERT INTO BoardDetails(Id, BoardId, LocationId, EmployeeId, ShiftId)
VALUES(1, 1, 1, 1, 1);