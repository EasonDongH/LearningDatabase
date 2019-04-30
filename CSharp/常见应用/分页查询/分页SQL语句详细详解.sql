
use DataPagerDB
go
--查询第一页
select  Top 5 StudentId,StudentName,Gender,Birthday,PhoneNumber from Students
where Birthday>'1989/10/12' 
--查询第二页
select  Top 5 StudentId,StudentName,Gender,Birthday,PhoneNumber from Students
where Birthday>'1989/10/12'  and StudentId not in
(select Top 5 StudentId from Students where Birthday>'1989/10/12' order by StudentId ASC )
order by StudentId ASC
--查询第三页    总结过滤条数=每页显示的条数*（显示的第几页-1）
select  Top 5 StudentId,StudentName,Gender,Birthday,PhoneNumber from Students
where Birthday>'1989/10/12'  and StudentId not in
(select Top 10 StudentId from Students where Birthday>'1989/10/12' order by StudentId ASC )
order by StudentId ASC
--查询符合条件的记录总数
select COUNT(*) from Students where Birthday>'1989/10/12' 

--计算符合条件的总页数（比如总计5条，每页分别显示：3、5、8，计算实际分页数）
print '----相除----'
print 5/3     --2页
print 5/5     --1页
print 5/8     --1页

print '---实际分页数---'
print 5/3+1     --2页
print 5/5         --1页
print 5/8+1     --1页

--对于除不尽的情况，通过取模来判断（有余数的都加1，就是实际页数）
print '---取模---'
print 5%3    
print 5%5        
print 5%8    
--==============分页实现的基本思路=================
--每页显示的条数
--过滤掉的总数=每页显示的条数*（当前显示的页数-1）
--查询条件的确定
--排序条件

--获取满足条件的记录总数
--知道查询结果需要显示的页数=记录总数/每页显示条数 + 1（如果记录总数和每页显示条数取模后不为0，则加1）