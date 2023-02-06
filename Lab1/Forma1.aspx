<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="Laboratorinis1.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Miesto žemėlapis:"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server" CellSpacing="2">
            </asp:Table>
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Rodyti pradinius duomenis" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
