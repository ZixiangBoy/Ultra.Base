
--CREATE TABLE tablename(
--	Id int identity(1,1) primary key NOT NULL,
--	Guid uniqueidentifier default newid() NULL,
--	Remark nvarchar(2000) NULL,
--	CreateDate datetime default getdate() NULL,
--	Creator nvarchar(50) NULL,
--	IsUsing bit default 1 NULL,
--	TimeStamp timestamp NOT NULL
--)
--go

drop table t_user
create table t_user(
	Id int identity(1,1) primary key NOT NULL,
	Guid uniqueidentifier default newid() not NULL,
	UserName nvarchar(50) NOT NULL,
	Pwd nvarchar(100) NULL,
	Remark nvarchar(2000) NULL,
	CreateDate datetime default getdate() not NULL,
	Creator nvarchar(50) NULL,
	IsUsing bit default 1 not NULL,
	TimeStamp timestamp NOT NULL
)
go

drop table t_role
CREATE TABLE t_role(
	Id int IDENTITY(1,1) NOT NULL,
	Guid uniqueidentifier default newid() not NULL,
	Name nvarchar(100) NOT NULL,
	[Desc] nvarchar(500) null,
	Remark nvarchar(200) NOT NULL,
	CreateDate datetime default getdate() not NULL,
	Creator nvarchar(50) NULL,
	IsUsing bit default 1 not NULL,
	TimeStamp timestamp NOT NULL
)
go

drop table t_roleset
CREATE TABLE t_roleset(
	Id int identity(1,1) primary key NOT NULL,
	Guid uniqueidentifier default newid() not NULL,
	RoleName nvarchar(100) NOT NULL,
	RoleId int NOT NULL,
	RoleSetTree nvarchar(max) NOT NULL,
	Remark nvarchar(2000) NULL,
	CreateDate datetime default getdate() not NULL,
	Creator nvarchar(50) NULL,
	IsUsing bit default 1 not NULL,
	TimeStamp timestamp NOT NULL
)
go

drop table t_roleuser
CREATE TABLE t_roleuser(
	Id int identity(1,1) primary key NOT NULL,
	Guid uniqueidentifier default newid() not NULL,
	UserId int NOT NULL,
	RoleId int NOT NULL,
	Remark nvarchar(2000) NULL,
	CreateDate datetime default getdate() not NULL,
	Creator nvarchar(50) NULL,
	IsUsing bit default 1 not NULL,
	TimeStamp timestamp NOT NULL
)
go

drop table t_menu
CREATE TABLE t_menu(
	Id int identity(1,1) primary key NOT NULL,
	Guid uniqueidentifier default newid() not NULL,
	[Version] nvarchar(20) NOT NULL,
	MenuXml nvarchar(max) NOT NULL,
	CreateDate datetime default getdate() not NULL,
	Creator nvarchar(50) NULL,
	IsUsing bit default 1 not NULL,
	TimeStamp timestamp NOT NULL
)
go

drop table t_mac
CREATE TABLE t_mac(
	Id int identity(1,1) primary key NOT NULL,
	Guid uniqueidentifier default newid() not NULL,
	[Mac] nvarchar(50) NOT NULL,
	CreateDate datetime default getdate() not NULL,
	Creator nvarchar(50) NULL,
	IsUsing bit default 1 not NULL,
	TimeStamp timestamp NOT NULL
)
go

drop table t_loginfail
CREATE TABLE t_loginfail(
	Id int identity(1,1) primary key NOT NULL,
	Guid uniqueidentifier default newid() not NULL,	
	UserName nvarchar(20) NOT NULL,
	LoginMAC nvarchar(200) NOT NULL,
	ExternalIP nvarchar(200) NOT NULL,
	LocalIP nvarchar(200) NOT NULL,
	LoginTime datetime NOT NULL,
	LastUpdateTime datetime NOT NULL,
	CreateDate datetime default getdate() not NULL,
	Creator nvarchar(50) NULL,
	IsUsing bit default 1 not NULL,
	TimeStamp timestamp NOT NULL
)
go

drop table t_logincur
CREATE TABLE t_logincur(
	Id int identity(1,1) primary key NOT NULL,
	Guid uniqueidentifier default newid() not NULL,	
	UserName nvarchar(20) NOT NULL,
	LoginMAC nvarchar(200) NOT NULL,
	ExternalIP nvarchar(200) NOT NULL,
	LocalIP nvarchar(200) NOT NULL,
	LoginTime datetime NOT NULL,
	LastUpdateTime datetime NOT NULL,
	CreateDate datetime default getdate() not NULL,
	Creator nvarchar(50) NULL,
	IsUsing bit default 1 not NULL,
	TimeStamp timestamp NOT NULL
)
go

drop table t_forcedoffline
CREATE TABLE t_forcedoffline(
	Id int identity(1,1) primary key NOT NULL,
	Guid uniqueidentifier default newid() not NULL,	
	LoginMAC nvarchar(200) NOT NULL,
	CreateDate datetime default getdate() not NULL,
	Creator nvarchar(50) NULL,
	IsUsing bit default 1 not NULL,
	TimeStamp timestamp NOT NULL
)
go




