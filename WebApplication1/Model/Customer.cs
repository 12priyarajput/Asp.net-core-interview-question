namespace WebApplication1.Model
{
    public class Customer
    {
        public string Name { get; set; }
        public List<Order> Order { get; set; }
    }

    public class Order
    {
        public string Product { get; set; }
    }
}
