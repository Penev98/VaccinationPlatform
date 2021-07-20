namespace VaccinationPlatform.Web.ViewModels.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services.Mapping;

    public class AllBookingsInfoViewModel : IMapFrom<Booking>
    {
        public string Id { get; set; }

        public int DistrictId { get; set; }

        public string DistrictName { get; set; }

        public int TownId { get; set; }

        public string TownName { get; set; }

        public int HospitalId { get; set; }

        public string HospitalName { get; set; }

        public int DiseaseId { get; set; }

        public string DiseaseName { get; set; }

        public int VaccineId { get; set; }

        public string VaccineName { get; set; }

        public DateTime BookingDate { get; set; }

        public string OtherInfo { get; set; }

        public string BookedById { get; set; }

        public string IdentityUserId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
