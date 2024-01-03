using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }


        public bool CountryExists(int id)
        {
            return _context.Coutries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Coutries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Coutries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByUser(int userId)
        {
            return _context.Users.Where(u => u.Id == userId).Select(c => c.Country).FirstOrDefault();
        }

        public bool CreateContry(Country country)
        {
            _context.Coutries.Add(country);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}