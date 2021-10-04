namespace VaccinationPlatform.Web.Views.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using VaccinationPlatform.Services.Data;

    [ApiController]
    [Route("/api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IGetAllService getAll;

        public DataController(IGetAllService getAll)
        {
            this.getAll = getAll;
        }

        [Route("districts")]
        public IActionResult GetAllDistrictsAjax()
        {
            return this.Ok(this.getAll.GetDistricts());
        }

        [Route("towns")]
        public IActionResult GetTownsByDistrictAjax(int districtId)
        {
            return this.Ok(this.getAll.GetTownsByDistrict(districtId));
        }

        [Route("hospitals")]
        public IActionResult GetHospitalsByTownAjax(int townId)
        {
            return this.Ok(this.getAll.GetHospitalsByTown(townId));
        }

        [Route("diseases")]
        public IActionResult GetAllDiseasesAjax()
        {
            return this.Ok(this.getAll.GetDiseases());
        }

        [Route("vaccines")]
        public IActionResult GetVaccinesByDiseaseAjax(int diseaseId)
        {
            return this.Ok(this.getAll.GetVaccinesByDisease(diseaseId));
        }
    }
}
