Option Strict On
Option Explicit On

Imports System.Data.Entity
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Models

Namespace WarehouseAcceptance.Data.Context
    Public Class WarehouseContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("name=WarehouseConnection")
        End Sub

        Public Property Fornitori As DbSet(Of Fornitore)
        Public Property Templates As DbSet(Of Template)
        Public Property TemplateAree As DbSet(Of TemplateArea)

        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            MyBase.OnModelCreating(modelBuilder)

            ' Configurazione Fornitori (esistente)
            modelBuilder.Entity(Of Fornitore)() _
                .ToTable("Fornitori") _
                .HasKey(Function(f) f.ID)
            modelBuilder.Entity(Of Fornitore)() _
                .Property(Function(f) f.Codice) _
                .IsRequired() _
                .HasMaxLength(20)
            modelBuilder.Entity(Of Fornitore)() _
                .Property(Function(f) f.RagioneSociale) _
                .IsRequired() _
                .HasMaxLength(100)
            modelBuilder.Entity(Of Fornitore)() _
                .Property(Function(f) f.PartitaIVA) _
                .IsRequired() _
                .HasMaxLength(20)
            modelBuilder.Entity(Of Fornitore)() _
                .Property(Function(f) f.Email) _
                .HasMaxLength(100)
            modelBuilder.Entity(Of Fornitore)() _
                .Property(Function(f) f.Telefono) _
                .HasMaxLength(20)

            ' Configurazione Template
            modelBuilder.Entity(Of Template)() _
                .ToTable("Templates") _
                .HasKey(Function(t) t.Id)
            modelBuilder.Entity(Of Template)() _
                .Property(Function(t) t.Nome) _
                .IsRequired() _
                .HasMaxLength(100)
            modelBuilder.Entity(Of Template)() _
                .Property(Function(t) t.Descrizione) _
                .HasMaxLength(500)
            modelBuilder.Entity(Of Template)() _
                .Property(Function(t) t.DataCreazione) _
                .IsRequired()
            modelBuilder.Entity(Of Template)() _
                .Property(Function(t) t.Attivo) _
                .IsRequired()

            ' Configurazione TemplateArea
            modelBuilder.Entity(Of TemplateArea)() _
                .ToTable("TemplateAree") _
                .HasKey(Function(ta) ta.Id)
            modelBuilder.Entity(Of TemplateArea)() _
                .Property(Function(ta) ta.Nome) _
                .IsRequired() _
                .HasMaxLength(50)
            modelBuilder.Entity(Of TemplateArea)() _
                .Property(Function(ta) ta.TipoDato) _
                .IsRequired() _
                .HasMaxLength(20)
            modelBuilder.Entity(Of TemplateArea)() _
                .Property(Function(ta) ta.X) _
                .IsRequired()
            modelBuilder.Entity(Of TemplateArea)() _
                .Property(Function(ta) ta.Y) _
                .IsRequired()
            modelBuilder.Entity(Of TemplateArea)() _
                .Property(Function(ta) ta.Larghezza) _
                .IsRequired()
            modelBuilder.Entity(Of TemplateArea)() _
                .Property(Function(ta) ta.Altezza) _
                .IsRequired()

            ' Configurazione relazione Template-TemplateArea
            modelBuilder.Entity(Of TemplateArea)() _
                .HasRequired(Function(ta) ta.Template) _
                .WithMany(Function(t) t.Aree) _
                .HasForeignKey(Function(ta) ta.TemplateId)

            ' Configurazione relazione Template-Fornitore (many-to-many)
            modelBuilder.Entity(Of Template)() _
                .HasMany(Function(t) t.FornitoriAssociati) _
                .WithMany(Function(f) f.Templates) _
                .Map(Sub(m)
                         m.ToTable("TemplateFornitore")
                         m.MapLeftKey("TemplateId")
                         m.MapRightKey("FornitoreId")
                     End Sub)
        End Sub
    End Class
End Namespace