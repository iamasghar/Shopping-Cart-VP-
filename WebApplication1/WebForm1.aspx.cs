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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                /* DataTable dt = new DataTable();
                  dt.Columns.Add("ID");
                  dt.Columns.Add("product_name");
                  dt.Columns.Add("Image");
                  dt.Columns.Add("price");
                  dt.Rows.Add("1", "TCU", "images/682699.jpg", "100");
                  dt.Rows.Add("3", "uct", "images/935484.jpg", "700");
                  dt.Rows.Add("2", "rty", "images/972103.jpg", "500");
                  dt.Rows.Add("11", "TasdCU", "images/935484.jpg", "300");
                  dt.Rows.Add("13", "uasdct", "images/972103.jpg", "600");
                  dt.Rows.Add("12", "rwety", "images/682699.jpg", "900");
                  mydatalist.DataSource = dt;
                  mydatalist.DataBind(); */
                ProductBLL productBLL = new ProductBLL();
                DataTable dt = productBLL.GetAllProducts();
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }



        }
        protected void asasas_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "asasas")
            {
                //Response.Write(@"<script>alert("+e.CommandArgument.ToString()+");</script>");
                int id = Int16.Parse(e.CommandArgument.ToString());
                Product p = new Product();
                p.Id = id;
                ProductBLL productBLL = new ProductBLL();
                DataTable dt = productBLL.SearchProduct(p);
                p.Name = dt.Rows[0]["Name"].ToString();
                p.Image = dt.Rows[0]["Image"].ToString();
                p.Price = float.Parse(dt.Rows[0]["Price"].ToString());
                p.Description = dt.Rows[0]["Description"].ToString();
                Cart cart = null;
                if (Session["cart"] != null)
                {
                    cart = (Cart)Session["cart"];
                }
                Cart newCart = new Cart(cart);
                if (newCart.AddToCart(p, 1))
                {
                    Response.Write(@"<script language='javascript'>alert('Item Added to Cart');</script>");
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Item not Added to Cart');</script>");
                }
                Session["cart"] = newCart; 
            }
        }
    }
}