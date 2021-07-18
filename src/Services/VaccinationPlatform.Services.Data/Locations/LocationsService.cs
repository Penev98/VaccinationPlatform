namespace VaccinationPlatform.Services.Data.Locations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using VaccinationPlatform.Data.Common.Repositories;
    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services.Mapping;

    public class LocationsService : ILocationService
    {
        private readonly IRepository<Hospital> hospitalsRepo;

        public LocationsService(IRepository<Hospital> hospitalsRepo)
        {
            this.hospitalsRepo = hospitalsRepo;
        }

        public IEnumerable<T> GetModels<T>()
        {
            return this.hospitalsRepo.AllAsNoTracking().Skip(4).To<T>().ToList();
        }
    }
}
