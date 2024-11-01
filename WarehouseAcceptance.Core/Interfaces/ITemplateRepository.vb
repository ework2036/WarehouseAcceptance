Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Models

Namespace WarehouseAcceptance.Core.Interfaces
    Public Interface ITemplateRepository
        ' Operazioni CRUD base
        Function GetAll() As IEnumerable(Of Template)
        Function GetById(ByVal id As Integer) As Template
        Sub Insert(ByVal template As Template)
        Sub Update(ByVal template As Template)
        Sub Delete(ByVal id As Integer)

        ' Operazioni specifiche per template
        Function GetByFornitore(ByVal fornitoreId As Integer) As IEnumerable(Of Template)
        Function GetActive() As IEnumerable(Of Template)
        Sub AssociaFornitore(ByVal templateId As Integer, ByVal fornitoreId As Integer)
        Sub DisassociaFornitore(ByVal templateId As Integer, ByVal fornitoreId As Integer)
    End Interface
End Namespace