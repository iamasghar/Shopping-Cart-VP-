using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using AppProps;

namespace WebApplication1
{
    public partial class Viewcart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<MyProduct> items = null;
            if (!Page.IsPostBack)
            {
                if (Session["cart"] != null)
                {
                    Cart cart = (Cart)Session["cart"];
                    items = cart.items;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Id");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Image");
                    dt.Columns.Add("Price");
                    dt.Columns.Add("Qty");
                    dt.Columns.Add("subt");
                    foreach (var item in items)
                    {
                        Product p = item.product;
                        dt.Rows.Add(p.Id + "", p.Name, p.Image, p.Price, item.quantity, item.subTotal);
                    }
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();
                    Session["totalPrice"] = cart.totalPrice.ToString();
                    Session["tqty"] = cart.totalQty.ToString();

                }
                else
                {
                    Response.Redirect("WebForm1");
                }
            }
        }


        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "cancel")
            {
                //Response.Write(@"<script>alert(" + e.CommandArgument.ToString() + ");</script>");
                int id = Int16.Parse(e.CommandArgument.ToString());
                Product p = new Product();
                p.Id = id;
                ProductBLL productBLL = new ProductBLL();
                DataTable dt = productBLL.SearchProduct(p);
                p.Name = dt.Rows[0]["Name"].ToString();
                p.Image = dt.Rows[0]["Image"].ToString();
                p.Price = float.Parse(dt.Rows[0]["Price"].ToString());
                p.Description = dt.Rows[0]["Description"].ToString();
                Cart cart = (Cart)Session["cart"];
                Cart newCart = new Cart(cart);
                if (newCart.RemoveFromCart(p, 1))
                {
                    Response.Write(@"<script language='javascript'>alert('Item Removed From Cart');</script>");
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Item not Removed From Cart');</script>");
                }
                Session["cart"] = newCart;
            }
        }
    }
}