namespace VaccinationPlatform.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services.Mapping;

    public class ShowBookingViewModel : IMapFrom<Booking>
    {
        public string Id { get; set; }

        public string DistrictName { get; set; }

        public string TownName { get; set; }

        public string HospitalName { get; set; }

        public string DiseaseName { get; set; }

        public string VaccineName { get; set; }

        public DateTime BookingDate { get; set; }

        public bool IsDeleted { get; set; }

    }
}
