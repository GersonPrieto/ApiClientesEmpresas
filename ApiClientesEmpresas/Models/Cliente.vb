Imports System.ComponentModel.DataAnnotations

Namespace Models

    Public Class Cliente

        Public Property Id As Integer

        <Required(ErrorMessage:="El nombre es obligatorio.")>
        <StringLength(100, ErrorMessage:="El nombre admite hasta 100 caracteres.")>
        Public Property Nombre As String

        <Required(ErrorMessage:="El apellido es obligatorio.")>
        <StringLength(100, ErrorMessage:="El apellido admite hasta 100 caracteres.")>
        Public Property Apellido As String

        <Required(ErrorMessage:="El correo electrónico es obligatorio.")>
        <StringLength(150, ErrorMessage:="El correo admite hasta 150 caracteres.")>
        <EmailAddress(ErrorMessage:="El correo electrónico no tiene un formato válido.")>
        Public Property Email As String

        <StringLength(30, ErrorMessage:="El teléfono admite hasta 30 caracteres.")>
        Public Property Telefono As String

    End Class

End Namespace