namespace VaccinationPlatform.Services.Data.Booking
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using VaccinationPlatform.Data.Common.Repositories;
    using VaccinationPlatform.Web.ViewModels.InputModels;

    public class BookingService : IBookingService
    {
        private readonly IDeletableEntityRepository<VaccinationPlatform.Data.Models.Booking> bookingRepo;

        public BookingService(IDeletableEntityRepository<VaccinationPlatform.Data.Models.Booking> bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public async Task CreateBookingAsync(BookingModel model)
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
            };

            await this.bookingRepo.AddAsync(booking);

            await this.bookingRepo.SaveChangesAsync();
        }
    }
}
