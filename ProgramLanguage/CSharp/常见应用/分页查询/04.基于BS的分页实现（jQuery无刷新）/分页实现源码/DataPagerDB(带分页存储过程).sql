
--ָ��ǰҪʹ�õ����ݿ�
use master
go
--�жϵ�ǰ���ݿ��Ƿ����
if exists (select * from sysdatabases where name='DataPagerDB')
drop database DataPagerDB--ɾ�����ݿ�
go
--�������ݿ�
create database DataPagerDB
on primary
(
	--���ݿ��ļ����߼���
    name='DataPagerDB_data',
    --���ݿ������ļ���������·����
    filename='D:\DB\DataPagerDB_data.mdf',
    --���ݿ��ļ���ʼ��С
    size=10MB,
    --�����ļ�������
    filegrowth=1MB
)
--������־�ļ�
log on
(
    name='DataPagerDB_log',
    filename='D:\DB\DataPagerDB_log.ldf',
    size=2MB,
    filegrowth=1MB
)
go
--����ѧԱ��Ϣ���ݱ�
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

--������ҳ�Ĵ洢����
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






--����ѧԱ��Ϣ
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��','��','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��','Ů','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��','��','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��Сǿ','Ů','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��','Ů','1986-05-08','022-66666666')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��1','��','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��1','Ů','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��1','��','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��Сǿ1','Ů','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��1','Ů','1986-05-08','022-66666666')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��2','��','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��2','Ů','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��2','��','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��Сǿ2','Ů','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��2','Ů','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��3','��','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��3','Ů','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��3','��','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��Сǿ3','Ů','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��3','Ů','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��4','��','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��4','Ů','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��4','��','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��Сǿ4','Ů','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��4','Ů','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��5','��','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��5','Ů','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��5','��','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��Сǿ5','Ů','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��5','Ů','1986-05-08','022-66666666') 
 insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��6','��','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��6','Ů','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��6','��','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��Сǿ6','Ů','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��6','Ů','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��7','��','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��7','Ů','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��7','��','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��Сǿ7','Ů','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��7','Ů','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��8','��','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��8','Ů','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��8','��','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��Сǿ8','Ů','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��8','Ů','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��9','��','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��9','Ů','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��9','��','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��Сǿ9','Ů','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��9','Ů','1986-05-08','022-66666666') 
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��10','��','1989-08-07','022-22222222')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��10','Ů','1989-05-06','022-33333333')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��10','��','1990-02-07','022-44444444')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��Сǿ10','Ů','1987-05-12','022-55555555')
insert into Students (StudentName,Gender,Birthday,PhoneNumber)
         values('��С��10','Ů','1986-05-08','022-66666666') 
  
--��ʾѧԱ��Ϣ�Ͱ༶��Ϣ
select * from Students





