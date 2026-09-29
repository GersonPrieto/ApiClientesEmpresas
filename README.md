# API de Clientes

**Universidad:** Universidad Autónoma de Asunción
**Materia:** Programación Orientada por Eventos Avanzada - Visual Basic  
**Alumno:** Gerson Prieto Franco  


## Descripción

Este proyecto corresponde al primer parcial de la materia.
Consiste en una API que permite registrar, listar, buscar, modificar
y eliminar clientes. Los datos se guardan en la base de datos
EmpresaDB de SQL Server.

## Herramientas utilizadas

- Visual Studio 2026.
- Visual Basic .NET y ASP.NET Core con .NET 10.
- Entity Framework Core 10.
- SQL Server 2025 y SQL Server Management Studio.
- Postman para realizar las pruebas.

## Cómo ejecutar el proyecto

1. Descargar o clonar el repositorio.
2. Ejecutar el archivo sql/EmpresaDB_Clientes.sql en SQL Server.
3. Abrir la solución en Visual Studio.
4. Revisar la cadena de conexión en appsettings.json y ajustar
   el servidor si corresponde. La configuración incluida utiliza
   localhost y autenticación de Windows.
5. Restaurar los paquetes NuGet y compilar el proyecto.
6. Ejecutar con Ctrl + F5.



La dirección de la API es http://localhost:5080.

## Endpoints

| Método | Ruta | Función |
|---|---|---|
| GET | /api/clientes | Listar todos los clientes. |
| GET | /api/clientes/{id} | Buscar un cliente por su ID. |
| POST | /api/clientes | Registrar un cliente. |
| PUT | /api/clientes/{id} | Modificar un cliente. |
| DELETE | /api/clientes/{id} | Eliminar un cliente. |

Para registrar o modificar se envían los campos nombre, apellido,
email y telefono en formato JSON. El ID se genera automáticamente
al registrar.

## Pruebas realizadas

Hice las pruebas con Postman: registro, listado, búsqueda,
modificación y eliminación de clientes. También comprobé las
respuestas ante un nombre vacío, un correo inválido y un ID igual
a cero.

Para verificar que los datos se guardaban, reinicié la aplicación
y consulté nuevamente el cliente. Además, revisé el registro
directamente en SQL Server.

Las capturas están en la carpeta evidencias y la colección de
Postman está en la carpeta postman.

// Para repetir las pruebas, es mejor registrar un cliente nuevo.
Ya que elimine uno de los clientes al finalizar la prueba.