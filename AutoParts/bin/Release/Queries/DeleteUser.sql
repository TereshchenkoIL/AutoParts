Create PROCEDURE [dbo].[sp_DeleteUser]
 @id int
AS
   DELETE FROM Users
   WHERE User_Id = @id
Go
