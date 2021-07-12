using System;
using System.Collections.Generic;
using System.Text;
using VaccinationPlatform.Data.Models;
using VaccinationPlatform.Services.Mapping;

namespace VaccinationPlatform.Web.ViewModels
{
  public class ShowBookingViewModel : IMapFrom<Booking>
    {
        public int Id { get; set; }

        public string DistrictName { get; set; }

        public string TownName { get; set; }

        public string HospitalName { get; set; }

        public string DiseaseName { get; set; }

        public string VaccineName { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
