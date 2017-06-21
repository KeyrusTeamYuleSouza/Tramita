use Tramita 

create table [Person].[UserRoles]
(
	UserIdentityCardID int foreign key(UserIdentityCardID) references [Person].[IdentityCard] ([ID]),
	UserRoleID int foreign key(UserRoleID) references [Management].[Roles] ([ID]),
	CreatedDate datetime NOT NULL,
	ModifiedDate datetime
)



