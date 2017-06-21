use Tramita 

create table Ticket.Ticket
(
    ID int identity(1, 1) primary key,
    TicketNumber int NOT NULL,
    Client int foreign key (ID) references Customer.Client(ID),
    UserRequest int foreign key (ID) references Person.IdentityCard (ID),
    UserDestination int foreign key (ID) references Person.IdentityCard(ID),
    Directorship int foreign key (ID) references Management.Directorship(DirectorshipID), 
    TicketStatus char(1) not null,
    TicketDate datetime not null,
    TicketModifiedDate datetime not null
)