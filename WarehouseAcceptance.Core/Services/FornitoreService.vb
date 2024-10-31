Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Interfaces
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Models

Namespace WarehouseAcceptance.Core.Services
    Public Class FornitoreService
        Implements IFornitoreService

        Private ReadOnly _fornitoreRepository As IFornitoreRepository

        Public Sub New(fornitoreRepository As IFornitoreRepository)
            If fornitoreRepository Is Nothing Then
                Throw New ArgumentNullException(NameOf(fornitoreRepository))
            End If
            _fornitoreRepository = fornitoreRepository
        End Sub

        Public Function GetFornitore(id As Integer) As Fornitore Implements IFornitoreService.GetFornitore
            Return _fornitoreRepository.GetById(id)
        End Function

        Public Function CercaFornitori(Optional searchTerm As String = "") As IEnumerable(Of Fornitore) Implements IFornitoreService.CercaFornitori
            If String.IsNullOrWhiteSpace(searchTerm) Then
                Return _fornitoreRepository.GetAll()
            End If
            Return _fornitoreRepository.Find(Function(f) f.Codice.Contains(searchTerm) OrElse f.RagioneSociale.Contains(searchTerm))
        End Function

        Public Function InserisciFornitore(fornitore As Fornitore) As Integer Implements IFornitoreService.InserisciFornitore
            Dim nuovoFornitore = _fornitoreRepository.Add(fornitore)
            _fornitoreRepository.SaveChanges()
            Return nuovoFornitore.ID
        End Function

        Public Sub AggiornaFornitore(fornitore As Fornitore) Implements IFornitoreService.AggiornaFornitore
            _fornitoreRepository.Update(fornitore)
            _fornitoreRepository.SaveChanges()
        End Sub

        Public Sub EliminaFornitore(id As Integer) Implements IFornitoreService.EliminaFornitore
            Dim fornitore = _fornitoreRepository.GetById(id)
            If fornitore IsNot Nothing Then
                _fornitoreRepository.Delete(fornitore)
                _fornitoreRepository.SaveChanges()
            End If
        End Sub
    End Class
End Namespace