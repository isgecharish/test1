Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ATN
  <DataObject()> _
  Partial Public Class atnPostApplication
    Private Shared _RecordCount As Integer
    Private _LeaveApplID As Int32
    Private _CardNo As String
    Private _Remarks As String
    Private _AppliedOn As String
    Private _ApplStatusID As Int32
    Private _PostedOn As String
    Private _PostedBy As String
    Private _PostingRemark As String
    Private _FinYear As String
		Private _AdvanceApplication As Boolean
		Private _ApprovedBy As String = ""
		Private _ApprovedByEmployeeName As String = ""
    Private _CardNoHRM_Employees As SIS.ATN.atnEmployees
    Private _CardNoEmployeeName As String
		Private _ApplStatusIDATN_ApplicationStatus As SIS.ATN.atnApplicationStatus
		Public Property ApprovedByEmployeeName() As String
			Get
				Return _ApprovedByEmployeeName
			End Get
			Set(ByVal value As String)
				If Convert.DBNull(value) Then
					_ApprovedByEmployeeName = ""
				Else
					_ApprovedByEmployeeName = value
				End If
			End Set
		End Property
		Public Property ApprovedBy() As String
			Get
				Return _ApprovedBy
			End Get
			Set(ByVal value As String)
				If Convert.DBNull(value) Then
					_ApprovedBy = ""
				Else
					_ApprovedBy = value
				End If
			End Set
		End Property
    Public Property LeaveApplID() As Int32
      Get
        Return _LeaveApplID
      End Get
      Set(ByVal value As Int32)
        _LeaveApplID = value
      End Set
    End Property
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Remarks = ""
				 Else
					 _Remarks = value
			   End If
      End Set
    End Property
    Public Property AppliedOn() As String
      Get
        If Not _AppliedOn = String.Empty Then
          Return Convert.ToDateTime(_AppliedOn).ToString("dd/MM/yyyy")
        End If
        Return _AppliedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AppliedOn = ""
				 Else
					 _AppliedOn = value
			   End If
      End Set
    End Property
    Public Property ApplStatusID() As Int32
      Get
        Return _ApplStatusID
      End Get
      Set(ByVal value As Int32)
        _ApplStatusID = value
      End Set
    End Property
    Public Property PostedOn() As String
      Get
        If Not _PostedOn = String.Empty Then
          Return Convert.ToDateTime(_PostedOn).ToString("dd/MM/yyyy")
        End If
        Return _PostedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PostedOn = ""
				 Else
					 _PostedOn = value
			   End If
      End Set
    End Property
    Public Property PostedBy() As String
      Get
        Return _PostedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PostedBy = ""
				 Else
					 _PostedBy = value
			   End If
      End Set
    End Property
    Public Property PostingRemark() As String
      Get
        Return _PostingRemark
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PostingRemark = ""
				 Else
					 _PostingRemark = value
			   End If
      End Set
    End Property
    Public Property FinYear() As String
      Get
        Return _FinYear
      End Get
      Set(ByVal value As String)
        _FinYear = value
      End Set
    End Property
    Public Property AdvanceApplication() As Boolean
      Get
        Return _AdvanceApplication
      End Get
      Set(ByVal value As Boolean)
        _AdvanceApplication = value
      End Set
    End Property
    Public ReadOnly Property CardNoHRM_Employees() As SIS.ATN.atnEmployees
      Get
        If _CardNoHRM_Employees Is Nothing Then
          _CardNoHRM_Employees = SIS.ATN.atnEmployees.GetByID(_CardNo)
        End If
        Return _CardNoHRM_Employees
      End Get
    End Property
    Public Property CardNoEmployeeName() As String
      Get
        Return _CardNoEmployeeName
      End Get
      Set(ByVal value As String)
        _CardNoEmployeeName = value
      End Set
    End Property
    Public ReadOnly Property ApplStatusIDATN_ApplicationStatus() As SIS.ATN.atnApplicationStatus
      Get
        If _ApplStatusIDATN_ApplicationStatus Is Nothing Then
          _ApplStatusIDATN_ApplicationStatus = SIS.ATN.atnApplicationStatus.GetByID(_ApplStatusID)
        End If
        Return _ApplStatusIDATN_ApplicationStatus
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal LeaveApplID As Int32) As SIS.ATN.atnPostApplication
      Dim Results As SIS.ATN.atnPostApplication = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPostApplicationSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LeaveApplID",SqlDbType.Int,LeaveApplID.ToString.Length, LeaveApplID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ATN.atnPostApplication(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal LeaveApplID As Int32, ByVal CardNo As String) As SIS.ATN.atnPostApplication
      Return GetByID(LeaveApplID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByCardNo(ByVal CardNo As String, ByVal OrderBy as String) As List(Of SIS.ATN.atnPostApplication)
      Dim Results As List(Of SIS.ATN.atnPostApplication) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "CardNo"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPostApplicationSelectByCardNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplication",SqlDbType.Bit,2, 0)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnPostApplication)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnPostApplication(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.ATN.atnPostApplication)
      Dim Results As List(Of SIS.ATN.atnPostApplication) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "CardNo"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spatnPostApplicationSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spatnPostApplicationSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.NVarChar,8, IIf(CardNo Is Nothing, String.Empty,CardNo))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID",SqlDbType.Int,10, 5)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.NVarChar,4, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplication",SqlDbType.Bit,2, 0)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ATN.atnPostApplication)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ATN.atnPostApplication(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ATN.atnPostApplication) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spatnPostApplicationUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LeaveApplID",SqlDbType.Int,11, Record.LeaveApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplStatusID",SqlDbType.Int,11, Record.ApplStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn",SqlDbType.DateTime,21, Now)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy",SqlDbType.NVarChar,9, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostingRemark",SqlDbType.NVarChar,101, Iif(Record.PostingRemark= "" ,Convert.DBNull, Record.PostingRemark))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As Integer
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _LeaveApplID = Ctype(Reader("LeaveApplID"),Int32)
      _CardNo = Ctype(Reader("CardNo"),String)
      If Convert.IsDBNull(Reader("Remarks")) Then
        _Remarks = String.Empty
      Else
        _Remarks = Ctype(Reader("Remarks"), String)
      End If
      If Convert.IsDBNull(Reader("AppliedOn")) Then
        _AppliedOn = String.Empty
      Else
        _AppliedOn = Ctype(Reader("AppliedOn"), String)
      End If
      _ApplStatusID = Ctype(Reader("ApplStatusID"),Int32)
      If Convert.IsDBNull(Reader("PostedOn")) Then
        _PostedOn = String.Empty
      Else
        _PostedOn = Ctype(Reader("PostedOn"), String)
      End If
      If Convert.IsDBNull(Reader("PostedBy")) Then
        _PostedBy = String.Empty
      Else
        _PostedBy = Ctype(Reader("PostedBy"), String)
      End If
      If Convert.IsDBNull(Reader("PostingRemark")) Then
        _PostingRemark = String.Empty
      Else
        _PostingRemark = Ctype(Reader("PostingRemark"), String)
      End If
      _FinYear = Ctype(Reader("FinYear"),String)
      _AdvanceApplication = Ctype(Reader("AdvanceApplication"),Boolean)
      _CardNoEmployeeName = Reader("HRM_Employees1_EmployeeName") & " [" & Ctype(Reader("CardNo"), String) & "]"
      _CardNoHRM_Employees = New SIS.ATN.atnEmployees("HRM_Employees1",Reader)
      _ApplStatusIDATN_ApplicationStatus = New SIS.ATN.atnApplicationStatus("ATN_ApplicationStatus2",Reader)
			If Convert.IsDBNull(Reader("ApprovedByEmployeeName")) Then
				_ApprovedByEmployeeName = String.Empty
			Else
				_ApprovedByEmployeeName = CType(Reader("ApprovedByEmployeeName"), String)
			End If
			If Convert.IsDBNull(Reader("ApprovedBy")) Then
				_ApprovedBy = String.Empty
			Else
				_ApprovedBy = CType(Reader("ApprovedBy"), String)
			End If
		End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _LeaveApplID = Ctype(Reader(AliasName & "_LeaveApplID"),Int32)
      _CardNo = Ctype(Reader(AliasName & "_CardNo"),String)
      If Convert.IsDBNull(Reader(AliasName & "_Remarks")) Then
        _Remarks = String.Empty
      Else
        _Remarks = Ctype(Reader(AliasName & "_Remarks"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_AppliedOn")) Then
        _AppliedOn = String.Empty
      Else
        _AppliedOn = Ctype(Reader(AliasName & "_AppliedOn"), String)
      End If
      _ApplStatusID = Ctype(Reader(AliasName & "_ApplStatusID"),Int32)
      If Convert.IsDBNull(Reader(AliasName & "_PostedOn")) Then
        _PostedOn = String.Empty
      Else
        _PostedOn = Ctype(Reader(AliasName & "_PostedOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_PostedBy")) Then
        _PostedBy = String.Empty
      Else
        _PostedBy = Ctype(Reader(AliasName & "_PostedBy"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_PostingRemark")) Then
        _PostingRemark = String.Empty
      Else
        _PostingRemark = Ctype(Reader(AliasName & "_PostingRemark"), String)
      End If
      _FinYear = Ctype(Reader(AliasName & "_FinYear"),String)
      _AdvanceApplication = Ctype(Reader(AliasName & "_AdvanceApplication"),Boolean)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
