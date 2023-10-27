CREATE TABLE [dbo].[Participate]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[CosplayerId] int not null,
	[EventId] int not null,
	[date] datetime2(7) not null,
	[Presence] varchar(50) not null,


	constraint FK_CosplayerIdParticipate foreign key (CosplayerId) references [Users](Id) on delete cascade,
	constraint FK_EventIdParticipate foreign key (EventId) references [Events](Id) on delete cascade,
)
