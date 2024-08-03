using System.ComponentModel.DataAnnotations;

namespace Grocery_Store.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a category name.")]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
