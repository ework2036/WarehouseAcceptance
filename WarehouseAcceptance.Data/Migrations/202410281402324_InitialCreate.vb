Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialCreate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.DDT",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Numero = c.String(),
                        .Data = c.DateTime(nullable := False),
                        .FornitoreID = c.Int(nullable := False),
                        .DataCreazione = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Fornitori", Function(t) t.FornitoreID, cascadeDelete := True) _
                .Index(Function(t) t.FornitoreID)
            
            CreateTable(
                "dbo.Fornitori",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Codice = c.String(),
                        .RagioneSociale = c.String(),
                        .PartitaIVA = c.String(),
                        .Email = c.String(),
                        .Telefono = c.String(),
                        .DataCreazione = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.RigheDDT",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .DDTID = c.Int(nullable := False),
                        .CodiceArticolo = c.String(),
                        .Descrizione = c.String(),
                        .QuantitaDocumento = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .QuantitaVerificata = c.Decimal(precision := 18, scale := 2),
                        .StatoConformita = c.Int(nullable := False),
                        .Note = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.DDT", Function(t) t.DDTID, cascadeDelete := True) _
                .Index(Function(t) t.DDTID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.RigheDDT", "DDTID", "dbo.DDT")
            DropForeignKey("dbo.DDT", "FornitoreID", "dbo.Fornitori")
            DropIndex("dbo.RigheDDT", New String() { "DDTID" })
            DropIndex("dbo.DDT", New String() { "FornitoreID" })
            DropTable("dbo.RigheDDT")
            DropTable("dbo.Fornitori")
            DropTable("dbo.DDT")
        End Sub
    End Class
End Namespace
