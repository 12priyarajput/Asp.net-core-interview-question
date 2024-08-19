

select *,
ROW_NUMBER() over (partition by subject order by marks desc) as Rank
from ExamResult
order by StudentName,Rank;


select *,
RANK() over (partition by subject order by marks desc) as Rank
from ExamResult
order by StudentName,Rank;


select *,
DENSE_RANK() over (partition by subject order by marks desc) as Rank
from ExamResult
order by StudentName,Rank



select *,
row_number() over (order by marks desc) as rowNumber,
rank() over (order by marks desc) as Rank,
DENSE_RANK() over (order by marks desc) as denseRank
from ExamResult;



-- divides data into groups 

select *, NTILE(2) over (order by marks)
from ExamResult


select * ,NTILE(3) over (order by marks desc) as rank
from ExamResult
order by rank;


select *, NTILE(2) over( partition by subject order by marks desc) as rank
from ExamResult
order by Subject, rank



--ROW_Number

--It assigns the sequential rank number to each unique record.

--RANK

--It assigns the rank number to each row in a partition. It skips the number for similar values.

--Dense_RANK

--It assigns the rank number to each row in a partition. It does not skip the number for similar values.

--NTILE(N)

--It divides the number of rows as per specified partition and assigns unique value in the partition.










