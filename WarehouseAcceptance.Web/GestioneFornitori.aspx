<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="GestioneFornitori.aspx.vb" Inherits="WarehouseAcceptance.Web.GestioneFornitori" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4 mb-4">Gestione Fornitori</h2>

        <div class="row mb-4">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">Inserimento/Modifica Fornitore</h5>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <asp:Label ID="lblCodice" runat="server" CssClass="form-label" Text="Codice:" />
                            <asp:TextBox ID="txtCodice" runat="server" CssClass="form-control" MaxLength="20" />
                            <asp:RequiredFieldValidator ID="rfvCodice" runat="server" 
                                ControlToValidate="txtCodice" 
                                ErrorMessage="Il codice è obbligatorio" 
                                CssClass="text-danger" 
                                Display="Dynamic" />
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="lblRagioneSociale" runat="server" CssClass="form-label" Text="Ragione Sociale:" />
                            <asp:TextBox ID="txtRagioneSociale" runat="server" CssClass="form-control" MaxLength="100" />
                            <asp:RequiredFieldValidator ID="rfvRagioneSociale" runat="server" 
                                ControlToValidate="txtRagioneSociale" 
                                ErrorMessage="La ragione sociale è obbligatoria" 
                                CssClass="text-danger" 
                                Display="Dynamic" />
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="lblPartitaIVA" runat="server" CssClass="form-label" Text="Partita IVA:" />
                            <asp:TextBox ID="txtPartitaIVA" runat="server" CssClass="form-control" MaxLength="20" />
                            <asp:RequiredFieldValidator ID="rfvPartitaIVA" runat="server" 
                                ControlToValidate="txtPartitaIVA" 
                                ErrorMessage="La partita IVA è obbligatoria" 
                                CssClass="text-danger" 
                                Display="Dynamic" />
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="lblEmail" runat="server" CssClass="form-label" Text="Email:" />
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="100" />
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                ControlToValidate="txtEmail" 
                                ErrorMessage="Email non valida" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                CssClass="text-danger" 
                                Display="Dynamic" />
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="lblTelefono" runat="server" CssClass="form-label" Text="Telefono:" />
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="20" />
                        </div>

                        <div class="mb-3">
                            <asp:Button ID="btnSalva" runat="server" Text="Salva" CssClass="btn btn-primary" />
                            <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" CssClass="btn btn-secondary" CausesValidation="false" />
                            <asp:Button ID="btnElimina" runat="server" Text="Elimina" CssClass="btn btn-danger" CausesValidation="false" 
                                OnClientClick="return confirm('Sei sicuro di voler eliminare questo fornitore?');" Visible="false" />
                        </div>

                        <asp:Label ID="lblMessaggio" runat="server" CssClass="alert alert-info" Visible="false" />
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">Ricerca Fornitori</h5>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <asp:TextBox ID="txtRicerca" runat="server" CssClass="form-control" placeholder="Cerca per codice o ragione sociale..." />
                        </div>
                        <div class="mb-3">
                            <asp:Button ID="btnRicerca" runat="server" Text="Cerca" CssClass="btn btn-primary" CausesValidation="false" />
                        </div>
                    </div>
                </div>

                <div class="card mt-3">
                    <div class="card-header">
                        <h5 class="card-title mb-0">Lista Fornitori</h5>
                    </div>
                    <div class="card-body">
                        -<asp:GridView ID="gvFornitori" runat="server" AutoGenerateColumns="False" 
    CssClass="table table-striped table-bordered table-hover" 
    DataKeyNames="ID" 
    AllowPaging="True" 
    PageSize="10"
    OnSelectedIndexChanged="gvFornitori_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="Codice" HeaderText="Codice" />
        <asp:BoundField DataField="RagioneSociale" HeaderText="Ragione Sociale" />
        <asp:BoundField DataField="PartitaIVA" HeaderText="P.IVA" />
        <asp:TemplateField HeaderText="Azioni">
            <ItemTemplate>
                <asp:LinkButton ID="lnkModifica" runat="server" 
                    CommandName="Select" 
                    CausesValidation="false"
                    CssClass="btn btn-sm btn-primary"
                    Text="Modifica" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>