using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VaccinationPlatform.Web.ViewModels.InputModels;

namespace VaccinationPlatform.Services.Data.Booking
{
   public interface IBookingService
    {
        public Task CreateBookingAsync(BookingModel model);
    }
}
