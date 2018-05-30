Partial Class GF_atnExecutionStates
  Inherits SIS.SYS.GridBase
  Protected Sub ToolBar0_1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GatnApplicationStatus"
    SetGridView = GridView1
  End Sub
  Private _EditUrl As String = "~/ATN_Main/App_Edit/EF_atnExecutionStates.aspx"
  Private _AddUrl As String = "~/ATN_Main/App_Create/AF_atnExecutionStates.aspx"
  Private _InfoUrl As String = "~/ATN_Main/App_Display/DF_atnExecutionStates.aspx"
  Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim RedirectUrl As String = _EditUrl & "?Code=" & oBut.CommandArgument.ToString
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim RedirectUrl As String = _InfoUrl & "?Code=" & oBut.CommandArgument.ToString
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ToolBar0_1.AddUrl = _AddUrl
    ToolBar0_1.EditUrl = _EditUrl

  End Sub
End Class
