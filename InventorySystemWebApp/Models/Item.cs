namespace InventorySystemWebApp.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
