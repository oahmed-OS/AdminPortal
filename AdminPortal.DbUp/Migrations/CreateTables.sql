 -- Dim Tables

Create Table Rotations (
	Id int PRIMARY KEY Identity(1,1),
	Name varchar(30) NOT NULL
);

Create Table Locations (
	Id int PRIMARY KEY Identity(1,1),
	Name varchar(30) NOT NULL,
	RotationId int FOREIGN KEY References Rotations(Id)
);

Create Table Skills (
	Id int PRIMARY KEY Identity(1,1),
	Name varchar(50) NOT NULL
);

Create Table Departments (
	Id int PRIMARY KEY Identity(1,1),
	Name varchar(30) NOT NULL
);

Create Table Shifts (
	Id int PRIMARY KEY Identity(1,1),
	Name varchar(15) NOT NULL
);

Create Table Employees (
	Id int PRIMARY KEY Identity(1,1),
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	UserId varchar(10),
	DepartmentId int FOREIGN KEY References Departments(Id)
);


-- Table Mappings

Create Table RotationDetails (
	RotationId int FOREIGN KEY References Rotations(Id),
	LocationId int FOREIGN KEY References Locations(Id),
	DepartmentId int FOREIGN KEY References Departments(Id),
	PRIMARY KEY (RotationId, LocationId, DepartmentId)
);

CREATE Table LocationSkills (
	LocationId int FOREIGN KEY References Locations(Id),
	SkillId int FOREIGN KEY References Skills(Id),
	PRIMARY KEY (LocationId, SkillId)
);

Create Table EmployeeSkills (
	EmployeeId int FOREIGN KEY References Employees(Id),
	SkillId int FOREIGN KEY References Skills(Id),
	PRIMARY KEY (EmployeeId, SkillId)
);

-- Boards Tables

Create Table Boards (
	Id int PRIMARY KEY,
	BoardDate datetime NOT NULL,
	DepartmentId int FOREIGN KEY References Departments(Id),
	IsLock bit,
	LockBy varchar(50)
);

Create Table BoardDetails (
	Id int PRIMARY KEY,
	BoardId int FOREIGN KEY References Boards(Id),
	LocationId int FOREIGN KEY References Locations(Id),
	EmployeeId int FOREIGN KEY References Employees(Id),
	ShiftId int FOREIGN KEY References Shifts(Id)
);