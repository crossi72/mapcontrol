Imports Microsoft.Maps.MapControl.WPF

Public Class mapSupport

#Region " Types "

	Public Structure coordinate
		Dim latitude As Double
		Dim longitude As Double

		Public Sub New(latitude As Double, longitude As Double)
			Me.latitude = latitude
			Me.longitude = longitude
		End Sub
	End Structure

#End Region

#Region " Variables "

	Private polygonCollection As New MapPolygonCollection

#End Region

#Region " Public Methods "

	''' <summary>
	''' remove every object from the map
	''' </summary>
	''' <param name="myMap">map to clear</param>
	''' <remarks></remarks>
	Public Sub ClearMap(myMap As Map)
		myMap.Children.Clear()
		Me.polygonCollection.Clear()
	End Sub

	''' <summary>
	''' add a bar to a map
	''' </summary>
	''' <param name="myMap">map to draw on</param>
	''' <param name="polygonName">name of the object</param>
	''' <param name="color">color of bar</param>
	''' <param name="latitude1">latitude of first point</param>
	''' <param name="longitude1">longitude of first point</param>
	''' <param name="latitude2">latitude of second point</param>
	''' <param name="longitude2">longitude of second point</param>
	''' <remarks></remarks>
	Public Sub AddLine(myMap As Map, polygonName As String, color As System.Windows.Media.Color, latitude1 As Double, longitude1 As Double, latitude2 As Double, longitude2 As Double)
		Dim x, y As coordinate

		x = New coordinate(latitude1, longitude1)
		y = New coordinate(latitude2, longitude2)

		AddPolygon(myMap, polygonName, color, x, y)
	End Sub

	''' <summary>
	''' add a bar to a map
	''' </summary>
	''' <param name="myMap">map to draw on</param>
	''' <param name="polygonName">name of the object</param>
	''' <param name="color">color of bar</param>
	''' <param name="latitude">latitude of bar</param>
	''' <param name="longitude">longitude of bar</param>
	''' <param name="width">width of bar</param>
	''' <param name="height">height of bar</param>
	''' <remarks></remarks>
	Public Sub AddBar(myMap As Map, polygonName As String, color As System.Windows.Media.Color, latitude As Double, longitude As Double, width As Double, height As Double)
		Dim x, y, z, t As coordinate

		x = New coordinate(latitude, longitude)
		y = New coordinate(latitude, longitude + width)
		z = New coordinate(latitude + height, longitude + width)
		t = New coordinate(latitude + height, longitude)

		AddPolygon(myMap, polygonName, color, x, y, z, t)
	End Sub

	''' <summary>
	''' add a triangle to a map
	''' </summary>
	''' <param name="myMap">map to draw on</param>
	''' <param name="polygonName">name of the object</param>
	''' <param name="color">color of triangle</param>
	''' <param name="latitude1">latitude of first point</param>
	''' <param name="longitude1">longitude of first point</param>
	''' <param name="latitude2">latitude of second point</param>
	''' <param name="longitude2">longitude of second point</param>
	''' <param name="latitude3">latitude of third point</param>
	''' <param name="longitude3">longitude of third point</param>
	''' <remarks></remarks>
	Public Sub AddTriangle(myMap As Map, polygonName As String, color As System.Windows.Media.Color, latitude1 As Double, longitude1 As Double, latitude2 As Double, longitude2 As Double, latitude3 As Double, longitude3 As Double)
		AddPolygon(myMap, polygonName, color, New coordinate(latitude1, longitude1), New coordinate(latitude2, longitude2), New coordinate(latitude3, longitude3))
	End Sub

	''' <summary>
	''' add a triangle to a map
	''' </summary>
	''' <param name="myMap">map to draw on</param>
	''' <param name="polygonName">name of the object</param>
	''' <param name="color">color of triangle</param>
	''' <param name="x">coordinates of first point</param>
	''' <param name="y">coordinates of second point</param>
	''' <param name="z">coordinates of third point</param>
	''' <remarks></remarks>
	Public Sub AddTriangle(myMap As Map, polygonName As String, color As System.Windows.Media.Color, x As coordinate, y As coordinate, z As coordinate)
		AddPolygon(myMap, polygonName, color, x, y, z)
	End Sub

	''' <summary>
	''' Remove an element from the map
	''' </summary>
	''' <param name="myMap"></param>
	''' <param name="elementName"></param>
	''' <remarks></remarks>
	Public Sub DeleteElement(myMap As Map, elementName As String)
		If Me.polygonCollection.Contains(elementName) Then
			myMap.Children.Remove(Me.polygonCollection(elementName))
			Me.polygonCollection.Remove(elementName)
		End If
	End Sub

	''' <summary>
	''' add a polygon to a map
	''' </summary>
	''' <param name="myMap">map to draw on</param>
	''' <param name="polygonName">name of the object</param>
	''' <param name="color">color of polygon</param>
	''' <param name="coordinate">coordinates of vertices of polygon</param>
	''' <remarks></remarks>
	Public Sub AddPolygon(myMap As Map, polygonName As String, color As System.Windows.Media.Color, ParamArray coordinate() As coordinate)
		Dim coord As coordinate

		Dim polygon As New MapPolygon() With _
		{.Fill = New System.Windows.Media.SolidColorBrush(color), _
		  .Stroke = New System.Windows.Media.SolidColorBrush(color), _
		  .StrokeThickness = 1, _
		  .Opacity = 0.7, _
		  .Locations = New LocationCollection() _
		}

		For Each coord In coordinate
			polygon.Locations.Add(New Location(coord.latitude, coord.longitude))
		Next

		polygon.Name = polygonName

		Me.polygonCollection.Add(polygon, polygonName)

		myMap.Children.Add(polygon)
	End Sub

#End Region

End Class
