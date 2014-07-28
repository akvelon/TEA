<%@ Page Title="Create Poll" Language="C#" MasterPageFile="~/Tea.Master" AutoEventWireup="true" CodeBehind="CreatePoll.aspx.cs" Inherits="Presentation.CreatePoll" %>
<asp:Content ContentPlaceHolderID="HeadPlaceholder" runat="server">
    <script src="Scripts/createpoll.js"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="QuestionPlaceholder" runat="server">
    What tasks would you like to include in the poll?
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceholder" runat="server">
    <div id="maincontent">
        <div class="input-group input-group-poll">
            <span class="input-group-addon"><span class="glyphicon glyphicon-pencil"></span></span>
            <input type="text" placeholder="Type here to add another text field" class="form-control input-poll" autofocus=""/>
        </div>
    </div>
    <asp:Button type="button" ID="ButtonCreate" class="btn btn-primary button-bottom" Text="Create" OnClick="ButtonCreate_Click" runat="server" disabled/>
</asp:Content>