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

    public class VaccinesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var vaccineDtos = JsonSerializer.Deserialize<List<VaccineDto>>(File.ReadAllText(@"..\..\Data\VaccinationPlatform.Data\Seeding\SeedData\vaccines.json"));

            foreach (var dto in vaccineDtos)
            {
                Vaccine vaccine = new Vaccine();
                vaccine.Name = dto.name;
                vaccine.Information = dto.information;
                vaccine.DiseaseId = dto.diseaseId;

                await dbContext.Vaccines.AddAsync(vaccine);
            }
        }
    }
}
