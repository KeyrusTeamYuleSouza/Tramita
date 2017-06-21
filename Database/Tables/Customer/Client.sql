use Tramita 

create table Client 
(
	ID int identity(1, 1) primary key,
	ClientCnpj varchar(16) NOT NULL,
	ClientCode varchar(10) NOT NULL,
	Name varchar(255) NOT NULL,
	ClientUrl varchar(120) NULL,
	ClientStatus bit NOT NULL,
	ModifiedDate datetime NOT NULL
)