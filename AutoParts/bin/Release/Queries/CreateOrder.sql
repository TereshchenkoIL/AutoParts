CREATE PROCEDURE [dbo].[sp_CreateOrder]
    @user int,
    @date date,
	@time time,
	@curr varchar(1),
    @Id int out
AS
   INSERT INTO Orders (User_Id,Create_Date,Create_Time,Curr)
   VALUES(@user,@date,@time,@curr)
  
    SET @Id=SCOPE_IDENTITY()
GO