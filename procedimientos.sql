use InventarioBD
go

create or alter proc usp_listar_productos
as
begin
    select ProductoID, Nombre, Categoria
    from Productos
end
go

create or alter proc usp_insertar_producto
    @Nombre nvarchar(100),
    @Categoria nvarchar(50)
as
begin
    insert into Productos (Nombre, Categoria)
    values (@Nombre, @Categoria)
end
go

create or alter proc usp_actualizar_producto
    @ProductoID int,
    @Nombre nvarchar(100),
    @Categoria nvarchar(50)
as
begin
    update Productos
    set Nombre = @Nombre,
        Categoria = @Categoria
    where ProductoID = @ProductoID
end
go

create or alter proc usp_listar_inventario
as
begin
    select InventarioID, FechaIngreso, Cantidad, Ubicacion, Estado, ProductoID
    from Inventario
end
go

create or alter proc usp_insertar_inventario
    @FechaIngreso date,
    @Cantidad int,
    @Ubicacion nvarchar(100),
    @Estado nvarchar(50),
    @ProductoID int
as
begin
    insert into Inventario (FechaIngreso, Cantidad, Ubicacion, Estado, ProductoID)
    values (@FechaIngreso, @Cantidad, @Ubicacion, @Estado, @ProductoID)
end
go

create or alter proc usp_actualizar_inventario
    @InventarioID int,
    @FechaIngreso date,
    @Cantidad int,
    @Ubicacion nvarchar(100),
    @Estado nvarchar(50),
    @ProductoID int
as
begin
    update Inventario
    set FechaIngreso = @FechaIngreso,
        Cantidad = @Cantidad,
        Ubicacion = @Ubicacion,
        Estado = @Estado,
        ProductoID = @ProductoID
    where InventarioID = @InventarioID
end
go
