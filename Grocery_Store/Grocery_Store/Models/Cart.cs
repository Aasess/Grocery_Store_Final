namespace Grocery_Store.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Item item, int quantity)
        {
            var cartItem = Items.FirstOrDefault(i => i.Item.Id == item.Id);
            if (cartItem == null)
            {
                Items.Add(new CartItem { Item = item, Quantity = quantity });
            }
            else
            {
                cartItem.Quantity += quantity;
            }
        }

        public void RemoveItem(int itemId)
        {
            var cartItem = Items.FirstOrDefault(i => i.Item.Id == itemId);
            if (cartItem != null)
            {
                Items.Remove(cartItem);
            }
        }

        public decimal TotalPrice => Items.Sum(i => i.Item.Price * i.Quantity);
    }
}



