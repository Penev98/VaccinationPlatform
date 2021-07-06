namespace VaccinationPlatform.Services.Data.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HospitalDto
    {
        public string name { get; set; }

        public string description { get; set; }

        public int townId { get; set; }
    }
}
