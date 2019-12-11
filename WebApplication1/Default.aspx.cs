using AppProps;
using BLL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int prd = Convert.ToInt32(Request.Params["prd"]);
                Product p = new Product();
                p.Id = prd;
                ProductBLL productBLL = new ProductBLL();
                DataList1.DataSource = productBLL.SearchProduct(p);
                DataList1.DataBind();
            }

        }

        protected void asasas_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "asasas")
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