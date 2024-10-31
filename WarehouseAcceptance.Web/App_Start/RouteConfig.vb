Option Strict On
Option Explicit On

Imports System.Web.Routing
Imports Microsoft.AspNet.FriendlyUrls

Public Module RouteConfig
    Public Sub RegisterRoutes(routes As RouteCollection)
        Dim settings As New FriendlyUrlSettings With {
            .AutoRedirectMode = RedirectMode.Permanent
        }
        routes.EnableFriendlyUrls(settings)
    End Sub
End Module