CREATE PROCEDURE [dbo].[sp_CreateProp_Part]
    @prop int,
    @part int,
	@value nvarchar(100),
    @Id int out
AS
    INSERT INTO Prop_Part(Prop_Id,Part_Id,Value)
    VALUES (@prop, @part,@value)
  
    SET @Id=SCOPE_IDENTITY()
GO