Imports System
Imports System.Web.UI
Imports Unity
Imports Unity.Resolution
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Interfaces
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Models
Imports WarehouseAcceptance.Web.WarehouseAcceptance.Web.Infrastructure

Public Class GestioneFornitori
    Inherits System.Web.UI.Page

    Private ReadOnly _fornitoreService As IFornitoreService
    Private _selectedID As Integer = 0

    Public Sub New()
        Try
            _fornitoreService = DirectCast(UnityConfig.Container.Resolve(GetType(IFornitoreService)), IFornitoreService)
        Catch ex As Exception
            Throw New InvalidOperationException("Errore durante la risoluzione del servizio fornitori.", ex)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CaricaFornitori()
        End If
    End Sub

    Private Sub CaricaFornitori()
        Try
            Dim termineRicerca As String = txtRicerca.Text.Trim()
            Dim fornitori = _fornitoreService.CercaFornitori(termineRicerca)
            gvFornitori.DataSource = fornitori
            gvFornitori.DataBind()
        Catch ex As Exception
            MostraMessaggio("Errore durante il caricamento dei fornitori: " & ex.Message, True)
        End Try
    End Sub

    Protected Sub btnSalva_Click(sender As Object, e As EventArgs) Handles btnSalva.Click
        ' Riabilita i validator prima del salvataggio
        rfvCodice.Enabled = True
        rfvRagioneSociale.Enabled = True
        rfvPartitaIVA.Enabled = True
        revEmail.Enabled = True

        If Not Page.IsValid Then
            Return
        End If

        Try
            Dim fornitore As New Fornitore With {
                .ID = _selectedID,
                .Codice = txtCodice.Text.Trim(),
                .RagioneSociale = txtRagioneSociale.Text.Trim(),
                .PartitaIVA = txtPartitaIVA.Text.Trim(),
                .Email = txtEmail.Text.Trim(),
                .Telefono = txtTelefono.Text.Trim()
            }

            If _selectedID = 0 Then
                _fornitoreService.InserisciFornitore(fornitore)
                MostraMessaggio("Fornitore inserito con successo")
            Else
                _fornitoreService.AggiornaFornitore(fornitore)
                MostraMessaggio("Fornitore aggiornato con successo")
            End If

            PulisciForm()
            CaricaFornitori()

        Catch ex As Exception
            MostraMessaggio("Errore durante il salvataggio: " & ex.Message, True)
        End Try
    End Sub

    Protected Sub btnRicerca_Click(sender As Object, e As EventArgs) Handles btnRicerca.Click
        CaricaFornitori()
    End Sub

    Protected Sub gvFornitori_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvFornitori.SelectedIndexChanged
        Try
            _selectedID = Convert.ToInt32(gvFornitori.SelectedDataKey.Value)
            Dim fornitore = _fornitoreService.GetFornitore(_selectedID)

            If fornitore IsNot Nothing Then
                txtCodice.Text = fornitore.Codice
                txtRagioneSociale.Text = fornitore.RagioneSociale
                txtPartitaIVA.Text = fornitore.PartitaIVA
                txtEmail.Text = fornitore.Email
                txtTelefono.Text = fornitore.Telefono
                btnElimina.Visible = True

                ' Disabilita temporaneamente i validator
                rfvCodice.Enabled = False
                rfvRagioneSociale.Enabled = False
                rfvPartitaIVA.Enabled = False
                revEmail.Enabled = False
            End If
        Catch ex As Exception
            MostraMessaggio("Errore durante il caricamento del fornitore: " & ex.Message, True)
        End Try
    End Sub

    Protected Sub btnElimina_Click(sender As Object, e As EventArgs) Handles btnElimina.Click
        Try
            If _selectedID > 0 Then
                _fornitoreService.EliminaFornitore(_selectedID)
                MostraMessaggio("Fornitore eliminato con successo")
                PulisciForm()
                CaricaFornitori()
            End If
        Catch ex As Exception
            MostraMessaggio("Errore durante l'eliminazione: " & ex.Message, True)
        End Try
    End Sub

    Protected Sub btnAnnulla_Click(sender As Object, e As EventArgs) Handles btnAnnulla.Click
        PulisciForm()
    End Sub

    Private Sub PulisciForm()
        _selectedID = 0
        txtCodice.Text = String.Empty
        txtRagioneSociale.Text = String.Empty
        txtPartitaIVA.Text = String.Empty
        txtEmail.Text = String.Empty
        txtTelefono.Text = String.Empty
        btnElimina.Visible = False
        lblMessaggio.Visible = False
    End Sub

    Private Sub MostraMessaggio(messaggio As String, Optional isError As Boolean = False)
        lblMessaggio.Text = messaggio
        lblMessaggio.CssClass = If(isError, "alert alert-danger", "alert alert-success")
        lblMessaggio.Visible = True
    End Sub
End Class