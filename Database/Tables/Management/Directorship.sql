use Tramita 

create table [Management].[Directorship]
 (
   DirectorshipID int identity(1, 1) primary key, 
   Name varchar(200) NOT NULL,
   Nick varchar(80) NOT NULL, 
   DirectorshipStatus bit NOT NULL,
   CreatedDate datetime NOT NULL,
   ModifiedDate datetime not null
 )
