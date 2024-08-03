using System.ComponentModel.DataAnnotations;

namespace Grocery_Store.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Please enter a item name.")]
        public string Name { get; set; }

        [Range(0.0, 1000000.0, ErrorMessage = "Price must be more than 0.")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        // foreign key property
        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        // navigation properties
        public Category Category { get; set; }
    }
}
