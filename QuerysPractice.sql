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
