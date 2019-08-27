Imports mapControl.mapSupport

Public Class mapControl

	Private mapSupport As New mapSupport

	Public Sub New()
		' Chiamata richiesta dalla finestra di progettazione.
		InitializeComponent()

		' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
	End Sub

	''' <summary>
	''' remove every object from the map
	''' </summary>
	''' <remarks></remarks>
	Public Sub ClearMap()
		Me.mapSupport.ClearMap(Me.myMap)
	End Sub

	''' <summary>
	''' Remove an element from the map
	''' </summary>
	''' <param name="elementName"></param>
	''' <remarks></remarks>
	Public Sub DeleteElement(elementName As String)
		Me.mapSupport.DeleteElement(Me.myMap, elementName)
	End Sub

	''' <summary>
	''' add a bar to a map
	''' </summary>
	''' <param name="polygonName">name of the object</param>
	''' <param name="color">color of bar</param>
	''' <param name="latitude1">latitude of first point</param>
	''' <param name="longitude1">longitude of first point</param>
	''' <param name="latitude2">latitude of second point</param>
	''' <param name="longitude2">longitude of second point</param>
	''' <remarks></remarks>
	Public Sub AddLine(polygonName As String, color As System.Windows.Media.Color, latitude1 As Double, longitude1 As Double, latitude2 As Double, longitude2 As Double)
		Me.mapSupport.AddLine(Me.myMap, polygonName, color, latitude1, longitude1, latitude2, longitude2)
	End Sub

	''' <summary>
	''' Set center of the map
	''' </summary>
	''' <param name="latidude">latidude of map center</param>
	''' <param name="longitude">longitude of map center</param>
	''' <remarks></remarks>
	Public Sub SetMapCenter(latidude As Double, longitude As Double)
		Me.mapSupport.SetMapCenter(Me.myMap, latidude, longitude)
	End Sub

	''' <summary>
	''' add a polygon to a map
	''' </summary>
	''' <param name="polygonName">name of the object</param>
	''' <param name="color">color of polygon</param>
	''' <param name="x">coordinates of first vertice of polygon</param>
	''' <param name="y">coordinates of second vertice of polygon</param>
	''' <param name="z">coordinates of third vertice of polygon</param>
	''' <remarks></remarks>
	Public Sub AddPolygon(polygonName As String, color As System.Windows.Media.Color, x As coordinate, y As coordinate, z As coordinate)
		Me.mapSupport.AddPolygon(Me.myMap, polygonName, color, x, y, z)
	End Sub

	''' <summary>
	''' add a triangle to a map
	''' </summary>
	''' <param name="polygonName">name of the object</param>
	''' <param name="color">color of polygon</param>
	''' <param name="x">coordinates of first vertice of polygon</param>
	''' <param name="y">coordinates of second vertice of polygon</param>
	''' <param name="z">coordinates of third vertice of polygon</param>
	''' <remarks></remarks>
	Public Sub AddTriangle(polygonName As String, color As System.Windows.Media.Color, x As coordinate, y As coordinate, z As coordinate)
		Me.mapSupport.AddTriangle(Me.myMap, polygonName, color, x, y, z)
	End Sub

	''' <summary>
	''' add a triangle to a map
	''' </summary>
	''' <param name="polygonName">name of the object</param>
	''' <param name="color">color of triangle</param>
	''' <param name="latitude1">latitude of first point</param>
	''' <param name="longitude1">longitude of first point</param>
	''' <param name="latitude2">latitude of second point</param>
	''' <param name="longitude2">longitude of second point</param>
	''' <param name="latitude3">latitude of third point</param>
	''' <param name="longitude3">longitude of third point</param>
	''' <remarks></remarks>
	Public Sub AddTriangle(polygonName As String, color As System.Windows.Media.Color, latitude1 As Double, longitude1 As Double, latitude2 As Double, longitude2 As Double, latitude3 As Double, longitude3 As Double)
		Me.mapSupport.AddTriangle(Me.myMap, polygonName, color, latitude1, longitude1, latitude2, longitude2, latitude3, longitude3)
	End Sub

	''' <summary>
	''' add a bar to a map
	''' </summary>
	''' <param name="polygonName">name of the object</param>
	''' <param name="color">color of bar</param>
	''' <param name="latitude">latitude of bar</param>
	''' <param name="longitude">longitude of bar</param>
	''' <param name="width">width of bar</param>
	''' <param name="height">height of bar</param>
	''' <remarks></remarks>
	Public Sub AddBar(polygonName As String, color As System.Windows.Media.Color, latitude As Double, longitude As Double, Width As Double, Height As Double)
		Me.mapSupport.AddBar(Me.myMap, polygonName, color, latitude, longitude, Width, Height)
	End Sub

	''' <summary>
	''' increase zoom level
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub Plus_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
		Me.myMap.ZoomLevel = Me.myMap.ZoomLevel + 0.1
	End Sub

	''' <summary>
	''' reduce zoom level
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub Minus_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
		Me.myMap.ZoomLevel = Me.myMap.ZoomLevel - 0.1
	End Sub

End Class
