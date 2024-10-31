Imports System.Collections.Generic

Public Interface IBaseRepository(Of T)
    Function GetAll() As IEnumerable(Of T)
    Function GetById(id As Integer) As T
    Function Add(entity As T) As T
    Sub Update(entity As T)
    Sub Delete(id As Integer)
    Function SaveChanges() As Boolean
End Interface
