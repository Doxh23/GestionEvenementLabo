/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

insert into [Role] values('Admin');
insert into [Role] values('Modo');
insert into [Role] values('Cosplayer');
insert into [Role] values('User');


insert into [EventType] values ('asia');
insert into [EventType] values ('comics');
insert into [EventType] values ('anime');
insert into [EventType] values ('games');


insert into [Status] values ('active');
insert into [Status] values ('termined');
insert into [Status] values ('cancel');

exec dbo.UserRegister 'Test1234!','admin@mail.com' ,1,'Adrien','Péters','04512520','dox','fort','pointfaible trop fort';
exec dbo.UserRegister 'Test1234!','user@mail.com' ,4,'Loic','La tantouze','04512520','lolo','faible','point faible trop faible';
