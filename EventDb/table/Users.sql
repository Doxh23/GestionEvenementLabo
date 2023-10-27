CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	LoginEmail varchar(150) not null Unique,
	[Password] varbinary(500) not null,
	RoleId int not null,
	SaltId int not null,
	LastName varchar(50) not null,
	FirstName varchar(50) not null,
	GSM varchar(50),
	Nickname varchar(50) not null unique,
	Allergie varchar(50) ,
	InfoSupp varchar(50) ,

	constraint FK_RoleIdUser foreign key (RoleId) references [Role](Id) on delete cascade,
	constraint FK_SaltIdUser foreign key (SaltId) references [Salt](Id) on delete cascade,
	constraint UNIQUE_User unique(LastName,FirstName,GSM)
)
