namespace VaccinationPlatform.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using VaccinationPlatform.Data.Seeding.SeedData;

    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

            var seeders = new List<ISeeder>
                          {
                                   // Uncomment if you start the app for the first time -> the first start will seed the data in the database

                                 // new RolesSeeder(),
                                // new DistrictSeeder(),
                               // new TownSeeder(),
                              // new HospitalsSeeder(),
                             // new DiseasesSeeder(),
                            // new VaccinesSeeder(),
                           // new ImagesSeeder(),
                          };

            if (seeders.Count > 0)
            {
                foreach (var seeder in seeders)
                {
                    await seeder.SeedAsync(dbContext, serviceProvider);
                    await dbContext.SaveChangesAsync();
                    logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
                }
            }
        }
    }
}
