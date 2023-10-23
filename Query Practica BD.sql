use Practica02PAMathias;

---Tablas
CREATE TABLE Vendedores (
    VendedorID INT PRIMARY KEY IDENTITY(1,1),
    Cedula NVARCHAR(15) NOT NULL,
    Nombre NVARCHAR(255) NOT NULL,
    Correo NVARCHAR(255) NOT NULL,
    Estado BIT NOT NULL,
    CONSTRAINT UQ_Cedula UNIQUE (Cedula)
);

CREATE TABLE Vehiculos (
    VehiculoID INT PRIMARY KEY IDENTITY(1,1),
    Marca NVARCHAR(100) NOT NULL,
    Modelo NVARCHAR(100) NOT NULL,
    Color NVARCHAR(50) NOT NULL,
    Precio DECIMAL(18, 2) NOT NULL,
    VendedorID INT NOT NULL,
    CONSTRAINT FK_VendedorID FOREIGN KEY (VendedorID) REFERENCES Vendedores(VendedorID),
);

CREATE TABLE Consultas (
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Cedula NVARCHAR(50),
    Nombre NVARCHAR(50),
    Marca NVARCHAR(50),
    Modelo NVARCHAR(50),
    Precio DECIMAL
);


-- Procedimientos
CREATE PROCEDURE VendedorPA
    @Cedula NVARCHAR(50),
    @Nombre NVARCHAR(100),
    @Correo NVARCHAR(100),
    @Estado BIT
AS
BEGIN
    INSERT INTO Vendedores (Cedula, Nombre, Correo, Estado)
    VALUES (@Cedula, @Nombre, @Correo, @Estado)
END

select * from Vehiculos;
select * from Vendedores


CREATE PROCEDURE InsertarVehiculo
    @Marca NVARCHAR(100),
    @Modelo NVARCHAR(100),
    @Color NVARCHAR(50),
    @Precio DECIMAL(18, 2),
    @VendedorID INT
AS
BEGIN
    -- Contar cuántos vehículos con la misma marca ya existen
    DECLARE @Count INT
    SELECT @Count = COUNT(*) FROM Vehiculos WHERE Marca = @Marca

    -- Si ya existen 2 vehículos con la misma marca, no permitir la inserción
    IF @Count >= 2
    BEGIN
        THROW 50000, 'No se pueden insertar más de 2 vehículos con la misma marca.', 1
        RETURN
    END

    -- Insertar el nuevo vehículo
    INSERT INTO Vehiculos (Marca, Modelo, Color, Precio, VendedorID)
    VALUES (@Marca, @Modelo, @Color, @Precio, @VendedorID)
END

-- Disparadores
CREATE TRIGGER trg_InsertarEnConsultasDesdeVendedores
ON Vendedores
AFTER INSERT
AS
BEGIN
    INSERT INTO Consultas (Cedula, Nombre, Marca, Modelo, Precio)
    SELECT V.Cedula, V.Nombre, VH.Marca, VH.Modelo, VH.Precio
    FROM inserted AS V
    JOIN Vehiculos AS VH ON V.VendedorID = VH.VendedorID;
END;

-- Crear el trigger en la tabla "Vehiculos"
CREATE TRIGGER trg_InsertarEnConsultasDesdeVehiculos
ON Vehiculos
AFTER INSERT
AS
BEGIN
    INSERT INTO Consultas (Cedula, Nombre, Marca, Modelo, Precio)
    SELECT V.Cedula, V.Nombre, VH.Marca, VH.Modelo, VH.Precio
    FROM Vendedores AS V
    JOIN inserted AS VH ON V.VendedorID = VH.VendedorID;
END;
