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
GO



-- Proceso de Ventas
CREATE TABLE productos (
    productoId UNIQUEIDENTIFIER PRIMARY KEY,
    nombre VARCHAR (100) NOT NULL,
    descripcion VARCHAR (500) NOT NULL,
    cantidad DECIMAL(7, 2),
    precio DECIMAL(7, 2)
);

CREATE TABLE ventas (
    ventaId UNIQUEIDENTIFIER PRIMARY KEY,
    fecha DATETIME,
    cliente VARCHAR(100),
    concepto VARCHAR(500),
    subtotal DECIMAL(7, 2),
    iva DECIMAL(7,2),
    total DECIMAL(7, 2)
)

CREATE TABLE ventasDetalles (
    productoId UNIQUEIDENTIFIER NOT NULL,
    ventaId UNIQUEIDENTIFIER NOT NULL,
    cantidadVendido DECIMAL(7,2) NOT NULL,
    precioProducto DECIMAL(7,2) NOT NULL,
    total DECIMAL(7,2) NOT NULL,
    CONSTRAINT PK_ProductoVenta PRIMARY KEY NONCLUSTERED (productoId, ventaId)
)


INSERT INTO productos (productoId, nombre, descripcion, cantidad, precio) VALUES ('69289A27-78EE-44B6-8A14-1086BF904FB8', 'Computador ASUS VivoBook 15', 'laptop para trabajos', 10, 29520.5)
INSERT INTO ventas (ventaId, fecha, cliente, concepto, subtotal, iva, total) VALUES ('43525D98-0950-494B-BA57-CBD2072ECBFE', '2021/05/18', 'Michael Traña', 'venta de computadora de contado', 29520.5, 4428.07, 33948.57)
INSERT INTO ventasDetalles (productoId, ventaId, cantidadVendido, precioProducto, total) VALUES ('69289A27-78EE-44B6-8A14-1086BF904FB8', '43525D98-0950-494B-BA57-CBD2072ECBFE', 1, 29520.5, 29520.5)
GO