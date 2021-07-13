namespace VaccinationPlatform.Services.Data.Booking
{
    using System;
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

        public async Task RemoveBookingAsync(int bookingId)
        {
            var bookingToRemove = this.bookingRepo.AllWithDeleted().Where(x => x.Id == bookingId).FirstOrDefault();

            if (bookingToRemove != null)
            {
                this.bookingRepo.HardDelete(bookingToRemove);
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
            return this.bookingRepo.AllWithDeleted().Where(x => x.BookedById == userId).OrderBy(x => x.IsDeleted).To<T>().ToList();
        }

        public T GetUserBooking<T>(int bookingId, string userId)
        {
            var bookingModel = this.bookingRepo.All().Where(x => x.BookedById == userId).Where(x => x.Id == bookingId).To<T>().FirstOrDefault();

            return bookingModel;
        }

        public async Task EditBookingAsync(BookingModel newModel, int bookingId)
        {
            var bookingToEdit = this.bookingRepo.All().Where(x => x.Id == bookingId).FirstOrDefault();

            if (bookingToEdit != null)
            {
                bookingToEdit.DistrictId = newModel.DistrictId;
                bookingToEdit.TownId = newModel.TownId;
                bookingToEdit.HospitalId = newModel.HospitalId;
                bookingToEdit.DiseaseId = newModel.DiseaseId;
                bookingToEdit.VaccineId = newModel.VaccineId;
                bookingToEdit.BookingDate = newModel.BookingDate;
                bookingToEdit.OtherInfo = newModel.OtherInfo;
            }

            await this.bookingRepo.SaveChangesAsync();
        }
    }
}
