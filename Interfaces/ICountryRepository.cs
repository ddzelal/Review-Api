using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app1.Models;

namespace web_app1.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromCountry(int coutryId);
        bool CountryExist(int id);

    }
}