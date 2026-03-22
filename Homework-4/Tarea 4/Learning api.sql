Create Database LearningApiDB

Create table PRODUCT
(
Id int primary key identity (1,1),
ProductName VARCHAR(100) NOT NULL,
Price int NOT NULL,
DateReceived DATETIME NOT NULL,
Stock BIT NOT NULL
);
select* from PRODUCT

SELECT @@SERVERNAME AS NombreServidor;
SELECT name 
FROM sys.databases;

select * from PRODUCT
DROP TABLE Product