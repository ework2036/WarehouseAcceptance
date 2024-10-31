Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Models

Namespace WarehouseAcceptance.Core.Interfaces
    Public Interface IFornitoreRepository
        Function GetById(id As Integer) As Fornitore
        Function GetAll() As IEnumerable(Of Fornitore)
        Function Find(predicate As Func(Of Fornitore, Boolean)) As IEnumerable(Of Fornitore)
        Function Add(fornitore As Fornitore) As Fornitore
        Sub Update(fornitore As Fornitore)
        Sub Delete(fornitore As Fornitore)
        Sub SaveChanges()
    End Interface
End Namespace