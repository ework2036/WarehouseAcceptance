Option Strict On
Option Explicit On

Imports System.Web.Optimization
Imports System.Web.UI

Public NotInheritable Class BundleConfig
    Private Sub New()
    End Sub

    Public Shared Sub RegisterBundles(bundles As BundleCollection)
        RegisterJQueryScriptManager()

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/WebFormsJs").Include(
            "~/Scripts/WebForms/WebForms.js",
            "~/Scripts/WebForms/WebUIValidation.js",
            "~/Scripts/WebForms/MenuStandards.js",
            "~/Scripts/WebForms/Focus.js",
            "~/Scripts/WebForms/GridView.js",
            "~/Scripts/WebForms/DetailsView.js",
            "~/Scripts/WebForms/TreeView.js",
            "~/Scripts/WebForms/WebParts.js"))

        bundles.Add(New ScriptBundle("~/bundles/MsAjaxJs").Include(
            "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
            "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
            "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
            "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"))

        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-*"))
        bundles.Add(New StyleBundle("~/Content/css").Include(
    "~/Content/bootstrap.css",
    "~/Content/site.css"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
            "~/Scripts/bootstrap.bundle.js"))
    End Sub

    Private Shared Sub RegisterJQueryScriptManager()
        Dim jQueryDefinition As New ScriptResourceDefinition With {
            .Path = "~/Scripts/jquery-3.7.0.min.js",
            .DebugPath = "~/Scripts/jquery-3.7.0.js",
            .CdnPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.0.min.js",
            .CdnDebugPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.0.js"
        }

        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQueryDefinition)
    End Sub
End Class