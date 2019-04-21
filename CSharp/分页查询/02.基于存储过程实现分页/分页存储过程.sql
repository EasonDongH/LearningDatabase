
use DataPagerDB
go
if exists(select * from sysobjects where name='usp_DataPager')
drop procedure usp_DataPager
go
create procedure usp_DataPager  
 @PageSize int,--ÿҳ��ʾ������
 @FilterCount int, --���˵����� 
 @Birthday varchar(20) --��ѯ��������
as 
	Select Top  (@PageSize) StudentId,StudentName,Gender,Birthday,PhoneNumber from Students 
	where  Birthday>@Birthday and StudentId not in
	 (Select Top  (@FilterCount) StudentId from Students where  Birthday>@Birthday order by StudentId ASC)
	order by StudentId ASC
	--��ѯ�����¼���� 
	select  count(*) from Students where  Birthday>@Birthday 
go

