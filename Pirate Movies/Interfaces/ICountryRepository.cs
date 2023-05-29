using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
    }
}
