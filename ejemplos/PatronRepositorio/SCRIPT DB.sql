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

INSERT INTO personas (personaId, nombres, apellidos, genero, fechaNacimiento)
VALUES (NEWID(), 'Carlitos', 'Vargas', 'M', '31/12/1990')
GO

UPDATE personas SET genero = 'F', fechaNacimiento = '27/05/1998' WHERE personaId = '631BD9CF-312F-4DBF-83A7-384CDC51C9BD'
GO

DELETE FROM personas WHERE personaId = 95C2138A-ABC9-4515-ADEA-E7C22CF2F0EC