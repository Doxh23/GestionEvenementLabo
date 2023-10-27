CREATE TABLE [dbo].[EventTypeDay]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	TypeId int not null ,
	EventId int not null,
	[Date] datetime2(7) not null,


	constraint FK_TypeIdEventTypeDay foreign key (TypeId) references EventType(Id) on delete cascade,
	constraint FK_EventIdEventTypeDay foreign key (EventId) references [Events](Id) on delete cascade
)
