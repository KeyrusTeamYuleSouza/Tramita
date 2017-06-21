use Tramita 

create table [Person].[IdentityCard]
 (
	ID int identity(1, 1) primary key,
	CPF char(12) NOT NULL,
	RE varchar(10) NOT NULL,
	RG char(12) NOT NULL,
	PasswordHash varchar(255) NOT NULL,
	DirectorshipID int foreign key(DirectorshipID) references [Management].[Directorship](DirectorshipID),
	HeadID int foreign key(HeadID) references [Management].[Head](HeadID),
	SectionID int,
	CreatedDate datetime NOT NULL,
	Active bit NOT NULL,
	ModifiedDate datetime
 )