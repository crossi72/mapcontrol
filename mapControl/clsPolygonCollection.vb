Imports Microsoft.Maps.MapControl.WPF

Public Class MapPolygonCollection
	Inherits CollectionBase

#Region " Variables "

	Dim nameList As New ArrayList

#End Region

#Region " Properties "

	Default Public Property Item(ByVal index As Integer) As MapPolygon
		Get
			Return CType(List(index), MapPolygon)
		End Get
		Set(ByVal Value As MapPolygon)
			List(index) = Value
		End Set
	End Property

	Default Public Property Item(ByVal name As String) As MapPolygon
		Get
			Return CType(List(nameList.IndexOf(name.ToLower)), MapPolygon)
		End Get
		Set(ByVal Value As MapPolygon)
			List(nameList.IndexOf(name.ToLower)) = Value
		End Set
	End Property

#End Region

#Region " Methods "

	Public Overloads Sub Clear()
		nameList.Clear()
		List.Clear()
	End Sub

	Public Function Add(ByVal value As MapPolygon, name As String) As Integer
		nameList.Add(name.ToLower)
		Return List.Add(value)
	End Function

	Public Function IndexOf(ByVal value As MapPolygon) As Integer
		Return List.IndexOf(value)
	End Function

	Public Sub Insert(ByVal index As Integer, ByVal value As MapPolygon)
		Me.Insert(index, value.Name.ToLower, value)
	End Sub

	Public Sub Insert(ByVal index As Integer, ByVal name As String, ByVal value As MapPolygon)
		nameList.Insert(index, name.ToLower)
		List.Insert(index, value)
	End Sub

	Public Sub Remove(ByVal name As String)
		Dim element As MapPolygon

		element = CType(List(nameList.IndexOf(name.ToLower)), MapPolygon)
		List.Remove(element)
		element = Nothing
		nameList.Remove(name.ToLower)
	End Sub

	Public Function Contains(ByVal value As MapPolygon) As Boolean
		' If value is not of type MapPolygon, this will return false.
		Return List.Contains(value)
	End Function

	Public Function Contains(ByVal value As String) As Boolean
		' If value is not of type String, this will return false.
		Return nameList.Contains(value.ToLower)
	End Function

	Protected Overrides Sub OnInsert(ByVal index As Integer, ByVal value As [Object])
		If value IsNot Nothing AndAlso Not TypeOf value Is MapPolygon Then
			Throw New ArgumentException("Object must be of type MapPolygon.", "value")
		End If
	End Sub

	Protected Overrides Sub OnRemove(ByVal index As Integer, ByVal value As [Object])
		If value IsNot Nothing AndAlso Not TypeOf value Is MapPolygon Then
			Throw New ArgumentException("Object must be of type MapPolygon.", "value")
		End If
	End Sub

	Protected Overrides Sub OnSet(ByVal index As Integer, ByVal oldValue As [Object], ByVal newValue As [Object])
		If newValue IsNot Nothing AndAlso Not TypeOf newValue Is MapPolygon Then
			Throw New ArgumentException("Object must be of type MapPolygon.", "newValue")
		End If
	End Sub

	Protected Overrides Sub OnValidate(ByVal value As [Object])
		If value IsNot Nothing AndAlso Not TypeOf value Is MapPolygon Then
			Throw New ArgumentException("Object must be of type MapPolygon.")
		End If
	End Sub

#End Region

End Class
