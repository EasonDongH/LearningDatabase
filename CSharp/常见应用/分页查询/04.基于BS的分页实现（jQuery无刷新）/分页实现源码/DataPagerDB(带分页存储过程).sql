
--指向当前要使用的数据库
use master
go
--判断当前数据库是否存在
if exists (select * from sysdatabases where name='DataPagerDB')
drop database DataPagerDB--删除数据库
go
--创建数据库
create database DataPagerDB
on primary
(
	--数据库文件的逻辑名
    name='DataPagerDB_data',
    --数据库物理文件名（绝对路径）
    filename='D:\DB\DataPagerDB_data.mdf',
    --数据库文件初始大小
    size=10MB,
    --数据文件增长量
    filegrowth=1MB
)
--创建日志文件
log on
(
    name='DataPagerDB_log',
    filename='D:\DB\DataPagerDB_log.ldf',
    size=2MB,
    filegrowth=1MB
)
go
--创建学员信息数据表
use DataPagerDB
go
if exists (select * from sysobjects where name='Students')
drop table Students
go
create table Students
(
    StudentId int identity(100000,1) primary key,
    StudentName varchar(20) not null,
    Gender char(2)  not null,
    Birthday smalldatetime  not null,   
    PhoneNumber varchar(50)
)
go

--创建分页的存储过程
use DataPagerDB 
go
if exists(select * from sysobjects where name='usp_DataPager')
drop procedure usp_DataPager
go
create procedure usp_DataPager   
 @PageSize int,
 @Birthday datetime,
 @filterCount int
as 
	SELECT TOP (@PageSize)  StudentId,StudentName,Gender,Birthday,PhoneNumber
	FROM Students 
	WHERE Birthday>@Birthday and StudentId not in 
	(SELECT TOP (@filterCount) StudentId FROM Students WHERE Birthday>@Birthday ORDER BY StudentId ASC)	
	ORDER BY StudentId ASC
	SELECT recordsCount= COUNT(*) FROM Students WHERE  Birthday>@Birthday
go






--插入学员信息
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('王小虎','男','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('贺小张','女','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('马小李','男','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('冯小强','女','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('杜小丽','女','1986-05-08','022-66666666')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('王小虎1','男','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('贺小张1','女','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('马小李1','男','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('冯小强1','女','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('杜小丽1','女','1986-05-08','022-66666666')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('王小虎2','男','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('贺小张2','女','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('马小李2','男','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('冯小强2','女','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('杜小丽2','女','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('王小虎3','男','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('贺小张3','女','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('马小李3','男','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('冯小强3','女','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('杜小丽3','女','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('王小虎4','男','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('贺小张4','女','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('马小李4','男','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('冯小强4','女','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('杜小丽4','女','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('王小虎5','男','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('贺小张5','女','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('马小李5','男','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('冯小强5','女','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('杜小丽5','女','1986-05-08','022-66666666') 
 insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('王小虎6','男','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('贺小张6','女','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('马小李6','男','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('冯小强6','女','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('杜小丽6','女','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('王小虎7','男','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('贺小张7','女','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('马小李7','男','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('冯小强7','女','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('杜小丽7','女','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('王小虎8','男','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('贺小张8','女','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('马小李8','男','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('冯小强8','女','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('杜小丽8','女','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('王小虎9','男','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('贺小张9','女','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('马小李9','男','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('冯小强9','女','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('杜小丽9','女','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('王小虎10','男','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('贺小张10','女','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('马小李10','男','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('冯小强10','女','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('杜小丽10','女','1986-05-08','022-66666666') 
  
--显示学员信息和班级信息
select * from Students





