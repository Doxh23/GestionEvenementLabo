CREATE TABLE [dbo].[Events]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Name] varchar(70) not null ,
	[StartDate] datetime2(7) not null,
	[EndDate] datetime2(7) not null,
	[Location] varchar(50) not null,
	[Adress] varchar(250) not null,
	[StatusId] int not null,

	constraint C_Date  check(StartDate < EndDate),
	constraint FK_Status foreign key (StatusId) references [Status](Id) on delete cascade
)
