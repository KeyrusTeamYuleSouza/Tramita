use Tramita 

create table Activity
(
	ID int identity(1 ,1) primary key,
	RequestActivity int foreign key (RequestActivityID) references RequestActivity (RequestActivityID),
	ModifiedDate datetime not null
)



