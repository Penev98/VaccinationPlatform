namespace VaccinationPlatform.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using VaccinationPlatform.Data.Common.Models;

    public class District : BaseModel<int>
    {
        public District()
        {
            this.Towns = new HashSet<Town>();
            this.Bookings = new HashSet<Booking>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
