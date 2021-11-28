 CREATE TABLE dbo.Usuarios (
	        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	        Edad int NOT NULL,
	        Genero int NOT NULL, 
			Nombre NVARCHAR(200) NOT NULL
        )