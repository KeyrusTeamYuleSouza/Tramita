use Tramita 

create table [Management].[Roles]
 (
	ID int identity(1, 1) primary key,
	Name varchar(80) NOT NULL,
	CreatedDate datetime NOT NULL,
	Active bit NOT NULL,
	ModifiedDate datetime
 )



