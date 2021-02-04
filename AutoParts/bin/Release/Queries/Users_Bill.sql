SELECT u.User_Id, u.Name,u.Second_name,u.Surname, u.Email, u.Phone, u.UserName, u.City, u.Adress, SUM(p.Price * OP.Quantity) AS Bill
From ((Users u INNER JOIN Orders o ON u.User_Id = o.User_Id) INNER JOIN Order_Part op ON o.Order_Id = op.Order_Id AND o.User_Id = u.User_Id)
INNER JOIN Parts p ON op.Part_Id = p.Part_Id
Group By u.User_Id,u.Name,u.Second_name,u.Surname, u.Email, u.Phone, u.UserName, u.City, u.Adress