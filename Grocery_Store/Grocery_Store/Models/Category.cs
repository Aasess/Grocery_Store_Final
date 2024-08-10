using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Grocery_Store.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a category name.")]
        public string Name { get; set; }

        [JsonIgnore] // Prevent serialization loop
        public ICollection<Item> Items { get; set; }
    }
}
