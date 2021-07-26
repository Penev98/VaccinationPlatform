namespace VaccinationPlatform.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services.Mapping;

    public class VaccineViewModel : IMapFrom<Vaccine>
    {
        public string Name { get; set; }

        public string Information { get; set; }
    }
}
