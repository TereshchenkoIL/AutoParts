CREATE PROCEDURE [dbo].[sp_UpdateUser]
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
    @Id int 
AS
    Update Users 
	Set
	Name = @name,
	Second_name = @second,
	Surname = @surname,
	Email = @email,
	Phone = @phone,
	UserName = @username,
	Password = @password,
	City = @city,
	Adress = @adress,
	Disc_Id = @disc,
	IsAdmin = @isAdmin
	WHERE User_Id = @Id
  
   
GO