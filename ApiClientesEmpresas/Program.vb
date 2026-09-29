Imports System
Imports System.Linq
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports ApiClientesEmpresa.Data
Imports ApiClientesEmpresa.Repositories
Imports ApiClientesEmpresa.Services

Module Program

    Sub Main(args As String())

        Dim builder = WebApplication.CreateBuilder(args)

        builder.Services.AddControllers()

        Dim cadenaConexion As String =
            builder.Configuration.GetConnectionString("EmpresaDB")

        If String.IsNullOrWhiteSpace(cadenaConexion) Then
            Throw New InvalidOperationException(
                "No se encontró la cadena de conexión EmpresaDB."
            )
        End If

        builder.Services.AddDbContext(Of EmpresaDbContext)(
            Sub(options)
                options.UseSqlServer(cadenaConexion)
            End Sub
        )

        builder.Services.AddScoped(Of IClienteRepository, ClienteRepository)()
        builder.Services.AddScoped(Of IClienteService, ClienteService)()

        Dim app = builder.Build()

        app.MapControllers()


        'app.MapGet(
        '    "/",
        '    New Func(Of String)(
        '        Function() "API de clientes en funcionamiento."
        '    )
        ')

        '        app.MapGet(
        '    "/diagnostico/conexion",
        '    New Func(Of IClienteService, String)(
        '        Function(servicio)

        '            Dim clientes = servicio.ObtenerTodos()

        '            Return $"Service y Repository funcionando. Clientes registrados: {clientes.Count}"

        '        End Function
        '    )
        ')




        app.Run("http://localhost:5080")

    End Sub

End Module