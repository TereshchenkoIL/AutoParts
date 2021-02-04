CREATE PROCEDURE [dbo].[sp_DeleteOrder]
        @Id int 
AS
    DELETE FROM Orders
	WHERE Order_Id = @Id
  
   
GO