<%@ Page Title="" Language="C#" MasterPageFile="~/Tea.Master" AutoEventWireup="true" CodeBehind="Vote.aspx.cs" Inherits="Presentation.Vote" %>
<asp:Content ContentPlaceHolderID="HeadPlaceholder" runat="server">

</asp:Content>
<asp:Content ContentPlaceHolderID="QuestionPlaceholder" runat="server">
    Vote
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceholder" runat="server">
    <asp:ListView ID="VoteView" runat="server">
        <LayoutTemplate>
            <table class="table">
                <th>Story</th>
                <th>Relation</th>
                <th>Story</th>
                <tbody id="itemPlaceholder" runat="server"></tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <textarea class="form-control" rows="5" disabled="disabled"><%# Eval("LeftStory.Description") %></textarea>
                </td>
                <td>
                    <input type="radio" name="<%# Eval("AnswerId") %>" value="trivial"> The left story is trivial<br/>
                    <input type="radio" name="<%# Eval("AnswerId") %>" value="easy"> The left story is easy<br/>
                    <input type="radio" name="<%# Eval("AnswerId") %>" value="easy" checked="checked"> Both stories are of equal complexity<br/>
                    <input type="radio" name="<%# Eval("AnswerId") %>" value="easy"> The left story is more difficult<br/>
                    <input type="radio" name="<%# Eval("AnswerId") %>" value="easy"> The left story is almost impossible
                </td>
                <td>
                    <textarea class="form-control" rows="5" disabled=""><%# Eval("RightStory.Description") %></textarea>
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div class="text-center">No data to show for such a request</div>
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:Button type="button" ID="ButtonVote" class="btn btn-primary button-bottom" Text="Vote" OnClick="ButtonVote_Click" runat="server"/>
</asp:Content>
