Imports System.Collections.Generic
Imports System.Linq
Imports Microsoft.EntityFrameworkCore
Imports ApiClientesEmpresa.Data
Imports ApiClientesEmpresa.Models

Namespace Repositories

    Public Class ClienteRepository
        Implements IClienteRepository

        Private ReadOnly _contexto As EmpresaDbContext

        Public Sub New(contexto As EmpresaDbContext)
            _contexto = contexto
        End Sub

        Public Function ObtenerTodos() As List(Of Cliente) _
            Implements IClienteRepository.ObtenerTodos

            Return _contexto.Clientes.
                AsNoTracking().
                OrderBy(Function(cliente) cliente.Id).
                ToList()

        End Function

        Public Function ObtenerPorId(id As Integer) As Cliente _
            Implements IClienteRepository.ObtenerPorId

            Return _contexto.Clientes.
                AsNoTracking().
                FirstOrDefault(Function(cliente) cliente.Id = id)

        End Function

        Public Function Crear(cliente As Cliente) As Cliente _
            Implements IClienteRepository.Crear

            _contexto.Clientes.Add(cliente)
            _contexto.SaveChanges()

            Return cliente

        End Function

        Public Function Actualizar(
            id As Integer,
            cliente As Cliente
        ) As Boolean Implements IClienteRepository.Actualizar

            Dim existente As Cliente = _contexto.Clientes.Find(id)

            If existente Is Nothing Then
                Return False
            End If

            existente.Nombre = cliente.Nombre
            existente.Apellido = cliente.Apellido
            existente.Email = cliente.Email
            existente.Telefono = cliente.Telefono

            _contexto.SaveChanges()

            Return True

        End Function

        Public Function Eliminar(id As Integer) As Boolean _
            Implements IClienteRepository.Eliminar

            Dim existente As Cliente = _contexto.Clientes.Find(id)

            If existente Is Nothing Then
                Return False
            End If

            _contexto.Clientes.Remove(existente)
            _contexto.SaveChanges()

            Return True

        End Function

    End Class

End Namespace