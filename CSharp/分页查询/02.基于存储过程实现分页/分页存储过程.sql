
use DataPagerDB
go
if exists(select * from sysobjects where name='usp_DataPager')
drop procedure usp_DataPager
go
create procedure usp_DataPager  
 @PageSize int,--每页显示多少条
 @FilterCount int, --过滤的条数 
 @Birthday varchar(20) --查询条件参数
as 
	Select Top  (@PageSize) StudentId,StudentName,Gender,Birthday,PhoneNumber from Students 
	where  Birthday>@Birthday and StudentId not in
	 (Select Top  (@FilterCount) StudentId from Students where  Birthday>@Birthday order by StudentId ASC)
	order by StudentId ASC
	--查询满足记录条数 
	select  count(*) from Students where  Birthday>@Birthday 
go

