using System;
using System.Collections.Generic;
using System.Text;
using VaccinationPlatform.Data.Models;

namespace VaccinationPlatform.Services.Data
{
   public interface IUserService
    {
        public ApplicationUser GetUserByBookingId(string bookingId);
    }
}
