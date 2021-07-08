namespace VaccinationPlatform.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services.Data.DataTransferObjects;

    public class HospitalsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var hospitalDtos = JsonSerializer.Deserialize<List<HospitalDto>>(File.ReadAllText(@"..\..\Data\VaccinationPlatform.Data\Seeding\SeedData\hospitals.json"));

            foreach (var dto in hospitalDtos)
            {
                Hospital hospital = new Hospital();
                hospital.Name = dto.name;
                hospital.Description = dto.description;
                hospital.TownId = dto.townId - 85;

                await dbContext.Hospitals.AddAsync(hospital);
            }

        }
    }
}
