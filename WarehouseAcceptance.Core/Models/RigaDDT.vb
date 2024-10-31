Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic

Namespace WarehouseAcceptance.Core.Models
    Public Class RigaDDT
        Public Property ID As Integer
        Public Property DDTID As Integer
        Public Property DDT As DDT
        Public Property CodiceArticolo As String
        Public Property Descrizione As String
        Public Property QuantitaDocumento As Decimal
        Public Property QuantitaVerificata As Decimal?
        Public Property StatoConformita As Integer  ' 0=Non verificato, 1=Conforme, 2=Non Conforme
        Public Property Note As String

        Public ReadOnly Property StatoConformitaDescrizione As String
            Get
                Select Case StatoConformita
                    Case 0
                        Return "Non verificato"
                    Case 1
                        Return "Conforme"
                    Case 2
                        Return "Non Conforme"
                    Case Else
                        Return "Stato non valido"
                End Select
            End Get
        End Property
    End Class
End Namespace