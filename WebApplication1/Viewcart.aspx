<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viewcart.aspx.cs" Inherits="WebApplication1.Viewcart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <a href="WebForm1.aspx">Products</a>
    <form id="form1" runat="server">
        <div>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th>Id </th>
                        <th>Image </th>
                        <th>Name </th>
                        <th>Price </th>
                        <th>Quantity </th>
                        <th>Sub Total </th>
                        <th>Cancel </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Id") %></td>
                                <td>
                                    <img src="images/<%# Eval("Image") %>" alt="img" width="80px" height="40px" />
                                </td>
                                <td><%# Eval("Name") %></td>
                                <td><%# Eval("Price") %></td>
                                <td><%# Eval("Qty") %></td>
                                <td><%# Eval("subt") %></td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="X"  CssClass="btn btn-sm btn-danger" OnCommand="Button1_Command" CommandName="cancel" CommandArgument='<%# Eval("Id") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div class="container">
                <p>Total Quantity : <%: Session["tqty"].ToString() %></p>
                <br />
                <p>Total Price+ : <%: Session["totalPrice"].ToString() %></p>
            </div>
        </div>
    </form>
</body>
</html>
