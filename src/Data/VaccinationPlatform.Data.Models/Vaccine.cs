namespace VaccinationPlatform.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using VaccinationPlatform.Data.Common.Models;

    public class Vaccine : BaseModel<int>
    {
        public Vaccine()
        {
            this.Hospitals = new HashSet<Hospital>();
            this.Bookings = new HashSet<Booking>();
        }

        [Required]
        public string Name { get; set; }

        public string Information { get; set; }

        public int DiseaseId { get; set; }

        public virtual Disease Disease { get; set; }

        public virtual ICollection<Hospital> Hospitals { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
