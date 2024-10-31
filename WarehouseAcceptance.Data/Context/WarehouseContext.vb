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

        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            MyBase.OnModelCreating(modelBuilder)

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
        End Sub
    End Class
End Namespace