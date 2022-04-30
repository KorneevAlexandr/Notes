﻿CREATE TABLE Notes
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	Description NVARCHAR(200),
	CreateDate DATETIME2,
	Content NVARCHAR(MAX)
);