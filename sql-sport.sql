
create database [Sportif-client];
use [Sportif-client];

create table [ADMIN](Name nvarchar(50),PassW nvarchar(50));
insert into [ADMIN] values('walid','walid');

create table client(CIN nvarchar(20) primary key,Name varchar(50),Age int,Tel nvarchar(30),Address varchar(70),JoinDate datetime,[Image] image,Prix BIT ,DateP datetime,typeC nvarchar(20) );

alter table client
ADD CONSTRAINT checktype check (typeC = 'KONGF' or typeC = 'TYK' or typeC = 'KIK' or typeC = 'MUS' or typeC = 'JUDO' or typeC = 'KRT')

 
create table [MONEY](typeC nvarchar(20),Prix float,JR smallint);

alter table [MONEY]
ADD CONSTRAINT checktype2 check (typeC = 'KONGF' or typeC = 'TYK' or typeC = 'KIK' or typeC = 'MUS' or typeC = 'JUDO' or typeC = 'KRT')
  
insert into [MONEY] values ('KONGF',100,30),('TYK',100,30),('KIK',100,30),('MUS',100,30),('JUDO',100,30),('KRT',100,30)


--SELECT DATA
Create Proc Selectclient
@typeC nvarchar(20)
as
Select * From  client Where typeC = @typeC


--INSERT DATA
create Proc Insertclint
@CIN varchar(20),@Name varchar(50),@Age int,@Tel varchar(30),@Add varchar(70),@DateD datetime,@image image ,@typeC nvarchar(20)
as
insert into client(CIN,Name,Age,Tel,Address,JoinDate,[image],typeC)
values (@CIN,@Name,@Age,@Tel,@Add,@DateD,@image,@typeC)


--Delet Data
create Proc Deleteclint
@CIN varchar(20),@typeC nvarchar(20)
AS
Delete From client Where CIN=@CIN


--UPDATE
create Proc Edit
@CIN varchar(20),@Name varchar(50),@Age int,@Tel varchar(30),@Add varchar(70),@DateD datetime,@image image,@typeC nvarchar(20)
as
Update client
set
Name=@Name,Age=@Age,Tel=@Tel,Address=@Add,JoinDate=@DateD,[Image]=@image
Where CIN=@CIN and typeC = @typeC











