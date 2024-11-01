Option Strict On
Option Explicit On

Imports Unity
Imports Unity.Lifetime
Imports Unity.Registration
Imports Unity.Resolution
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Interfaces
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Services
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.WarehouseAcceptance.Core.Services
Imports WarehouseAcceptance.Data.WarehouseAcceptance.Data.Context
Imports WarehouseAcceptance.Data.WarehouseAcceptance.Data.Repositories
Imports WarehouseAcceptance.Data.WarehouseAcceptance.Data.WarehouseAcceptance.Data.Repositories

Namespace WarehouseAcceptance.Web.Infrastructure
    Public NotInheritable Class UnityConfig
        Private Sub New()
        End Sub

        Private Shared _container As IUnityContainer

        Public Shared ReadOnly Property Container As IUnityContainer
            Get
                If _container Is Nothing Then
                    _container = New UnityContainer()
                    RegisterTypes(_container)
                End If
                Return _container
            End Get
        End Property

        Private Shared Sub RegisterTypes(container As IUnityContainer)
            ' Register DbContext
            container.RegisterType(Of WarehouseContext)(New HierarchicalLifetimeManager())

            ' Register Repositories
            container.RegisterType(Of IFornitoreRepository, FornitoreRepository)(New HierarchicalLifetimeManager())
            container.RegisterType(Of ITemplateRepository, TemplateRepository)(New HierarchicalLifetimeManager())

            ' Register Services
            container.RegisterType(Of IFornitoreService, FornitoreService)(New HierarchicalLifetimeManager())
            container.RegisterType(Of ITemplateService, TemplateService)(New HierarchicalLifetimeManager())
        End Sub
    End Class
End Namespace