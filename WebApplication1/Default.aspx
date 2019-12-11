<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container pt-5">
            <div class="row pt-5">
                <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <ItemTemplate>
                        <div class="col-sm-12 " style="padding: 15px;">
                            <div class="row p-5">
                                <div class="col-sm-6">
                                    <img src="./Images/<%#Eval("Image") %>" alt="img" width="100%" />
                                </div>
                                <div class="col-sm-6 pt-5" style="padding-top: 120px; padding-left: 20px">
                                    <h3><%#Eval("Name") %></h3>
                                    <b>Rs: <%#Eval("Price") %></b>
                                    <br />
                                    <p><%#Eval("Description") %></p>
                                    <br />
                                    <br />
                                    <asp:Button ID="Button1" runat="server" Text="Add to Cart" OnCommand="asasas_Command" CommandName="asasas" CommandArgument='<%# Eval("Id")%>' CssClass="btn btn-danger" />
                                    <a href="WebForm1.aspx" class="btn btn-info">Back</a>
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
