<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Pretplatnici_UI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Odaberite stručnu spremu:"></asp:Label>
                <asp:DropDownList ID="ddlStrucneSpreme" runat="server"></asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Unesite Ime"></asp:Label>
                <asp:TextBox ID="txtIme" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Unesite Prezime"></asp:Label>
                <asp:TextBox ID="txtPrezime" runat="server"></asp:TextBox>
            </p>
                        <p>
                <asp:Label ID="Label4" runat="server" Text="Unesite e-mail:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label5" runat="server" Text="Unesite korisnicko ime:"></asp:Label>
                <asp:TextBox ID="txtKorisnickoIme" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label6" runat="server" Text="Unesite lozinku:"></asp:Label>
                <asp:TextBox ID="txtLozinka" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label7" runat="server" Text="Potvrdite lozinku:"></asp:Label>
                <asp:TextBox ID="txtPotvrdiLozinku" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <asp:Button ID="Sacuvaj" runat="server" Text="Sacuvaj" OnClick="Sacuvaj_Click"/>
        </div>

        <p>
            &nbsp;</p>

    </form>
</body>
</html>
