Option Strict On
Option Explicit On

Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports WarehouseAcceptance.Data.WarehouseAcceptance.Data.Context

Namespace WarehouseAcceptance.Data.Migrations
    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of WarehouseContext)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As WarehouseContext)
            '  This method will be called after migrating to the latest version.
        End Sub
    End Class
End Namespace