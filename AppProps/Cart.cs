using System.Collections.Generic;
using System.Linq;

namespace AppProps
{
    public class Cart
    {
        public List<MyProduct> items = null;
        public int totalQty = 0;
        public float totalPrice = 0;

        public Cart(Cart OldCart)
        {
            if (OldCart != null)
            {
                items = OldCart.items;
                totalQty = OldCart.totalQty;
                totalPrice = OldCart.totalPrice;
            }
        }
        public bool AddToCart(Product product, int qty)
        {
            if (items == null)
            {
                MyProduct myProduct = new MyProduct();
                myProduct.product = product;
                myProduct.quantity = qty;
                myProduct.subTotal = product.Price * qty;
                items = new List<MyProduct>();
                items.Add(myProduct);
                totalQty++;
                totalPrice = myProduct.subTotal;
                return true;
            }
            else
            {
                MyProduct previousItem = items.FirstOrDefault(x => x.product.Id == product.Id);
                if (previousItem != null)
                {
                    totalPrice = qty * previousItem.product.Price + totalPrice;
                    totalQty++;
                    previousItem.quantity = previousItem.quantity + qty;
                    previousItem.subTotal += qty * previousItem.product.Price;
                    return true;
                }
                else
                {
                    MyProduct myProduct = new MyProduct();
                    myProduct.product = product;
                    myProduct.quantity = qty;
                    myProduct.subTotal = product.Price * qty;
                    items.Add(myProduct);
                    totalQty++;
                    totalPrice = myProduct.subTotal + totalPrice;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveFromCart(Product product, int qty)
        {
            MyProduct Item = items.FirstOrDefault(x => x.product.Id == product.Id);
            if (Item != null)
            {
                if (Item.quantity == qty)
                {
                    float dprice = (Item.product.Price * qty);
                    totalPrice -= dprice;
                    totalQty -= qty;
                    items.Remove(Item);
                    return true;
                }
                else if (Item.quantity > 1)
                {
                    Item.quantity -= qty;
                    float dprice = (Item.product.Price * qty);
                    Item.subTotal -= dprice;
                    totalPrice -= dprice;
                    totalQty -= qty;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

    public class MyProduct
    {
        public Product product;
        public int quantity;
        public float subTotal;
    }
}
