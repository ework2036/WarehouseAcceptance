Option Strict On
Option Explicit On

Imports Unity
Imports Unity.Lifetime
Imports Unity.Registration
Imports Unity.Resolution
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Interfaces
Imports WarehouseAcceptance.Core.WarehouseAcceptance.Core.Services
Imports WarehouseAcceptance.Data.WarehouseAcceptance.Data.Context
Imports WarehouseAcceptance.Data.WarehouseAcceptance.Data.Repositories

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
            container.RegisterType(GetType(WarehouseContext), New HierarchicalLifetimeManager())

            ' Register Repository
            container.RegisterType(GetType(IFornitoreRepository), GetType(FornitoreRepository), New HierarchicalLifetimeManager())

            ' Register Service
            container.RegisterType(GetType(IFornitoreService), GetType(FornitoreService), New HierarchicalLifetimeManager())
        End Sub
    End Class
End Namespace