namespace Lumivate.TurtleStore.Models
{
    // TODO-checkpoint-6 part A: Create the Order model class
    // This class represents a customer order.
    // Add the following properties:
    //   - Id (int)
    //   - CustomerName (string)
    //   - OrderDate (DateTime)
    //   - Items (List<OrderItem>) - the line items in this order
    //   - Total (decimal) - computed from the items
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal Total { get; set; }
    }
}
