Option Strict On
Option Explicit On

Imports System.Data.Entity
Imports System.Collections.Generic
Imports System.Linq
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Models
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Interfaces
Imports WarehouseAcceptance.Data.WarehouseAcceptance.Data.Context

Namespace WarehouseAcceptance.Data.WarehouseAcceptance.Data.Repositories
    Public Class TemplateRepository
        Implements ITemplateRepository

        Private ReadOnly _context As WarehouseContext

        Public Sub New(context As WarehouseContext)
            _context = context
        End Sub

        Public Function GetAll() As IEnumerable(Of Template) Implements ITemplateRepository.GetAll
            Return _context.Templates _
                .Include(Function(t) t.Aree) _
                .Include(Function(t) t.FornitoriAssociati) _
                .ToList()
        End Function

        Public Function GetById(ByVal id As Integer) As Template Implements ITemplateRepository.GetById
            Return _context.Templates _
                .Include(Function(t) t.Aree) _
                .Include(Function(t) t.FornitoriAssociati) _
                .FirstOrDefault(Function(t) t.Id = id)
        End Function

        Public Sub Insert(ByVal template As Template) Implements ITemplateRepository.Insert
            _context.Templates.Add(template)
            _context.SaveChanges()
        End Sub

        Public Sub Update(ByVal template As Template) Implements ITemplateRepository.Update
            _context.Entry(template).State = EntityState.Modified

            ' Aggiorna anche le aree del template
            For Each area In template.Aree
                If area.Id = 0 Then
                    _context.Entry(area).State = EntityState.Added
                Else
                    _context.Entry(area).State = EntityState.Modified
                End If
            Next

            _context.SaveChanges()
        End Sub

        Public Sub Delete(ByVal id As Integer) Implements ITemplateRepository.Delete
            Dim template = _context.Templates.Find(id)
            If template IsNot Nothing Then
                _context.Templates.Remove(template)
                _context.SaveChanges()
            End If
        End Sub

        Public Function GetByFornitore(ByVal fornitoreId As Integer) As IEnumerable(Of Template) Implements ITemplateRepository.GetByFornitore
            Return _context.Templates _
                .Include(Function(t) t.Aree) _
                .Include(Function(t) t.FornitoriAssociati) _
                .Where(Function(t) t.FornitoriAssociati.Any(Function(f) f.ID = fornitoreId)) _
                .ToList()
        End Function

        Public Function GetActive() As IEnumerable(Of Template) Implements ITemplateRepository.GetActive
            Return _context.Templates _
                .Include(Function(t) t.Aree) _
                .Include(Function(t) t.FornitoriAssociati) _
                .Where(Function(t) t.Attivo = True) _
                .ToList()
        End Function

        Public Sub AssociaFornitore(ByVal templateId As Integer, ByVal fornitoreId As Integer) Implements ITemplateRepository.AssociaFornitore
            Dim template = GetById(templateId)
            Dim fornitore = _context.Fornitori.Find(fornitoreId)

            If template IsNot Nothing AndAlso fornitore IsNot Nothing Then
                template.FornitoriAssociati.Add(fornitore)
                _context.SaveChanges()
            End If
        End Sub

        Public Sub DisassociaFornitore(ByVal templateId As Integer, ByVal fornitoreId As Integer) Implements ITemplateRepository.DisassociaFornitore
            Dim template = GetById(templateId)
            Dim fornitore = _context.Fornitori.Find(fornitoreId)

            If template IsNot Nothing AndAlso fornitore IsNot Nothing Then
                template.FornitoriAssociati.Remove(fornitore)
                _context.SaveChanges()
            End If
        End Sub
    End Class
End Namespace