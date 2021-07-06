namespace VaccinationPlatform.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VaccinationPlatform.Data.Models;

    public class DistrictsSeeder : ISeeder
    {
        // District name is at the 5th index in the scv line
        private const int DistrictNameIndex = 5;

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
                                                         // TODO: Use a relative path
            string input = await File.ReadAllTextAsync(@"D:\repos\test\src\Data\VaccinationPlatform.Data\Seeding\SeedData\districtsAndTowns.csv");
            string[] infoLine = input.Split("\r\n");

            for (int i = 0; i < infoLine.Length; i++)
            {
                string[] lineElements = infoLine[i].Split(',');

                var potentialDist = dbContext.Districts.Where(x => x.Name == lineElements[DistrictNameIndex]).FirstOrDefault();

                if (potentialDist == null)
                {
                    District dist = new District();
                    dist.Name = lineElements[DistrictNameIndex];

                    await dbContext.Districts.AddAsync(dist);
                    await dbContext.SaveChangesAsync();
                }

            }
        }
    }
}
