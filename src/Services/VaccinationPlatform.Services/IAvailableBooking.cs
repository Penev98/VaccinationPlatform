using System;
using System.Collections.Generic;
using System.Text;

namespace VaccinationPlatform.Services
{
    public interface IAvailableBooking
    {
        public bool IsBookingAvailable(int hospitalId, DateTime dateToCheck);

        public bool IsBookingInThePast(DateTime dateToCheck);
    }
}
