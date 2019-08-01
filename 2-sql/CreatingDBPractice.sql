CREATe SCHEMA Job;
GO

CREATE TABLE Job.Department(
	DeptId Int NOT NULL Identity(1,1) Primary Key,
	Name Nvarchar(20) Not NUll,
	Location Nvarchar(20) Not Null
);

CREATE TABLE Job.Employee(
	EmpId Int NOT NULL Identity(1,1) Primary Key,
	FirstName Nvarchar(20) Not NUll,
	LastName Nvarchar(20) Not NUll,
	SSN Int Not NUll unique,
	DeptId INT NOT NULL
);

CREATE TABLE Job.EmpDetails(
	EDId Int NOT NULL Identity(1,1) Primary Key,
	EmpId INT NOT NULL Unique,
	Salary Money Not NUll,
	Address1 Nvarchar(500) Not NUll,
	Address2 Nvarchar(500) NUll,
	City Nvarchar(100) Not NUll,
	State Nvarchar(100) Not NUll,
	Country Nvarchar(100) Not NUll,
);

Alter Table Job.Employee Add
	Constraint FK_Employee_Department_DeptId Foreign Key (DeptId)
		References Job.Department (DeptId)

Alter Table Job.EmpDetails Add
	Constraint FK_EmpDetails_Employee_EmpId Foreign Key (EDId)
		References Job.Employee (EmpId)


Insert Into Job.Department(Name, Location) Values
	('Flower Department', 'California');

Select * from Job.Department;
