namespace VaccinationPlatform.Services.Data.Booking
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using VaccinationPlatform.Data.Common.Repositories;
    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services.Mapping;
    using VaccinationPlatform.Web.ViewModels.InputModels;

    public class BookingService : IBookingService
    {
        private readonly IDeletableEntityRepository<VaccinationPlatform.Data.Models.Booking> bookingRepo;

        public BookingService(IDeletableEntityRepository<VaccinationPlatform.Data.Models.Booking> bookingRepo, UserManager<ApplicationUser> userManager)
        {
            this.bookingRepo = bookingRepo;
        }

        public async Task CancelBookingAsync(int bookingId)
        {
           var bookingToCancel = this.bookingRepo.All().Where(x => x.Id == bookingId).FirstOrDefault();

           if (bookingToCancel != null)
            {
                this.bookingRepo.Delete(bookingToCancel);
            }

           await this.bookingRepo.SaveChangesAsync();
        }

        public Task RemoveBooking(int bookingId)
        {
            var bookingToRemove = this.bookingRepo.All().Where(x => x.Id == bookingId).FirstOrDefault();

            if (bookingToDelete != null)
            {
                this.bookingRepo.Delete(bookingToDelete);
            }

            await this.bookingRepo.SaveChangesAsync();
        }

        public async Task CreateBookingAsync(BookingModel model, string bookedByUserId)
        {
            VaccinationPlatform.Data.Models.Booking booking = new VaccinationPlatform.Data.Models.Booking()
            {
                DistrictId = model.DistrictId,
                TownId = model.TownId,
                HospitalId = model.HospitalId,
                DiseaseId = model.DiseaseId,
                VaccineId = model.VaccineId,
                BookingDate = model.BookingDate,
                OtherInfo = model.OtherInfo,
                BookedById = bookedByUserId,
            };

            await this.bookingRepo.AddAsync(booking);

            await this.bookingRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetBookingsByUserId<T>(string userId)
        {
            return this.bookingRepo.AllWithDeleted().Where(x => x.BookedById == userId /* && x.isRemoved == false*/).OrderBy(x => x.IsDeleted).To<T>().ToList();
        }
    }
}
