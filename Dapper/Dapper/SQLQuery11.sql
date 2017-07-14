CREATE TABLE dbo.Team
(
Id INT PRIMARY KEY,
TeamName VARCHAR(255),
Town VARCHAR(255)
);

CREATE TABLE dbo.Player
(
Id INT PRIMARY KEY,
FirstName     VARCHAR(255),
LastName     VARCHAR(255),
Age     VARCHAR(255),
TeamId   INT FOREIGN KEY REFERENCES Team(Id)
);

INSERT INTO Team VALUES (1, 'Let is Snow', 'ISBN3030303');
INSERT INTO Team VALUES (2, 'Three Cups of Tea','ISBN638242');
GO

INSERT INTO dbo.Player VALUES(100,'John Green','3030','1','1');
INSERT INTO dbo.Player VALUES(101,'Maureen Johnson','4343','1','1');
INSERT INTO dbo.Player VALUES(102,'Lauren Myracle','76665','1','1');
INSERT INTO dbo.Player VALUES(103,'Greg Mortenson','6434','1','1');
INSERT INTO dbo.Player VALUES(104,'David Oliver Relin','72322','1','1');
GO

SELECT * FROM dbo.Team;
SELECT * FROM dbo.Player;