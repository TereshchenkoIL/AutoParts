USE CourseWorkdb;
GO

CREATE TABLE Engines
(
Engine_Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(150) NOT NULL,
Power INT,
Volume FLoat,
Type NVARCHAR(170) NOT NULL
);

CREATE TABLE Cars
(
Car_Id INT PRIMARY KEY IDENTITY,
Mark NVARCHAR(100) NOT NULL,
Year INT NOT NULL,
Model NVARCHAR(150) NOT NULL,
Type NVARCHAR (100)
);

CREATE TABLE Modifications
(
Modif_Id INT PRIMARY KEY IDENTITY,
NAME NVARCHAR(150) NOT NULL,
Complect NVARCHAR(50),
Drive_type NVARCHAR(70),
Car_Id INT,
Engine_Id INT,
CONSTRAINT FK_Mod_To_Cars FOREIGN KEY (Car_Id) REFERENCES Cars(Car_Id) ON DELETE CASCADE,
CONSTRAINT FK_Mod_To_Engines FOREIGN KEY (Engine_Id) REFERENCES Engines(Engine_Id) ON DELETE CASCADE
);

CREATE TABLE Groups
(
Group_Id INT PRiMARY KEY IDENTITY,
Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Pr_Types
(
Type_Id INT PRIMARY KEY IDENTITY,
Group_Id INT,
Name NVARCHAR(100)
);
CREATE TABLE Producers
(
Producer_Name NVARCHAR(150) PRIMARY KEY,
Descript NVARCHAR(500),
Year INT
);
GO
CREATE TABLE Parts
(
Part_Id INT PRIMARY KEY IDENTITY,
Car_Id INT,
Price MONEY NOT NULL,
Type_Id INT,
Name NVARCHAR(350) NOT NULL,
Descript NVARCHAR(700),
Producer_Name NVARCHAR(150),
Warranty INT,
CONSTRAINT FK_Part_To_Cars FOREIGN KEY (Car_Id) REFERENCES Cars(Car_Id) ON DELETE SET NULL,
CONSTRAINT FK_Part_To_Type FOREIGN KEY (Type_Id) REFERENCES Pr_Types(Type_Id),
CONSTRAINT FK_Part_To_Prod FOREIGN KEY (Producer_Name) REFERENCES Producers(Producer_Name) ON DELETE SET NULL
);

CREATE TABLE Properties
(
Prop_Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(100) NOT NULL,
Unit Nvarchar(25) NOT NULL
);

CREATE TABLE Prop_Part
(
Prop_Id INT,
Part_Id INT,
Value INT,
PRIMARY KEY(Prop_Id, Part_Id),
CONSTRAINT FR_Prop_Part_To_Prop FOREIGN KEY (Prop_Id) REFERENCES Properties(Prop_Id) ON DELETE CASCADE,
CONSTRAINT FR_Prop_Part_To_Part FOREIGN KEY (Part_Id) REFERENCES Parts(Part_Id) ON DELETE CASCADE
);

CREATE TABLE Discounts
(
Disc_Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(70),
Disc INT,
Descript NVARCHAR(300)
);

CREATE TABLE Users
(
User_Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL,
Second_name NVARCHAR(70) NOT NULL,
Surname NVARCHAR(90) NOT NULL,
Email NVARCHAR(100),
Phone NVARCHAR(100),
UserName NVARCHAR(50) NOT NULL,
Password NVARCHAR(20) NOT NULL,
City NVARCHAR(25),
Adress NVARCHAR(50),
Disc_Id INT,
IsAdmin BIT,
CONSTRAINT FK_Users_To_Disc FOREIGN KEY (Disc_Id) REFERENCES Discounts(Disc_Id) ON DELETE SET NULL
);
GO

CREATE TABLE Orders
(
Order_Id INT PRIMARY KEY IDENTITY,
User_Id INT,
Create_Date DATE,
Curr VARCHAR(1),
Create_Time TIME,
CONSTRAINT FK_Orders_To_Users FOREIGN KEY (User_Id) REFERENCES Users(User_Id) ON DELETE CASCADE 
);

CREATE TABLE Order_Part(
Order_Id INT,
Part_Id INT,
Quantity INT NOT NULL,
PRIMARY KEY(Order_Id,Part_Id),
CONSTRAINT FK_OP_To_Orders FOREIGN KEY (Order_Id) REFERENCES Orders(Order_Id) ON DELETE CASCADE,
CONSTRAINT FK_OP_To_Parts FOREIGN KEY (Part_Id) REFERENCES Parts(Part_Id)
);

CREATE TABLE Responses
(
Response_Id INT PRIMARY KEY IDENTITY,
Part_Id INT,
User_Id INT,
Rate FLOAT,
Text NVARCHAR(500),
Create_Date Date,
CONSTRAINT FK_Resp_To_Part FOREIGN KEY (Part_Id) REFERENCES Parts(Part_Id) ON DELETE CASCADE,
CONSTRAINT FK_Resp_To_User FOREIGN KEY (User_Id) REFERENCES Users(User_Id) ON DELETE CASCADE
);