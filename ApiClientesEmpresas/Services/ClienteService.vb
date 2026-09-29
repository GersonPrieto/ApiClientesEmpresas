Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports ApiClientesEmpresa.Models
Imports ApiClientesEmpresa.Repositories

Namespace Services

    Public Class ClienteService
        Implements IClienteService

        Private ReadOnly _repositorio As IClienteRepository

        Public Sub New(repositorio As IClienteRepository)
            _repositorio = repositorio
        End Sub

        Public Function ObtenerTodos() As List(Of Cliente) _
            Implements IClienteService.ObtenerTodos

            Return _repositorio.ObtenerTodos()

        End Function

        Public Function ObtenerPorId(id As Integer) As Cliente _
            Implements IClienteService.ObtenerPorId

            ValidarId(id)

            Return _repositorio.ObtenerPorId(id)

        End Function

        Public Function Crear(cliente As Cliente) As Cliente _
            Implements IClienteService.Crear

            Dim preparado As Cliente = PrepararCliente(cliente)

            If cliente.Id <> 0 Then
                Throw New ValidationException(
                    "El identificador se genera automáticamente. " &
                    "Para registrar un cliente, omití el Id o enviá 0."
                )
            End If

            Return _repositorio.Crear(preparado)

        End Function

        Public Function Actualizar(
            id As Integer,
            cliente As Cliente
        ) As Boolean Implements IClienteService.Actualizar

            ValidarId(id)

            Dim preparado As Cliente = PrepararCliente(cliente)

            If cliente.Id <> 0 AndAlso cliente.Id <> id Then
                Throw New ValidationException(
                    "El Id del cliente debe coincidir con el de la URL."
                )
            End If

            Return _repositorio.Actualizar(id, preparado)

        End Function

        Public Function Eliminar(id As Integer) As Boolean _
            Implements IClienteService.Eliminar

            ValidarId(id)

            Return _repositorio.Eliminar(id)

        End Function

        Private Shared Sub ValidarId(id As Integer)

            If id <= 0 Then
                Throw New ValidationException(
                    "El identificador debe ser mayor que cero."
                )
            End If

        End Sub

        Private Shared Function PrepararCliente(
            cliente As Cliente
        ) As Cliente

            If cliente Is Nothing Then
                Throw New ValidationException(
                    "Se deben proporcionar los datos del cliente."
                )
            End If

            Dim preparado As New Cliente With {
                .Nombre = If(cliente.Nombre, String.Empty).Trim(),
                .Apellido = If(cliente.Apellido, String.Empty).Trim(),
                .Email = If(cliente.Email, String.Empty).Trim(),
                .Telefono = If(
                    String.IsNullOrWhiteSpace(cliente.Telefono),
                    Nothing,
                    cliente.Telefono.Trim()
                )
            }

            Validator.ValidateObject(
                preparado,
                New ValidationContext(preparado),
                validateAllProperties:=True
            )

            Return preparado

        End Function

    End Class

End Namespace