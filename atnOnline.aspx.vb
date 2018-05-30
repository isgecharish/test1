
Partial Class atnOnline
    Inherits System.Web.UI.Page

  Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    Dim id As String = ""
    Dim val As String = ""
    Dim stopEMail As String = ""
    Try
      id = Request.QueryString("id")
      val = Request.QueryString("val")
    Catch ex As Exception
      id = ""
      val = ""
    End Try
    Try
      stopEMail = Request.QueryString("stopEMail")
    Catch ex As Exception
      stopEMail = ""
    End Try
    Dim apl As SIS.ATN.atnNewApplHeader = Nothing
    If id <> String.Empty Then
      HttpContext.Current.Session("LoginID") = ""
      apl = SIS.ATN.atnNewApplHeader.GetbyApplication(id)
    End If
    If apl Is Nothing Then
      msg.Text = "E-Mail Request is already EXECUTED."
      msg.ForeColor = Drawing.Color.Green
    Else
      HttpContext.Current.Session("FinYear") = SIS.SYS.Utilities.ApplicationSpacific.ReadActiveFinYear
      If apl.ApplStatusID = 2 Then
        HttpContext.Current.Session("LoginID") = apl.VerifiedBy
      ElseIf apl.ApplStatusID = 3 Then
        HttpContext.Current.Session("LoginID") = apl.ApprovedBy
      End If
      If val = apl.Approved Then
        Try
          SIS.ATN.atnApplHeader.ForwardApplication(apl.LeaveApplID, "Approved via E-Mail")
          apl = SIS.ATN.atnNewApplHeader.atnNewApplHeaderGetByID(apl.LeaveApplID)
          apl.Application = ""
          apl.Approved = ""
          apl.Rejected = ""
          SIS.ATN.atnNewApplHeader.UpdateData(apl)
          msg.Text = "Approved successfully"
          msg.ForeColor = Drawing.Color.Green
        Catch ex As Exception
        End Try
      ElseIf val = apl.Rejected Then
        Try
          SIS.ATN.atnApplHeader.RejectApplication(apl.LeaveApplID, "Rejected via E-Mail")
          apl = SIS.ATN.atnNewApplHeader.atnNewApplHeaderGetByID(apl.LeaveApplID)
          apl.Application = ""
          apl.Approved = ""
          apl.Rejected = ""
          SIS.ATN.atnNewApplHeader.UpdateData(apl)
          msg.Text = "Rejected Successfully"
          msg.ForeColor = Drawing.Color.Red
        Catch ex As Exception
        End Try
      Else
        msg.Text = "Invalid E-Mail"
        msg.ForeColor = Drawing.Color.Red
      End If
    End If
    If stopEMail <> String.Empty Then
      HttpContext.Current.Session("LoginID") = ""
      apl = SIS.ATN.atnNewApplHeader.GetbyApplication(stopEMail)
      If apl IsNot Nothing Then
        Dim tmp As SIS.ATN.atnEmployeeConfiguration = Nothing
        If apl.ApplStatusID = 2 Then
          HttpContext.Current.Session("LoginID") = apl.VerifiedBy
          tmp = SIS.ATN.atnEmployeeConfiguration.atnEmployeeConfigurationGetByID(apl.VerifiedBy)
          If tmp IsNot Nothing Then
            tmp.SendVerifyMail = False
            SIS.ATN.atnEmployeeConfiguration.UpdateData(tmp)
            apl.Application = ""
            apl.Approved = ""
            apl.Rejected = ""
            SIS.ATN.atnNewApplHeader.UpdateData(apl)
            msg.Text = "Stop E-Mail Notification for Leave Verification executed."
            msg.ForeColor = Drawing.Color.Green
          Else
            msg.Text = "Stop E-Mail Notification execution Error."
            msg.ForeColor = Drawing.Color.Red
          End If
        ElseIf apl.ApplStatusID = 3 Then
          HttpContext.Current.Session("LoginID") = apl.ApprovedBy
          tmp = SIS.ATN.atnEmployeeConfiguration.atnEmployeeConfigurationGetByID(apl.ApprovedBy)
          If tmp IsNot Nothing Then
            tmp.SendApproveMail = False
            SIS.ATN.atnEmployeeConfiguration.UpdateData(tmp)
            apl.Application = ""
            apl.Approved = ""
            apl.Rejected = ""
            SIS.ATN.atnNewApplHeader.UpdateData(apl)
            msg.Text = "Stop E-Mail Notification for Leave Approval executed."
            msg.ForeColor = Drawing.Color.Green
          Else
            msg.Text = "Stop E-Mail Notification execution Error."
            msg.ForeColor = Drawing.Color.Red
          End If
        End If
      Else
        msg.Text = "Stop E-Mail Notification CAN NOT be executed."
        msg.ForeColor = Drawing.Color.Red
      End If
    End If
  End Sub
End Class
