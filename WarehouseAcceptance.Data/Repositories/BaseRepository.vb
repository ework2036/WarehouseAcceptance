Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.Data.Entity
Imports WarehouseAcceptance.Data.WarehouseAcceptance.Data.Context

Namespace WarehouseAcceptance.Data.Repositories
    Public MustInherit Class BaseRepository(Of T As Class)
        Protected ReadOnly Context As WarehouseContext

        Public Sub New(context As WarehouseContext)
            If context Is Nothing Then
                Throw New ArgumentNullException(NameOf(context))
            End If
            Me.Context = context
        End Sub

        Public MustOverride Function GetAll() As IEnumerable(Of T)
        Public MustOverride Function GetById(id As Integer) As T
        Public MustOverride Function Add(entity As T) As T
        Public MustOverride Sub Update(entity As T)
        Public MustOverride Sub Delete(entity As T)
        Public MustOverride Sub SaveChanges()
    End Class
End Namespace