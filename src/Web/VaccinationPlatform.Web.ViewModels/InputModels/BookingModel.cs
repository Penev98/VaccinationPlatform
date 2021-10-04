namespace VaccinationPlatform.Web.ViewModels.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services;
    using VaccinationPlatform.Services.Mapping;

    public class BookingModel : IMapFrom<Booking>, IValidatableObject
    {
        [Required]
        public int DistrictId { get; set; }

        public string DistrictName { get; set; }

        [Required]
        public int TownId { get; set; }

        public string TownName { get; set; }

        [Required]
        public int HospitalId { get; set; }

        public string HospitalName { get; set; }

        [Required]
        public int DiseaseId { get; set; }

        public string DiseaseName { get; set; }

        [Required]
        public int VaccineId { get; set; }

        public string VaccineName { get; set; }

        [Display(Name = "Date of Booking")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Display(Name = "Other Information")]
        [DataType(DataType.MultilineText)]
        public string OtherInfo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IList<ValidationResult> results = new List<ValidationResult>();

            // if date is binded correctly
            if (this.BookingDate.Year > 0001)
            {
                var freeDateCheck = this.CheckFreeDate(validationContext);
                var pastDateCheck = this.CheckPastDate(validationContext);
                results.Add(freeDateCheck);
                results.Add(pastDateCheck);
            }

            return results;
        }

        private ValidationResult CheckFreeDate(ValidationContext validationContext)
        {
            var service = (IAvailableBooking)validationContext.GetService(typeof(IAvailableBooking));

            bool result = service.IsBookingAvailable(this.HospitalId, this.BookingDate);

            if (result == false)
            {
                 return new ValidationResult("This date is already booked for this hospital.", new[] { "BookingDate" });
            }

            return ValidationResult.Success;
        }

        private ValidationResult CheckPastDate(ValidationContext validationContext)
        {
            var service = (IAvailableBooking)validationContext.GetService(typeof(IAvailableBooking));

            bool result = service.IsBookingInThePast(this.BookingDate);

            if (result == true)
            {
                return new ValidationResult("Date cannot be in the past.", new[] { "BookingDate" });
            }

            return ValidationResult.Success;
        }
    }
}
