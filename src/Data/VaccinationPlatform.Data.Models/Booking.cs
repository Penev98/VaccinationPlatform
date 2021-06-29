namespace VaccinationPlatform.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using VaccinationPlatform.Data.Common.Models;

    public class Booking : BaseDeletableModel<int>
    {
        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public int HospitalId { get; set; }

        public virtual Hospital Hospital { get; set; }

        public int DiseaseId { get; set; }

        public virtual Disease Disease { get; set; }

        public int VaccineId { get; set; }

        public virtual Vaccine Vaccine { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        public string OtherInfo { get; set; }

        public string BookedById { get; set; }

        public virtual ApplicationUser BookedBy { get; set; }
    }
}
