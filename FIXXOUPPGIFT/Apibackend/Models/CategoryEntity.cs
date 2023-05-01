using System.ComponentModel.DataAnnotations;

namespace Apibackend.Models
{
    public class CategoryEntity
    {
        [Key]
		public int Id { get; set; }
		public string CategoryName { get; set; } = null!;

		public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
