using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();

        Country GetCountry(int id);
        Country GetCountryByUser(int userId);
        bool CountryExists(int id);

        bool CreateContry(Country country);

        bool UpdateCountry(Country country);
        bool Save();
        bool DeleteCountry(Country country);
    }   
}
