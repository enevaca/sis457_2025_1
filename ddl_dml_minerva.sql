﻿CREATE DATABASE Minerva;
GO
USE [master]
GO
CREATE LOGIN [usrminerva] WITH PASSWORD = N'123456',
	DEFAULT_DATABASE = [Minerva],
	CHECK_EXPIRATION = OFF,
	CHECK_POLICY = ON
GO
USE [Minerva]
GO
CREATE USER [usrminerva] FOR LOGIN [usrminerva]
GO
ALTER ROLE [db_owner] ADD MEMBER [usrminerva]
GO

DROP TABLE CompraDetalle;
DROP TABLE Compra;
DROP TABLE Usuario;
DROP TABLE Empleado;
DROP TABLE Proveedor;
DROP TABLE Producto;
DROP TABLE UnidadMedida;
DROP PROC paProductoListar;
DROP PROC paEmpleadoListar;

CREATE TABLE UnidadMedida(
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  descripcion VARCHAR(20) NOT NULL UNIQUE
);
CREATE TABLE Producto (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idUnidadMedida INT NOT NULL,
  codigo VARCHAR(20) NOT NULL,
  descripcion VARCHAR(250) NOT NULL,
  --unidadMedida VARCHAR(20) NOT NULL,
  saldo DECIMAL NOT NULL DEFAULT 0,
  precioVenta DECIMAL NOT NULL CHECK (precioVenta > 0),
  CONSTRAINT fk_Producto_UnidadMedida FOREIGN KEY(idUnidadMedida) REFERENCES UnidadMedida(id)
);
CREATE TABLE Proveedor (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nit BIGINT NOT NULL,
  razonSocial VARCHAR(100) NOT NULL,
  direccion VARCHAR(250) NULL,
  telefono VARCHAR(30) NOT NULL,
  representante VARCHAR(100) NOT NULL
);
CREATE TABLE Empleado (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  cedulaIdentidad VARCHAR(12) NOT NULL,
  nombres VARCHAR(30) NOT NULL,
  primerApellido VARCHAR(30) NULL,
  segundoApellido VARCHAR(30) NULL,
  direccion VARCHAR(250) NOT NULL,
  celular BIGINT NOT NULL,
  cargo VARCHAR(50) NOT NULL
);
CREATE TABLE Usuario (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idEmpleado INT NOT NULL,
  usuario VARCHAR(20) NOT NULL,
  clave VARCHAR(250) NOT NULL,
  CONSTRAINT fk_Usuario_Empleado FOREIGN KEY(idEmpleado) REFERENCES Empleado(id)
);
CREATE TABLE Compra (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idProveedor INT NOT NULL,
  transaccion INT NOT NULL,
  fecha DATE NOT NULL DEFAULT GETDATE(),
  CONSTRAINT fk_Compra_Proveedor FOREIGN KEY(idProveedor) REFERENCES Proveedor(id)
);
CREATE TABLE CompraDetalle (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idCompra INT NOT NULL,
  idProducto INT NOT NULL,
  cantidad DECIMAL NOT NULL CHECK (cantidad > 0),
  precioUnitario DECIMAL NOT NULL,
  total DECIMAL NOT NULL,
  CONSTRAINT fk_CompraDetalle_Compra FOREIGN KEY(idCompra) REFERENCES Compra(id),
  CONSTRAINT fk_CompraDetalle_Producto FOREIGN KEY(idProducto) REFERENCES Producto(id)
);

ALTER TABLE UnidadMedida ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE UnidadMedida ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE UnidadMedida ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Producto ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Producto ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Producto ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Proveedor ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Proveedor ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Proveedor ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Empleado ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Empleado ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Empleado ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Usuario ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Usuario ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Usuario ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Compra ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Compra ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Compra ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE CompraDetalle ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE CompraDetalle ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE CompraDetalle ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

GO
CREATE PROC paProductoListar @parametro VARCHAR(100)
AS
  SELECT p.id, p.codigo, p.descripcion, um.descripcion AS unidadMedida, p.saldo, p.precioVenta,
		 p.usuarioRegistro, p.fechaRegistro, p.estado, p.idUnidadMedida
  FROM Producto p
  INNER JOIN UnidadMedida um ON um.id = p.idUnidadMedida
  WHERE p.estado<>-1 AND p.codigo+p.descripcion+um.descripcion LIKE '%'+REPLACE(@parametro,' ','%')+'%'
  ORDER BY p.estado DESC, p.descripcion ASC;
GO
CREATE PROC paEmpleadoListar @parametro VARCHAR(100)
AS
  SELECT ISNULL(u.usuario,'--') AS usuario,e.* 
  FROM Empleado e
  LEFT JOIN Usuario u ON e.id = u.idEmpleado
  WHERE e.estado<>-1 
	AND e.cedulaIdentidad+e.nombres+ISNULL(e.primerApellido,'')+ISNULL(e.segundoApellido,'') LIKE '%'+REPLACE(@parametro,' ','%')+'%'
  ORDER BY e.estado DESC, e.nombres ASC, e.primerApellido ASC;

EXEC paProductoListar 'bond carta';
EXEC paEmpleadoListar '';

-- DML
INSERT INTO UnidadMedida(descripcion)
VALUES ('Caja'),('Docena'),('Metro'),('Paquete'),('Pliego'),('Unidad');

INSERT INTO Producto(codigo,descripcion,idUnidadMedida,saldo,precioVenta)
VALUES ('PL0254', 'Bolígrafo Pilot Color Azul', 1, 0, 36);

INSERT INTO Producto(codigo,descripcion,idUnidadMedida,saldo,precioVenta)
VALUES ('HB7985', 'Papel Bond Tamaño Carta', 4, 0, 30);

INSERT INTO Producto(codigo,descripcion,idUnidadMedida,saldo,precioVenta)
VALUES ('HB7986', 'Papel Bond Tamaño Oficio', 4, 0, 33);

UPDATE Producto SET precioVenta=34 WHERE codigo='HB7986';
UPDATE Producto SET estado=-1 WHERE codigo='HB7986';

INSERT INTO Empleado(cedulaIdentidad, nombres, primerApellido, segundoApellido, direccion, celular, cargo)
VALUES ('1234567', 'Juan', 'Pérez', 'López', 'Calle Loa N° 50', 71717171, 'Cajero');

INSERT INTO Usuario(idEmpleado, usuario, clave)
VALUES (1, 'jperez', '');

UPDATE Usuario SET clave='i0hcoO/nssY6WOs9pOp5Xw==' WHERE id=1;

SELECT * FROM Producto;
SELECT * FROM Usuario;