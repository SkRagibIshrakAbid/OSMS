using System;
using System.Collections.Generic;

namespace Online_Shopping_Test
{
    // Encapsulate product data and functionality
    public class Product
    {
        // Define product properties
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        // Define a constructor to initialize product values
        public Product(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        // Define a method to display product information
        public virtual void ShowProduct()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Description: " + Description);
        }
    }

    // Model a shopping cart as a collection of products
    public class ShoppingCart
    {
        // Define a list of products as a property
        public List<Product> Products { get; set; }

        // Define a constructor to initialize an empty list of products
        public ShoppingCart()
        {
            Products = new List<Product>();
        }

        // Define a method to add a product to the shopping cart
        public void AddProduct(Product product)
        {
            Products.Add(product);
            Console.WriteLine(product.Name + " added to cart.");
        }

        // Define more methods for removing, editing, reviewing products ...
    }

    // Model an order as a collection of order details
    public class Order
    {
        // Define a list of order details as a property
        public List<OrderDetail> OrderDetails { get; set; }

        // Define a property to calculate the total cost of the order
        public decimal TotalCost
        {
            get
            {
                decimal total = 0;
                foreach (OrderDetail od in OrderDetails)
                {
                    total += od.Subtotal;
                }
                return total;
            }
        }

        // Define a constructor to initialize an empty list of order details
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        // Define a method to create an order from a shopping cart
        public void CreateOrder(ShoppingCart cart)
        {
            foreach (Product p in cart.Products)
            {
                // Create an order detail for each product in the cart
                OrderDetail od = new OrderDetail(p, 1); // Assume quantity is 1 for simplicity
                                                        // Add the order detail to the order
                OrderDetails.Add(od);
            }
            Console.WriteLine("Order created.");
        }

        // Define more methods for processing, confirming, canceling orders ...
    }

    // Model an order detail as a product with quantity and subtotal
    public class OrderDetail : Product // Inherit from Product class 
    {
        // Define quantity as a property 
        public int Quantity { get; set; }

        // Define subtotal as a property that calculates the product price times quantity 
        public decimal Subtotal
        {
            get
            {
                return Price * Quantity;
            }
        }

        // Define a constructor that takes a product and a quantity as parameters 
        public OrderDetail(Product product, int quantity) : base(product.Name, product.Price, product.Description) // Call base constructor with product values 
        {
            Quantity = quantity;
        }

        // Override ShowProduct method to display order detail information 
        public override void ShowProduct()
        {
            base.ShowProduct(); // Call base method to show product information 
            Console.WriteLine("Quantity: " + Quantity);
            Console.WriteLine("Subtotal: " + Subtotal);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
