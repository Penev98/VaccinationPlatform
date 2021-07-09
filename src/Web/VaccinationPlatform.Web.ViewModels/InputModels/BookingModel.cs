namespace VaccinationPlatform.Web.ViewModels.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using VaccinationPlatform.Data.Models;

    public class BookingModel
    {
        [Required]
        public int DistrictId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Districts { get; set; }

        [Required]
        public int TownId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Towns { get; set; }

        [Required]
        public int HospitalId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Hospitals { get; set; }

        [Required]
        public int DiseaseId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Diseases { get; set; }

        [Required]
        public int VaccineId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Vaccines { get; set; }

        [Display(Name = "Date of Booking")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Display(Name = "Other Information")]
        [DataType(DataType.MultilineText)]
        public string OtherInfo { get; set; }
    }
}
