using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionStore.Domain.Entities
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        // create the cart
        private List<CartLine> lineCollection = new List<CartLine>();

        //Access the content of the cart
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        //Add an item to the cart
        public void AddItem(Product myproduct, int myquantity)
        {
            //find line of item in the cart, if not return null
            CartLine line = lineCollection.Where(p => p.Product.ProductID == myproduct.ProductID).FirstOrDefault();

            //if item does not exists in cart, add it and set quantity to 1
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = myproduct,
                    Quantity = myquantity
                });
            }
            else
            {
                line.Quantity += myquantity;
            }
        }
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(p => p.Product.Price * p.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }

    }
}
