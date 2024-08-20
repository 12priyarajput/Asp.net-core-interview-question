create table EmployeeTT(empID int identity(1,1),
managerid int,
salary int
)

-- find sum of salary basis on managers's  (2nd highest)
with getHighestSalary(
managerid, totalSalary
)
As(
select managerid,sum(salary) totatlSalary
from Employeett
group by managerid
)

select top 1 * from  (
select top 2 *  from getHighestSalary
order by totalSalary  ) t
order by totalSalary

select * from ExamResult


-- Complax View-
create view testvv as
select e.FirstName,et.Country from Employee e join
EmployeeTest et on e.ID = et.ID


select * from testvv

insert into testvv values('Sneha','India')
update testvv set FirstName = 'Priya' where Country = 'India'

--Simple View--
create view testV as
select * from ExamResult


select * from testV

update testV set Marks = 36 where studentName = 'Lily'
and Subject = 'Maths'

--------------------------------------------------------------------------------
--------------Indexes---------------------------------------


CREATE TABLE Books
(
id INT PRIMARY KEY NOT NULL,
name VARCHAR(50) NOT NULL,
category VARCHAR(50) NOT NULL,
price INT NOT NULL
)

INSERT INTO Books
    
VALUES
(6, 'Book6', 'Cat6', 5000),
(7, 'Book7', 'Cat7', 8000),
(1, 'Book1', 'Cat1', 1800),
(2, 'Book2', 'Cat2', 1500),
(10, 'Book10', 'Cat10', 3200),
(3, 'Book3', 'Cat3', 2000),
(9, 'Book9', 'Cat9', 5400),
(4, 'Book4', 'Cat4', 1300),
(5, 'Book5', 'Cat5', 1500),
(8, 'Book8', 'Cat8', 5000)

select * from books
EXECUTE sp_helpindex Books --will return index info a system defined function


ALTER TABLE Books
DROP CONSTRAINT PK__Books__3213E83F5AE9527F


create clustered index IX_tblbook_Price
On books(price asc)


select * from Books -- see the output


create clustered index X_books_ID -- It will give you an error
on books(Id desc)
-----------------------------
--------------Non Clustered index--------------------------


create nonclustered index IX_books_Name
on books(name asc,id desc)


select * from books
--Arrange data in an order and return all except first record

with cte(
 Subject,StudentName,Marks, ROW
)
As(
select Subject,StudentName,Marks, ROW_NUMBER() over(order by marks ) as ROW
from ExamResult
)
select * from cte
where ROW > 1


-- give ranks to the students as per their marks and marks can be duplicate

select *, row_number() over (partition by studentName
order by marks desc) as Ranks from ExamResult
order by ranks
