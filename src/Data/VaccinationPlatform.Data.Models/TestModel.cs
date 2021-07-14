using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VaccinationPlatform.Data.Common.Models;

namespace VaccinationPlatform.Data.Models
{
   public class TestModel : BaseDeletableModel<int>
    {
        [Required]
        [Column(TypeName = "date")]
        public DateTime BookingDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Hour { get; set; }

    }
}
