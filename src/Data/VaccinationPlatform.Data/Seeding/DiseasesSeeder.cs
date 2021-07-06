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

    public class DiseasesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var diseaseDtos = JsonSerializer.Deserialize<List<DiseaseDto>>(File.ReadAllText(@"D:\repos\test\src\Data\VaccinationPlatform.Data\Seeding\SeedData\diseases.json"));

            foreach (var dto in diseaseDtos)
            {
                Disease disease = new Disease();
                disease.Name = dto.name;
                disease.Information = dto.information;

                await dbContext.Diseases.AddAsync(disease);
            }

        }
    }
}
