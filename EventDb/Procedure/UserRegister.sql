CREATE Procedure [dbo].[UserRegister]

	@Password varchar(100),
	@Email varchar(100),
	@Role int,
	@LastName varchar(100),
	@FirstName varchar(100),
	@Gsm varchar(100),
	@Nickname varchar(100),
	@Allergie varchar(100),
	@InfoSupp varchar(255)


AS

BEGIN
	declare @Salt varchar(255)
	set @Salt = CONCAT(newid(),newid(),newid())
	declare @PwdHash varbinary(100)
	set @PwdHash = HASHBYTES('SHA2_512',CONCAT(@Salt,@password,@Email,dbo.secretKey()))
	begin transaction t1
	 insert into Salt values (@Salt) 
	 declare @saltId int
	 set @saltId = @@IDENTITY
	insert into Users values(@email,@PwdHash,@Role,@SaltId,@LastName,@FirstName,@Gsm,@Nickname,@Allergie,@InfoSupp)
	if (@@ERROR = 0)
	begin
		commit transaction t1
   end
   else
   begin 
      rollback transaction t1
	end

	select @@ROWCOUNT


END
