namespace VaccinationPlatform.Services.Data.Booking
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using VaccinationPlatform.Web.ViewModels.InputModels;

    public interface IBookingService
    {
        public Task CreateBookingAsync(BookingModel model, string bookedByUserId);

        public IEnumerable<T> GetBookingsByUserId<T>(string userId);

        public Task CancelBookingAsync(int bookingId);

        public Task RemoveBooking(int bookingId);

    }
}
