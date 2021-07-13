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

        public Task RemoveBookingAsync(int bookingId);

        public Task EditBookingAsync(BookingModel newModel, int bookingId);

        public T GetUserBooking<T>(int bookingId, string userId);
    }
}
