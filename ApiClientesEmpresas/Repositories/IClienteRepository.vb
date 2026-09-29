Imports System.Collections.Generic
Imports ApiClientesEmpresa.Models

Namespace Repositories

    Public Interface IClienteRepository

        Function ObtenerTodos() As List(Of Cliente)

        Function ObtenerPorId(id As Integer) As Cliente

        Function Crear(cliente As Cliente) As Cliente

        Function Actualizar(id As Integer, cliente As Cliente) As Boolean

        Function Eliminar(id As Integer) As Boolean

    End Interface

End Namespace