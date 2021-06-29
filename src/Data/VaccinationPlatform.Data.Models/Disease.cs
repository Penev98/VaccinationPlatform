namespace VaccinationPlatform.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using VaccinationPlatform.Data.Common.Models;

    public class Disease : BaseModel<int>
    {
        public Disease()
        {
            this.Vaccines = new HashSet<Vaccine>();
            this.Bookings = new HashSet<Booking>();
        }

        [Required]
        public string Name { get; set; }

        public string Information { get; set; }

        public virtual ICollection<Vaccine> Vaccines { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

    }
}
