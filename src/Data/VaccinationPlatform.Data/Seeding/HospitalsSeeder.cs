using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using VaccinationPlatform.Data.Models;
using System.IO;
using VaccinationPlatform.Services.Data.DataTransferObjects;

namespace VaccinationPlatform.Data.Seeding
{
    public class HospitalsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var hospitalDtos = JsonSerializer.Deserialize<List<HospitalDto>>(File.ReadAllText(@"D:\repos\test\src\Data\VaccinationPlatform.Data\Seeding\SeedData\hospitals.json"));

            foreach (var dto in hospitalDtos)
            {
                Hospital hospital = new Hospital();
                hospital.Name = dto.name;
                hospital.Description = dto.description;
                hospital.TownId = dto.townId;

                await dbContext.Hospitals.AddAsync(hospital);
            }
        }
    }
}
