namespace VaccinationPlatform.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using VaccinationPlatform.Services.Data.MedicalInfo;
    using VaccinationPlatform.Web.ViewModels;

    public class MedicalInfoController : Controller
    {
        private readonly IMedicalInfoService medicalInfoService;

        public MedicalInfoController(IMedicalInfoService medicalInfoService)
        {
            this.medicalInfoService = medicalInfoService;
        }

        public IActionResult Index()
        {
            var models = this.medicalInfoService.GetDiseases<MedicalInfoViewModel>();
            return this.View(models);
        }

        public JsonResult GetDiseases()
        {
            return this.Json(this.medicalInfoService.GetAllDiseaseNames());
        }
    }
}
