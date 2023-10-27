CREATE PROCEDURE [dbo].[UserLogin]
	@email varchar(100) ,
	@pwd varchar(100)
	as 
begin

declare @salt varchar(255)

set @salt = (select s.value from Users as u join Salt as s on u.SaltId = s.Id where LoginEmail = @email ) 

declare @hashMdp varbinary(100)
set @hashMdp = HASHBYTES('SHA2_512',CONCAT(@salt,@pwd,@email,dbo.secretKey()))

 select  u.Id, LoginEmail,r.Value as [role],r.Id as RoleId ,LastName,FirstName,GSM,Nickname,Allergie,InfoSupp  from Users as u join [Role] as r on u.RoleId = r.Id where  LoginEmail = @email and u.Password = @hashMdp

  end
