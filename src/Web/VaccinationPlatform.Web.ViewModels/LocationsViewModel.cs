using System;
using System.Collections.Generic;
using System.Text;
using VaccinationPlatform.Data.Models;
using VaccinationPlatform.Services.Mapping;

namespace VaccinationPlatform.Web.ViewModels
{
   public class LocationsViewModel : IMapFrom<Hospital>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TownDistrictId { get; set; }

        public string TownDistrictName { get; set; }

        public int TownId { get; set; }

        public string TownName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
