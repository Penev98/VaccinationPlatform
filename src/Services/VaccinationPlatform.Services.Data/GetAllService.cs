namespace VaccinationPlatform.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using VaccinationPlatform.Data.Common.Repositories;
    using VaccinationPlatform.Data.Models;

    public class GetAllService : IGetAllService
    {
        private readonly IRepository<District> districtsRepo;
        private readonly IRepository<Town> townsRepo;
        private readonly IRepository<Hospital> hospitalsRepo;
        private readonly IRepository<Disease> diseasesRepo;
        private readonly IRepository<Vaccine> vaccinesRepo;

        public GetAllService(IRepository<District> districtsRepo, IRepository<Town> townsRepo, IRepository<Hospital> hospitalsRepo, IRepository<Disease> diseasesRepo, IRepository<Vaccine> vaccinesRepo)
        {
            this.districtsRepo = districtsRepo;
            this.townsRepo = townsRepo;
            this.hospitalsRepo = hospitalsRepo;
            this.diseasesRepo = diseasesRepo;
            this.vaccinesRepo = vaccinesRepo;
        }

        public IEnumerable<KeyValuePair<string, string>> GetDiseases()
        {
            var diseases = this.diseasesRepo.AllAsNoTracking()
                .Select(x => new { x.Id, x.Name })
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

            return diseases;
        }

        public IEnumerable<KeyValuePair<string, string>> GetDistricts()
        {
            return this.districtsRepo.AllAsNoTracking()
               .Select(x => new
               {
                   x.Id,
                   x.Name,
               }).Take(27).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<KeyValuePair<string, string>> GetHospitalsByTown(int townId)
        {
            var hospitals = this.hospitalsRepo.AllAsNoTracking()
                .Where(x => x.TownId != 89 && x.TownId == townId) // Town with ID 89 is a test town
                .Select(x => new { x.Id, x.Name })
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

            return hospitals;
        }

        public IEnumerable<KeyValuePair<string, string>> GetTownsByDistrict(int districtId)
        {
            var towns = this.townsRepo.AllAsNoTracking()
                .Where(x => x.Id != 89 && x.DistrictId == districtId)
                .Select(x => new { x.Id, x.Name })
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

            return towns;
        }

        public IEnumerable<KeyValuePair<string, string>> GetVaccinesByDisease(int diseaseId)
        {
            var vaccines = this.vaccinesRepo.AllAsNoTracking()
                .Where(x => x.DiseaseId == diseaseId)
                .Select(x => new { x.Id, x.Name })
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

            return vaccines;
        }
    }
}
