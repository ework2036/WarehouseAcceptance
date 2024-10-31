Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Models

Namespace WarehouseAcceptance.Core.Interfaces
    Public Interface IFornitoreService
        Function GetFornitore(id As Integer) As Fornitore
        Function CercaFornitori(Optional searchTerm As String = "") As IEnumerable(Of Fornitore)
        Function InserisciFornitore(fornitore As Fornitore) As Integer
        Sub AggiornaFornitore(fornitore As Fornitore)
        Sub EliminaFornitore(id As Integer)
    End Interface
End Namespace