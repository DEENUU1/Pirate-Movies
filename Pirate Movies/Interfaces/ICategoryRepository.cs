using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        bool CategoryCreate(Category category);
        bool CategoryExists(int id);
        bool Save();
    }
}
