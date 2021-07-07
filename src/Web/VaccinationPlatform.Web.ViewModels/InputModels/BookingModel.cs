namespace VaccinationPlatform.Web.ViewModels.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using VaccinationPlatform.Data.Models;

    public class BookingModel
    {
        // public int DistrictId { get; set; }

        // public int TownId { get; set; }

        // public int HospitalId { get; set; }

        // public int DiseaseId { get; set; }

        // public int VaccineId { get; set; }

        [Required]
        public IEnumerable<KeyValuePair<string, string>> Districts { get; set; }

        public string District { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string Hospital { get; set; }

        [Required]
        public string Disease { get; set; }

        [Required]
        public string Vaccine { get; set; }

        [Display(Name = "Date of Booking")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Display(Name = "Other Information")]
        [DataType(DataType.MultilineText)]
        public string OtherInfo { get; set; }
    }
}
