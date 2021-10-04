namespace VaccinationPlatform.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using VaccinationPlatform.Data.Common.Repositories;

    public class AvailableBooking : IAvailableBooking
    {

        private readonly IDeletableEntityRepository<VaccinationPlatform.Data.Models.Booking> bookingRepo;

        public AvailableBooking(IDeletableEntityRepository<VaccinationPlatform.Data.Models.Booking> bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public bool IsBookingAvailable(int hospitalId, DateTime dateToCheck)
        {
            var bookingCheck = this.bookingRepo.AllAsNoTracking().Where(x => x.HospitalId == hospitalId && x.BookingDate.Equals(dateToCheck)).FirstOrDefault();

            if (bookingCheck == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsBookingInThePast(DateTime dateToCheck)
        {
            int result = dateToCheck.CompareTo(DateTime.Now);

            if (result == -1)
            {
                return true;
            }

            return false;
        }
    }
}
