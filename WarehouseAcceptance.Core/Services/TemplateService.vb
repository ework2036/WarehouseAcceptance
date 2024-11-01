Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Models
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Interfaces

Namespace WarehouseAcceptance.Core.WarehouseAcceptance.Core.Services
    Public Class TemplateService
        Implements ITemplateService

        Private ReadOnly _templateRepository As ITemplateRepository

        Public Sub New(templateRepository As ITemplateRepository)
            _templateRepository = templateRepository
        End Sub

        Public Function GetAllTemplates() As IEnumerable(Of Template) Implements ITemplateService.GetAllTemplates
            Return _templateRepository.GetAll()
        End Function

        Public Function GetTemplateById(ByVal id As Integer) As Template Implements ITemplateService.GetTemplateById
            Return _templateRepository.GetById(id)
        End Function

        Public Sub CreateTemplate(ByVal template As Template) Implements ITemplateService.CreateTemplate
            If template Is Nothing Then
                Throw New ArgumentNullException(NameOf(template))
            End If

            template.DataCreazione = DateTime.Now
            template.Attivo = True
            _templateRepository.Insert(template)
        End Sub

        Public Sub UpdateTemplate(ByVal template As Template) Implements ITemplateService.UpdateTemplate
            If template Is Nothing Then
                Throw New ArgumentNullException(NameOf(template))
            End If

            _templateRepository.Update(template)
        End Sub

        Public Sub DeleteTemplate(ByVal id As Integer) Implements ITemplateService.DeleteTemplate
            _templateRepository.Delete(id)
        End Sub

        Public Function GetTemplatesByFornitore(ByVal fornitoreId As Integer) As IEnumerable(Of Template) Implements ITemplateService.GetTemplatesByFornitore
            Return _templateRepository.GetByFornitore(fornitoreId)
        End Function

        Public Function GetActiveTemplates() As IEnumerable(Of Template) Implements ITemplateService.GetActiveTemplates
            Return _templateRepository.GetActive()
        End Function

        Public Sub AssociaTemplateAFornitore(ByVal templateId As Integer, ByVal fornitoreId As Integer) Implements ITemplateService.AssociaTemplateAFornitore
            _templateRepository.AssociaFornitore(templateId, fornitoreId)
        End Sub

        Public Sub DisassociaTemplateAFornitore(ByVal templateId As Integer, ByVal fornitoreId As Integer) Implements ITemplateService.DisassociaTemplateAFornitore
            _templateRepository.DisassociaFornitore(templateId, fornitoreId)
        End Sub

        Public Function GetAreeTemplate(ByVal templateId As Integer) As IEnumerable(Of TemplateArea) Implements ITemplateService.GetAreeTemplate
            Dim template = GetTemplateById(templateId)
            Return If(template?.Aree, New List(Of TemplateArea)())
        End Function

        Public Sub AggiungiAreaTemplate(ByVal templateId As Integer, ByVal area As TemplateArea) Implements ITemplateService.AggiungiAreaTemplate
            If area Is Nothing Then
                Throw New ArgumentNullException(NameOf(area))
            End If

            Dim template = GetTemplateById(templateId)
            If template IsNot Nothing Then
                area.TemplateId = templateId
                template.Aree.Add(area)
                UpdateTemplate(template)
            End If
        End Sub

        Public Sub ModificaAreaTemplate(ByVal area As TemplateArea) Implements ITemplateService.ModificaAreaTemplate
            If area Is Nothing Then
                Throw New ArgumentNullException(NameOf(area))
            End If

            Dim template = GetTemplateById(area.TemplateId)
            If template IsNot Nothing Then
                Dim areaEsistente = template.Aree.FirstOrDefault(Function(a) a.Id = area.Id)
                If areaEsistente IsNot Nothing Then
                    ' Aggiorna le proprietà dell'area
                    areaEsistente.Nome = area.Nome
                    areaEsistente.TipoDato = area.TipoDato
                    areaEsistente.X = area.X
                    areaEsistente.Y = area.Y
                    areaEsistente.Larghezza = area.Larghezza
                    areaEsistente.Altezza = area.Altezza
                    UpdateTemplate(template)
                End If
            End If
        End Sub

        Public Sub RimuoviAreaTemplate(ByVal areaId As Integer) Implements ITemplateService.RimuoviAreaTemplate
            Dim template = _templateRepository.GetAll().FirstOrDefault(Function(t) t.Aree.Any(Function(a) a.Id = areaId))
            If template IsNot Nothing Then
                Dim area = template.Aree.First(Function(a) a.Id = areaId)
                template.Aree.Remove(area)
                UpdateTemplate(template)
            End If
        End Sub
    End Class
End Namespace
