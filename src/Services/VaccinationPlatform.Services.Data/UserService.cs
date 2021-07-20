namespace VaccinationPlatform.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VaccinationPlatform.Data.Common.Repositories;
    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services.Mapping;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepo;

        public UserService(IDeletableEntityRepository<ApplicationUser> usersRepo)
        {
            this.usersRepo = usersRepo;
        }

        public ApplicationUser GetUserByBookingId(string bookingId)
        {
            var user = this.usersRepo.AllAsNoTrackingWithDeleted().Where(x => x.Bookings.Any(x => x.Id == bookingId)).FirstOrDefault();
            return user;
        }
    }
}
