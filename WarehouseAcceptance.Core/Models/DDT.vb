Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic

Namespace WarehouseAcceptance.Core.Models
    Public Class DDT
        Public Property ID As Integer
        Public Property Numero As String
        Public Property Data As DateTime
        Public Property FornitoreID As Integer
        Public Property Fornitore As Fornitore
        Public Property DataCreazione As DateTime = DateTime.Now
        Public Property Righe As ICollection(Of RigaDDT)
    End Class
End Namespace