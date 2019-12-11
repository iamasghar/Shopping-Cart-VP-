<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <a href="Viewcart.aspx" >Cart</a>
    <form id="form1" runat="server">
        <div class="container pt-5">
            <div class="row pt-5">
                <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <ItemTemplate>
                        <div class="col-sm-6 col-md-4 col-lg-3 " style="padding: 15px; border: 1px solid black;">
                            <div class="card">
                                <div class="card-head">
                                </div>
                                <div class="card-body">
                                    <img src="./Images/<%#Eval("Image") %>" alt="img" width="100%" />
                                    <h3><%#Eval("Name") %></h3>
                                    <p><%#Eval("Price") %></p>
                                    <asp:Button ID="asasas" runat="server" Text="Add to Cart" OnCommand="asasas_Command" CommandName="asasas" CommandArgument='<%# Eval("Id")%>' CssClass="btn btn-danger" />
                                    <a href="Default.aspx?prd=<%# Eval("Id")%>" class="btn btn-info">View Product</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </form>
</body>
</html>
