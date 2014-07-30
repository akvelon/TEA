<%@ Page Title="" Language="C#" MasterPageFile="~/Tea.Master" AutoEventWireup="true" CodeBehind="ViewPoll.aspx.cs" Inherits="Presentation.ViewPoll" %>
<asp:Content ContentPlaceHolderID="HeadPlaceholder" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="QuestionPlaceholder" runat="server">
    View poll
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceholder" runat="server">
    <asp:ListView ID="PollView" runat="server">
        <LayoutTemplate>
            <table class="table">
                <th>User story</th>
                <th>Estimated effort</th>
                <tbody id="itemPlaceholder" runat="server"></tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Description") %>
                </td>
                <td class="col-md-2">
                    N/A
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div class="text-center">No data to show for such a request</div>
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:Panel ID="BottomPanel" runat="server">
        <div class="general-information">Vote count:<asp:Label ID="TotalVoted" CssClass="general-information-right" runat="server"></asp:Label></div>
    </asp:Panel>
</asp:Content>
