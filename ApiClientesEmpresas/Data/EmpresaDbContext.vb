Imports Microsoft.EntityFrameworkCore
Imports ApiClientesEmpresa.Models

Namespace Data

    Public Class EmpresaDbContext
        Inherits DbContext

        Public Sub New(options As DbContextOptions(Of EmpresaDbContext))
            MyBase.New(options)
        End Sub

        Public Property Clientes As DbSet(Of Cliente)

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)

            MyBase.OnModelCreating(modelBuilder)

            Dim entidad = modelBuilder.Entity(Of Cliente)()

            entidad.ToTable("Clientes", "dbo")

            entidad.HasKey(Function(cliente) cliente.Id)

            entidad.Property(Function(cliente) cliente.Id).
                UseIdentityColumn(1, 1)

            entidad.Property(Function(cliente) cliente.Nombre).
                HasColumnType("varchar(100)").
                IsRequired()

            entidad.Property(Function(cliente) cliente.Apellido).
                HasColumnType("varchar(100)").
                IsRequired()

            entidad.Property(Function(cliente) cliente.Email).
                HasColumnType("varchar(150)").
                IsRequired()

            entidad.Property(Function(cliente) cliente.Telefono).
                HasColumnType("varchar(30)").
                IsRequired(False)

        End Sub

    End Class

End Namespace