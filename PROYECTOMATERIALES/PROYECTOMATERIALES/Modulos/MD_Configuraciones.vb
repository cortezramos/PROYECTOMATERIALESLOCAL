Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Module MD_Configuraciones

    ''Datos de conexion a base de datos
    Public vBaseDatos As String = ""
    Public vServer As String = ""
    Public Conexion As String = "Data Source = " & vServer & "; Initial Catalog = " & vBaseDatos & "; Integrated Security = True"
    
    ''Datos de usuario logueado
    Public usuarioid As Integer
    Public usuariolog As String
    Public contralog As String ''Contraseña
    Public empresaid As Integer
    Public empresa As String
    Public catalogolog As Integer
    Public sucursallog As Integer
    Public crearlog As Integer
    Public eliminarlog As Integer
    Public modificarlog As Integer    
    Public consultarlog As Integer
    Public tipousuariolog As Integer
    ''Datos para permisos temporales -Usuarios que se loguearan para autorizar ciertas transacciones
    Public usuarioPermiso As String
    Public contraPermiso As String ''Contraseña
    Public crearPermiso As Integer
    Public eliminarPermiso As Integer
    Public modificarPermiso As Integer
    ''Finca para datos de despacho y planta que es la finca id
    'Public finca As String
    'Public fincaid As Integer

    'Variable para numero de orden de solicitud
    Public numeroSolicitud As Integer
    Public dtDetalleOrdenes As DataTable
    Public row As DataRow

    'Variables para manejo de reporting service
    Public vUrlReportServer As String
    Public vPathReportServer As String

    'Tamaño de pantalla para consultar informes
    Public altoPantalla As Double
    Public anchoPantalla As Double

    ''Variables globales de sql
    Public cmd As SqlCommand
    Public da As SqlDataAdapter
    Public dt As DataTable

    ''Variables para cargar una sola vez datos
    Public dtConsultaProductos As New DataTable
    Public dtConsultaCentros As New DataTable
End Module