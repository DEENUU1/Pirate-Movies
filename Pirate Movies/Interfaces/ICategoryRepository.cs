using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
    }
}
