-------------------------------------Triggers------------------------------------

select * from Employee
CREATE TABLE [dbo].[EmployeeAudit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Country] [varchar](100) NULL
) ON [PRIMARY]
GO


create trigger trg_AfterInsertEmployee
on employee
After Insert
As
Begin
             Insert into EmployeeAudit(FirstName,LastName,Country)
			 select FirstName,LastName,Country
			 from inserted;
End;


select * from Employee
SELECT * from EmployeeAudit

insert into Employee values('John','scena','Africa')


create trigger trg_AfterDeleteEmployee
on employee
after delete
As
 Begin
     Insert into EmployeeAudit(FirstName,LastName,Country)
	 select FirstName,LastName,Country
	 from deleted;
 end


 delete from Employee where id = 2

 select * from Employee
 select * from EmployeeAudit



 ----------instead of triggers--------------


 CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DepartmentID INT
);
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName NVARCHAR(50)
);


CREATE VIEW EmployeeView AS
SELECT 
    E.EmployeeID,
    E.FirstName,
    E.LastName,
    D.DepartmentID
FROM 
    Employees E
JOIN 
    Departments D ON E.DepartmentID = D.DepartmentID;


	create trigger Trg_InsteadOfInsertEmployeeView
	on EmployeeView
	instead of insert
	as
	begin
	     insert into Employees (EmployeeID, FirstName, LastName, DepartmentID)
		 select EmployeeID, FirstName, LastName, DepartmentID
		 from inserted
	end


	insert into EmployeeView values (2,'Henna','Louise',2)


	select * from EmployeeView
	select * from Employees

	select * from EmployeeAudit


	CREATE TRIGGER trg_InsteadOfUpdateEmployeeView
ON EmployeeView
INSTEAD OF UPDATE
AS
BEGIN
    UPDATE E
    SET 
        E.FirstName = I.FirstName,
        E.LastName = I.LastName,
        E.DepartmentID = I.DepartmentID
    FROM Employees E
    INNER JOIN INSERTED I ON E.EmployeeID = I.EmployeeID;

END;

select * from Employees
select * from EmployeeView
update EmployeeView set firstname = 'John', lastname ='scena', departmentid =1
where EmployeeID = 1


CREATE TRIGGER trg_InsteadOfDeleteEmployeeView
ON EmployeeView
INSTEAD OF DELETE
AS
BEGIN
    -- Delete from Employees table
    DELETE FROM Employees
    WHERE EmployeeID IN (SELECT EmployeeID FROM DELETED);

    -- Optionally, handle related deletions in Departments table if necessary
END;


delete from EmployeeView where Employeeid = 1