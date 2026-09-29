/*
    Ejercicio 1
*/

IF DB_ID(N'EmpresaDB') IS NULL
BEGIN
    CREATE DATABASE EmpresaDB;
END;
GO

USE EmpresaDB;
GO

IF OBJECT_ID(N'dbo.Clientes', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Clientes
    (
        Id INT IDENTITY(1,1) NOT NULL
            CONSTRAINT PK_Clientes PRIMARY KEY,
        Nombre VARCHAR(100) NOT NULL,
        Apellido VARCHAR(100) NOT NULL,
        Email VARCHAR(150) NOT NULL,
        Telefono VARCHAR(30) NULL
    );
END;
GO
