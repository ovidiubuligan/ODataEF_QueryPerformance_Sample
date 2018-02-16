
USE master
IF EXISTS(select * from sys.databases where name='ODataPerformanceSample')
	DROP DATABASE ODataPerformanceSample


CREATE DATABASE ODataPerformanceSample;
go

USE ODataPerformanceSample;
go

CREATE TABLE [User]  
   (Id int PRIMARY KEY NOT NULL IDENTITY(1,1),  
    UserName varchar(25) NOT NULL,  
    FirstName varchar(25) ,  
	LastName varchar(25) ,
    Age int
	);

CREATE TABLE [Role ]  
   (Id int PRIMARY KEY  NOT NULL IDENTITY(1,1),  
    [Name] varchar(25) ,  
    [Description] varchar(25) ,  
    [Col1] varchar(25) 
	);  

CREATE TABLE [UserRole]  
   (Id int PRIMARY KEY NOT NULL IDENTITY(1,1),  
    [UserId] int FOREIGN KEY REFERENCES [User](Id),  
    [RoleId] int FOREIGN KEY REFERENCES [Role](Id)      
	);  
go 


 -- Seed the database

DECLARE @i int = 0
WHILE @i < 30 
BEGIN	
    SET @i = @i + 1;
	DECLARE @istring as varchar(25);
	SET @istring = @i;-- CAST(@i as varchar(25));
	-- add Users
    Insert into [User](UserName,FirstName,LastName,Age) 
				Values('UserName'+@istring,'FirstName'+@istring,'LastName'+@istring,@i/2);
	-- add Roles

    Insert into [Role]([Name],[Description]) 
				Values('RoleName'+@istring,'Description'+@istring );

	-- link Users to Roles
	Insert into [UserRole](UserId,RoleId) 
				Values(@i,@i/5+1);

END

