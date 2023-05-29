using Pirate_Movies.Models;

namespace Pirate_Movies.Repository
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
    }
}
