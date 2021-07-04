namespace VaccinationPlatform.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using VaccinationPlatform.Data.Common.Models;

    public class Hospital : BaseModel<int>
    {
        public Hospital()
        {
            this.Vaccines = new HashSet<Vaccine>();
            this.Bookings = new HashSet<Booking>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Vaccine> Vaccines { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
