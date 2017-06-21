use Tramita 

create table [Person].[UserProfile]
(
	UserProfileID int identity(1, 1) primary key,
	IdentityCardID int foreign key(IdentityCardID) references [Person].[IdentityCard](ID),	
	FirstName varchar(80) NOT NULL,
	LastName varchar(100) NOT NULL,
	Email varchar(200) NOT NULL,
	Phone varchar(20),
	BirthDate datetime,
	About varchar(255),
	Midia varchar(255),
	ModifiedDate datetime
)