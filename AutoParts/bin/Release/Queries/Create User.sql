CREATE PROCEDURE [dbo].[sp_CreateUser]
    @name nvarchar(50),
	@second nvarchar(70),
	@surname nvarchar(90),
	@email nvarchar(100),
	@phone nvarchar(100),
	@username nvarchar(50),
	@password nvarchar(50),
	@city nvarchar(25),
	@adress nvarchar(25),
	@disc int,
	@isAdmin bit,
    @Id int out
AS
    INSERT INTO Users (Name, Second_name,Surname,Email,Phone,UserName,Password,City,Adress, Disc_Id, IsAdmin)
    VALUES (@name, @second,@surname, @email, @phone, @username, @password, @city, @adress, @disc, @isAdmin)
  
    SET @Id=SCOPE_IDENTITY()
GO