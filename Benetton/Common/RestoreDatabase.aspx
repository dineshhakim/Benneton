<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RestoreDatabase.aspx.cs" Inherits="Benetton.Common.RestoreDatabase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlMsgBox" runat="server">
    </asp:Panel>
    <fieldset class="fieldsetCss">
        <legend class="legendCss">Restore Database</legend>
        <table>
            <tr>
                <td>
                    Designation Database
                </td>
                <td>
                    <asp:TextBox ID="txtDatabase" runat="server"></asp:TextBox>
                </td>
                <td>
                    Source File
                </td>
                <td>
                    <asp:FileUpload ID="fuDatabase" runat="server" Visible="false" />
                    <asp:TextBox ID="txtFileName" runat="server" placeholder="D:\DataBase\DBName.bak"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnRestore" runat="server" Text="Restore DataBase" CssClass="Button"
                        ValidationGroup="v" OnClick="btnRestore_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
