using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationPlatform.Data.Models;

namespace VaccinationPlatform.Data.Seeding
{
   public class TownsSeeder : ISeeder
    {
        // Town name is at the 0th index in the csv line
        private const int TownNameIndex = 0;

        // District name is at the 5th index in the scv line
        private const int DistrictNameIndex = 5;

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
                                                            // TODO: Use a relative path
            string input = await File.ReadAllTextAsync(@"..\..\Data\VaccinationPlatform.Data\Seeding\SeedData\districtsAndTowns.csv");
            string[] infoLine = input.Split("\r\n");

            for (int i = 0; i < infoLine.Length; i++)
            {
                string[] lineElements = infoLine[i].Split(',');

                District district = dbContext.Districts.FirstOrDefault(x => x.Name == lineElements[DistrictNameIndex]);
                int distId = district.Id;

                var town = new Town();
                town.Name = lineElements[TownNameIndex];
                town.DistrictId = distId;

                await dbContext.Towns.AddAsync(town);
            }
        }
    }
}
