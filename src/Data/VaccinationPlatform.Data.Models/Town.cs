namespace VaccinationPlatform.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using VaccinationPlatform.Data.Common.Models;

    public class Town : BaseModel<int>
    {
        public Town()
        {
            this.Hospitals = new HashSet<Hospital>();
            this.Bookings = new HashSet<Booking>();
        }

        [Required]
        public string Name { get; set; }

        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        public virtual ICollection<Hospital> Hospitals { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
