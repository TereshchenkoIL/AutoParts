CREATE PROCEDURE [dbo].[sp_UpdatePart]
(
@id int null,
@car int,
@price MONEY,
@name NVARCHAR(350),
@Desc NVARCHAR(700),
@producer NVARCHAR(150),
@warr int
)
AS
BEGIN
	
	SET NOCOUNT ON;

UPDATE Parts
set
Car_Id = @car,
Price = @price,
Name = @name,
Descript = @Desc,
Producer_Name = @producer,
Warranty = @warr
WHERE Part_Id = @id
END