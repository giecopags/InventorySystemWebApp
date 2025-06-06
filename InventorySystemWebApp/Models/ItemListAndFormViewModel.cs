namespace InventorySystemWebApp.Models
{
    public class ItemListAndFormViewModel
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public Item NewItem { get; set; } = new Item();
    }
}
