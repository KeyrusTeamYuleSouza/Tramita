use Tramita 

select 
		u.[ID],
		u.[FirstName],
		u.[LastName],
		u.[TelePhone],
		u.[CellPhone],
		u.[Email],
		uic.[CPF],
		uic.[RE],
		uic.[Password],
		umgt.[SectionName],
		umgt.[DivisionName],
		um.[MidiaName],
		um.[MidiaPath],
		u.[ModifiedDate],
		u.[Active]

from [User] u 
join [UserIdentityCard] uic on u.[IdentityCardID] = uic.[IdentityCardID]
join [UserManagement] umgt on u.ManagementID = umgt.ManagementID
join [UserMidia] um on u.MidiaID = um.MidiaID

