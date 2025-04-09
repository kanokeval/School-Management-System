create database SMS;
use SMS;
create table AdminLogin(username varchar(50),password varchar(50));
select * from AdminLogin;
insert into AdminLogin values('keval','keval123');

create table StudInformation
(studid int NOT NULL primary key,studnm varchar(50) null,dob datetime null,
gender varchar(50) null,phone varchar(50) null,email varchar(50) null);
select * from StudInformation;			

create table TeacherInfo
(teacherid int NOT NULL,teachernm varchar(50),
gender varchar(50));
alter table TeacherInfo add subject varchar(20);
select * from TeacherInfo;

create table ClassInfo
(classid int NOT NULL,classnnm varchar(50),
class varchar(50));
select * from ClassInfo;

create table RollnoInfo
(rid int NOT NULL,rnm varchar(50),
rclass varchar(50),rdate datetime null);
select * from RollnoInfo;