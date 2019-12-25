using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Bageri_20.Models
{
    // kopplas ihop med interfacet för klassen Contact
    public class ContactRepositoryMock : IContact
    {
        // interfacet till klassen IContact kopplas hit, dvs 
        // klassen implementerar interface IContact
        // tillfälligt testdata, används för att testa data utan databasanrop
        // kallas att "mocka databasanrop" (simulera databasanrop)
        public Contact GetContact()
        {
            Contact kontakt = new Contact();
            kontakt.Id = 1;
            kontakt.Name = "Baka på nätet";
            kontakt.WebbPage = "www.bakeonnet.se";
            kontakt.StreetAdress = "Bakagatan 1";
            kontakt.CityAdress = "755 90 Nätstaden";
            kontakt.Mail = "bakeonnet@gmail.com";
            kontakt.Phone = "012-34 56 789";
            return kontakt;
        }
    }
}
