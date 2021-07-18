namespace VaccinationPlatform.Data.Seeding.SeedData
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;

    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services.Data.DataTransferObjects;

    public class ImagesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var imageDtos = JsonSerializer.Deserialize<List<ImageDto>>(File.ReadAllText(@"..\..\Data\VaccinationPlatform.Data\Seeding\SeedData\images.json"));

            foreach (var dto in imageDtos)
            {
                Image image = new Image();
                image.Url = dto.url;
                image.HospitalId = dto.hospitalId;

                await dbContext.Images.AddAsync(image);
            }
        }
    }
}
