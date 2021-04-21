USE master
GO

CREATE DATABASE MiBaseDeDatos
GO

USE MiBaseDeDatos
GO

CREATE TABLE personas (
    personaId UNIQUEIDENTIFIER PRIMARY KEY,
    nombres VARCHAR (50) NOT NULL,
    apellidos VARCHAR (50) NOT NULL,
    genero CHAR(1),
    fechaNacimiento VARCHAR(10)
);


SELECT * FROM personas
GO