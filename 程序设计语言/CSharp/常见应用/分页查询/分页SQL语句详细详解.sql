
use DataPagerDB
go
--��ѯ��һҳ
select  Top 5 StudentId,StudentName,Gender,Birthday,PhoneNumber from Students
where Birthday>'1989/10/12' 
--��ѯ�ڶ�ҳ
select  Top 5 StudentId,StudentName,Gender,Birthday,PhoneNumber from Students
where Birthday>'1989/10/12'  and StudentId not in
(select Top 5 StudentId from Students where Birthday>'1989/10/12' order by StudentId ASC )
order by StudentId ASC
--��ѯ����ҳ    �ܽ��������=ÿҳ��ʾ������*����ʾ�ĵڼ�ҳ-1��
select  Top 5 StudentId,StudentName,Gender,Birthday,PhoneNumber from Students
where Birthday>'1989/10/12'  and StudentId not in
(select Top 10 StudentId from Students where Birthday>'1989/10/12' order by StudentId ASC )
order by StudentId ASC
--��ѯ���������ļ�¼����
select COUNT(*) from Students where Birthday>'1989/10/12' 

--���������������ҳ���������ܼ�5����ÿҳ�ֱ���ʾ��3��5��8������ʵ�ʷ�ҳ����
print '----���----'
print 5/3     --2ҳ
print 5/5     --1ҳ
print 5/8     --1ҳ

print '---ʵ�ʷ�ҳ��---'
print 5/3+1     --2ҳ
print 5/5         --1ҳ
print 5/8+1     --1ҳ

--���ڳ������������ͨ��ȡģ���жϣ��������Ķ���1������ʵ��ҳ����
print '---ȡģ---'
print 5%3    
print 5%5        
print 5%8    
--==============��ҳʵ�ֵĻ���˼·=================
--ÿҳ��ʾ������
--���˵�������=ÿҳ��ʾ������*����ǰ��ʾ��ҳ��-1��
--��ѯ������ȷ��
--��������

--��ȡ���������ļ�¼����
--֪����ѯ�����Ҫ��ʾ��ҳ��=��¼����/ÿҳ��ʾ���� + 1�������¼������ÿҳ��ʾ����ȡģ��Ϊ0�����1��