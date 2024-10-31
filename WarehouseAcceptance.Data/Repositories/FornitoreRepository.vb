Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.Data.Entity
Imports System.Linq
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Interfaces
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Models
Imports WarehouseAcceptance.Data.WarehouseAcceptance.Data.Context

Namespace WarehouseAcceptance.Data.Repositories
    Public Class FornitoreRepository
        Inherits BaseRepository(Of Fornitore)
        Implements IFornitoreRepository

        Public Sub New(context As WarehouseContext)
            MyBase.New(context)
        End Sub

        Public Overrides Function GetAll() As IEnumerable(Of Fornitore) Implements IFornitoreRepository.GetAll
            Return Context.Set(Of Fornitore)().ToList()
        End Function

        Public Function Find(predicate As Func(Of Fornitore, Boolean)) As IEnumerable(Of Fornitore) Implements IFornitoreRepository.Find
            Return Context.Set(Of Fornitore)().Where(predicate).ToList()
        End Function

        Public Overrides Function GetById(id As Integer) As Fornitore Implements IFornitoreRepository.GetById
            Return Context.Set(Of Fornitore)().Find(id)
        End Function

        Public Overrides Function Add(entity As Fornitore) As Fornitore Implements IFornitoreRepository.Add
            Return Context.Set(Of Fornitore)().Add(entity)
        End Function

        Public Overrides Sub Update(entity As Fornitore) Implements IFornitoreRepository.Update
            Context.Entry(entity).State = EntityState.Modified
        End Sub

        Public Overrides Sub Delete(entity As Fornitore) Implements IFornitoreRepository.Delete
            Context.Set(Of Fornitore)().Remove(entity)
        End Sub

        Public Overrides Sub SaveChanges() Implements IFornitoreRepository.SaveChanges
            Context.SaveChanges()
        End Sub
    End Class
End Namespace