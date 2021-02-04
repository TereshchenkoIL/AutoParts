Use CourseWorkdb;

SELECT Pr_Types.Name, AVG(Parts.Price) AS AVGPrice
FROM Parts  LEFT JOIN Pr_Types ON Parts.Type_Id =Pr_Types.Type_Id
Group By Pr_Types.Name


SELECT 'Середня ціна' As AVGPrice,[Акумулятор],[Тормозний диск]
FROM( SELECT p.Price, pr.Name
FROM Parts p LEFT JOIN Pr_Types pr ON p.Type_Id = pr.Type_Id) AS SourceTable
PIVOT(AVG(Price)FOR Name IN([Акумулятор],[Тормозний диск])) AS PivotTable