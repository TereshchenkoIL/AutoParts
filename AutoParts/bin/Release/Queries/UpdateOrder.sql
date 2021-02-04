CREATE PROCEDURE [dbo].[sp_UpdateOrder]
    @user int,
    @date date,
	@time time,
	@curr varchar(1),
    @Id  INT
AS
  UPDATE Orders
  SET
  User_Id = @user,
  Create_Date = @date,
  Create_Time = @time,
  Curr = @curr
  WHERE Order_Id = @Id
    
GO