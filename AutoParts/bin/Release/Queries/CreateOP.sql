CREATE PROCEDURE [dbo].[sp_CreateOP]
    @order int,
    @part int,
    @quant int
AS
    INSERT INTO Order_Part(Order_Id,Part_Id,Quantity)
    VALUES (@order,@part,@quant)
  
   
GO