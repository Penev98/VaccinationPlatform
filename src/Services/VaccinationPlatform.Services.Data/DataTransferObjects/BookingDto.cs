using System;
using System.Collections.Generic;
using System.Text;

namespace VaccinationPlatform.Services.Data.DataTransferObjects
{
    public class BookingDto
    {
        public int DistrictId { get; set; }

        public int TownId { get; set; }

        public int HospitalId { get; set; }

        public int DiseaseId { get; set; }

        public int VaccineId { get; set; }

        public DateTime BookingDate { get; set; }

        public string OtherInfo { get; set; }

    }
}
