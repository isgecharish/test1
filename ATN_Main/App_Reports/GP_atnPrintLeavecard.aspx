﻿<%@ Page Title="ISGEC:Print LeaveCard" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GP_atnPrintLeavecard.aspx.vb" Inherits="GP_atnPrintLeavecard" %>
<%@ Register TagPrefix="LGM" TagName="LC_LeaveCard" Src="~/ATN_Main/App_FKControls/LC_LeaveCard.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
					<asp:Label ID="LabelatnAppliedApplications" runat="server" Font-Bold="True" Font-Size="14px"  Text="LEAVE CARD"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
  <ContentTemplate>
        <LGM:ToolBar0 
          ID="ToolBar0_1" 
          ToolType="lgNReport"
          EnableAdd="False" 
          runat="server" />
<div id="frmdiv" class="ui-widget-content minipage">
<div id="div221" runat="server"   style="width:400px;margin:auto">
</div>
</div>
  </ContentTemplate>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>

