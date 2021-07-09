namespace VaccinationPlatform.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using VaccinationPlatform.Services.Data;
    using VaccinationPlatform.Services.Data.Booking;
    using VaccinationPlatform.Web.ViewModels.InputModels;

    public class BookingController : BaseController
    {
        private readonly IGetAllService getAll;
        private readonly IBookingService bookingService;

        public BookingController(IGetAllService getAll, IBookingService bookingService)
        {
            this.getAll = getAll;
            this.bookingService = bookingService;
        }

        public IActionResult BookApointment()
        {
            BookingModel model = new BookingModel();
            model.Districts = this.getAll.GetDistricts();

            // model.Towns = this.getAll.GetTowns();
            // model.Hospitals = this.getAll.GetHospitals();
            // model.Diseases = this.getAll.GetDiseases();
            // model.Vaccines = this.getAll.GetVaccines();
            model.BookingDate = DateTime.UtcNow;

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BookApointment(BookingModel bookingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Content("There are validational errors. Please go back and fill the form with the rquired information.");
            }

            // await this.bookingService.CreateBookingAsync(bookingModel);
            return this.RedirectToAction("SuccesfullBooking");
        }

        [HttpGet]
        public JsonResult GetAllDistrictsAjax()
        {
            return this.Json(this.getAll.GetDistricts());
        }

        [HttpGet]
        public JsonResult GetTownsByDistrictAjax(int districtId)
        {
            return this.Json(this.getAll.GetTownsByDistrict(districtId));
        }

        [HttpGet]
        public JsonResult GetHospitalsByTownAjax(int townId)
        {
            return this.Json(this.getAll.GetHospitalsByTown(townId));
        }

        [HttpGet]
        public JsonResult GetAllDiseasesAjax()
        {
            return this.Json(this.getAll.GetDiseases());
        }

        [HttpGet]
        public JsonResult GetVaccinesByDiseaseAjax(int diseaseId)
        {
            return this.Json(this.getAll.GetVaccinesByDisease(diseaseId));
        }

        public IActionResult SuccesfullBooking()
        {
            return this.View();
        }
    }
}
