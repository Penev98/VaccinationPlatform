using System;
using System.Collections.Generic;
using System.Text;
using VaccinationPlatform.Data.Models;

namespace VaccinationPlatform.Services.Data
{
    public interface IGetAllService
    {
        public IEnumerable<KeyValuePair<string , string>> GetDistricts();

        public IEnumerable<KeyValuePair<string, string>> GetTowns();

        public IEnumerable<KeyValuePair<string, string>> GetHospitals();

        public IEnumerable<KeyValuePair<string, string>> GetDiseases();

        public IEnumerable<KeyValuePair<string, string>> GetVaccines();

    }
}
