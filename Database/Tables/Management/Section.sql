USE Tramita 

create table [Management].[Section] 
(
   SectionID int identity(1, 1) primary key, 
   DirectorshipID int foreign key(DirectorshipID) references [Management].[Directorship](DirectorshipID),
   HeadID int foreign key(HeadID) references [Management].[Head](HeadID),
   Name varchar(200) NOT NULL,
   Nick varchar(80) NOT NULL, 
   SectionStatus bit NOT NULL,
   CreatedDate datetime NOT NULL,
   ModifiedDate datetime
)