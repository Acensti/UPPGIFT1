using FIXXOUPPGIFT.Models.Dtos;

namespace FIXXOUPPGIFT.ViewModels
{
    public class CollectionViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
