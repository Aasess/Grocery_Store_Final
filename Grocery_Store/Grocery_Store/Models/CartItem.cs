namespace Grocery_Store.Models
{

    public class CartItem
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public  decimal TotalPrice { get; set; }
    }
}   

