CREATE TABLE [dbo].[Comments]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Content] varchar(255) not null,
	PostDate datetime2(7) not null,
	UserId int not null,
	EventId int not null

	constraint FK_UserId foreign Key (UserId) references Users(Id),
	constraint FK_EventId foreign Key (EventId) references [Events](Id)

)
