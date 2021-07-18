namespace VaccinationPlatform.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using VaccinationPlatform.Services.Data;
    using VaccinationPlatform.Services.Data.Locations;
    using VaccinationPlatform.Web.ViewModels;

    public class LocationsController : BaseController
    {
        private readonly ILocationService locationsService;
        private readonly IGetAllService getService;

        public LocationsController(ILocationService locationsService, IGetAllService getService)
        {
            this.locationsService = locationsService;
            this.getService = getService;
        }

        public IActionResult Index()
        {
            List<LocationsViewModel> locations = this.locationsService.GetModels<LocationsViewModel>().ToList();
            return this.View(locations);
        }

        [HttpGet]
        public JsonResult GetDistricts()
        {
            return this.Json(this.getService.GetDistricts());
        }

        public JsonResult GetTowns(int districtId)
        {
            return this.Json(this.getService.GetTownsByDistrict(districtId));
        }

       
    }
}
