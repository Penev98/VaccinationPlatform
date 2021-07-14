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

        public Task CancelBookingAsync(string bookingId);

        public Task RemoveBookingAsync(string bookingId);

        public Task EditBookingAsync(BookingModel newModel, string bookingId);

        public T GetUserBooking<T>(string bookingId, string userId);
    }
}
