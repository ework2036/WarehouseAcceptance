Option Strict On
Option Explicit On

Namespace WarehouseAcceptance.Core.Models
    Public Class Fornitore
        Public Property ID As Integer
        Public Property Codice As String
        Public Property RagioneSociale As String
        Public Property PartitaIVA As String
        Public Property Email As String
        Public Property Telefono As String
        Public Property DataCreazione As DateTime = DateTime.Now
    End Class
End Namespace