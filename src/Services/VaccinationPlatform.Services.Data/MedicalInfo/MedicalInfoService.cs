namespace VaccinationPlatform.Services.Data.MedicalInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using VaccinationPlatform.Data.Common.Repositories;
    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services.Mapping;

    public class MedicalInfoService : IMedicalInfoService
    {
        private readonly IRepository<Disease> diseasesRepo;

        public MedicalInfoService(IRepository<Disease> diseasesRepo)
        {
            this.diseasesRepo = diseasesRepo;
        }

        public IEnumerable<string> GetAllDiseaseNames()
        {
            return this.diseasesRepo.AllAsNoTracking().Select(x => x.Name).ToList();
        }

        public IEnumerable<T> GetDiseases<T>()
        {
            return this.diseasesRepo.AllAsNoTracking().To<T>().ToList();
        }
    }
}
