namespace VaccinationPlatform.Services.Data.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class VaccineDto
    {
        public string name { get; set; }

        public string information { get; set; }

        public int diseaseId { get; set; }

    }
}
