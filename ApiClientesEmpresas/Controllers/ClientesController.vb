Imports System.ComponentModel.DataAnnotations
Imports Microsoft.AspNetCore.Mvc
Imports ApiClientesEmpresa.Models
Imports ApiClientesEmpresa.Services

Namespace Controllers

    <ApiController>
    <Route("api/clientes")>
    Public Class ClientesController
        Inherits ControllerBase

        Private ReadOnly _servicio As IClienteService

        Public Sub New(servicio As IClienteService)
            _servicio = servicio
        End Sub

        <HttpGet>
        Public Function ObtenerTodos() As IActionResult

            Return Ok(_servicio.ObtenerTodos())

        End Function

        <HttpGet("{id:int}")>
        Public Function ObtenerPorId(id As Integer) As IActionResult

            Try
                Dim cliente As Cliente = _servicio.ObtenerPorId(id)

                If cliente Is Nothing Then
                    Return NotFound(
                        New With {.mensaje = "No se encontró el cliente."}
                    )
                End If

                Return Ok(cliente)

            Catch ex As ValidationException

                Return BadRequest(New With {.mensaje = ex.Message})

            End Try

        End Function

        <HttpPost>
        Public Function Crear(
            <FromBody> cliente As Cliente
        ) As IActionResult

            Try
                Dim creado As Cliente = _servicio.Crear(cliente)

                Return CreatedAtAction(
                    NameOf(ObtenerPorId),
                    New With {.id = creado.Id},
                    creado
                )

            Catch ex As ValidationException

                Return BadRequest(New With {.mensaje = ex.Message})

            End Try

        End Function

        <HttpPut("{id:int}")>
        Public Function Actualizar(
            id As Integer,
            <FromBody> cliente As Cliente
        ) As IActionResult

            Try
                Dim actualizado As Boolean =
                    _servicio.Actualizar(id, cliente)

                If Not actualizado Then
                    Return NotFound(
                        New With {.mensaje = "No se encontró el cliente."}
                    )
                End If

                Return NoContent()

            Catch ex As ValidationException

                Return BadRequest(New With {.mensaje = ex.Message})

            End Try

        End Function

        <HttpDelete("{id:int}")>
        Public Function Eliminar(id As Integer) As IActionResult

            Try
                Dim eliminado As Boolean = _servicio.Eliminar(id)

                If Not eliminado Then
                    Return NotFound(
                        New With {.mensaje = "No se encontró el cliente."}
                    )
                End If

                Return NoContent()

            Catch ex As ValidationException

                Return BadRequest(New With {.mensaje = ex.Message})

            End Try

        End Function

    End Class

End Namespace