use Tramita 

create table [Management].[Head]
(
   HeadID int identity(1, 1) primary key,
   DirectorshipID int foreign key(DirectorshipID) references [Management].[Directorship](DirectorshipID),
   Name varchar(200) NOT NULL,
   Nick varchar(80) NOT NULL, 
   HeadStatus bit NOT NULL,
   CreatedDate datetime NOT NULL,
   ModifiedDate datetime
)