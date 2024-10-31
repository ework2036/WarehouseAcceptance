Option Strict On
Option Explicit On

Imports System.Web
Imports System.Web.Optimization
Imports System.Web.Routing
Imports WarehouseAcceptance.Web.WarehouseAcceptance.Web.Infrastructure

Public Class Global_asax
    Inherits HttpApplication

    Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Inizializza Unity
        Dim container = UnityConfig.Container

        ' Registra le route
        RouteConfig.RegisterRoutes(RouteTable.Routes)

        ' Registra i bundle
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub
End Class