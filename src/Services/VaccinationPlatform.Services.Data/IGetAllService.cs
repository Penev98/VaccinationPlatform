namespace VaccinationPlatform.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using VaccinationPlatform.Data.Models;

    public interface IGetAllService
    {
        public IEnumerable<KeyValuePair<string, string>> GetDistricts();

        public IEnumerable<KeyValuePair<string, string>> GetTownsByDistrict(int districtId);

        public IEnumerable<KeyValuePair<string, string>> GetHospitalsByTown(int townId);

        public IEnumerable<KeyValuePair<string, string>> GetDiseases();

        public IEnumerable<KeyValuePair<string, string>> GetVaccinesByDisease(int diseaseId);

    }
}
