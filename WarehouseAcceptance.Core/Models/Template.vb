Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace WarehouseAcceptance.Core.Models
    <Table("Templates")>
    Public Class Template
        Public Sub New()
            Aree = New List(Of TemplateArea)
            FornitoriAssociati = New List(Of Fornitore)
            DataCreazione = DateTime.Now
            Attivo = True
        End Sub

        <Key>
        Public Property Id As Integer

        <Required>
        <StringLength(100)>
        <Display(Name:="Nome Template")>
        Public Property Nome As String

        <StringLength(500)>
        <Display(Name:="Descrizione")>
        Public Property Descrizione As String

        <Required>
        <Display(Name:="Data Creazione")>
        <Column(TypeName:="datetime2")>
        Public Property DataCreazione As DateTime

        <Required>
        <Display(Name:="Attivo")>
        Public Property Attivo As Boolean

        ' Relazioni
        Public Overridable Property Aree As List(Of TemplateArea)
        Public Overridable Property FornitoriAssociati As List(Of Fornitore)
    End Class

    <Table("TemplateAree")>
    Public Class TemplateArea
        <Key>
        Public Property Id As Integer

        <Required>
        <StringLength(50)>
        <Display(Name:="Nome Area")>
        Public Property Nome As String

        <Required>
        <StringLength(20)>
        <Display(Name:="Tipo Dato")>
        Public Property TipoDato As String

        <Required>
        <Display(Name:="Coordinata X")>
        Public Property X As Integer

        <Required>
        <Display(Name:="Coordinata Y")>
        Public Property Y As Integer

        <Required>
        <Display(Name:="Larghezza")>
        Public Property Larghezza As Integer

        <Required>
        <Display(Name:="Altezza")>
        Public Property Altezza As Integer

        ' Chiave esterna per Template
        <Required>
        Public Property TemplateId As Integer

        <ForeignKey("TemplateId")>
        Public Overridable Property Template As Template
    End Class
End Namespace