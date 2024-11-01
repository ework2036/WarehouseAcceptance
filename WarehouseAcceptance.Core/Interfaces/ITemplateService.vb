Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Models

Namespace WarehouseAcceptance.Core.Interfaces
    Public Interface ITemplateService
        ' Operazioni CRUD base
        Function GetAllTemplates() As IEnumerable(Of Template)
        Function GetTemplateById(ByVal id As Integer) As Template
        Sub CreateTemplate(ByVal template As Template)
        Sub UpdateTemplate(ByVal template As Template)
        Sub DeleteTemplate(ByVal id As Integer)

        ' Operazioni specifiche
        Function GetTemplatesByFornitore(ByVal fornitoreId As Integer) As IEnumerable(Of Template)
        Function GetActiveTemplates() As IEnumerable(Of Template)
        Sub AssociaTemplateAFornitore(ByVal templateId As Integer, ByVal fornitoreId As Integer)
        Sub DisassociaTemplateAFornitore(ByVal templateId As Integer, ByVal fornitoreId As Integer)

        ' Gestione Aree Template
        Function GetAreeTemplate(ByVal templateId As Integer) As IEnumerable(Of TemplateArea)
        Sub AggiungiAreaTemplate(ByVal templateId As Integer, ByVal area As TemplateArea)
        Sub ModificaAreaTemplate(ByVal area As TemplateArea)
        Sub RimuoviAreaTemplate(ByVal areaId As Integer)
    End Interface
End Namespace
