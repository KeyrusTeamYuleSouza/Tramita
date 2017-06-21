use Tramita 

create table RequestActivity
(
    ID int identity(1, 1) primary key,
    TicketNumber int NOT NULL,
    Client int,
    UserRequest int foreign key (UserRequestID) references Person.IdentityCard (ID),
    UserDestination int foreign key (UserDestinationID) references Person.IdentityCard(ID),
    Directorship int foreign key (DirectorshipID) references Management.Directorship(DirectorshipID), 
    TicketStatus char(1) not null,
    TicketDate datetime not null,
    TicketModifiedDate datetime not null
)


