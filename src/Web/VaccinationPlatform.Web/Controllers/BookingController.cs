namespace VaccinationPlatform.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
   
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services;
    using VaccinationPlatform.Services.Data;
    using VaccinationPlatform.Services.Data.Booking;
    using VaccinationPlatform.Web.ViewModels;
    using VaccinationPlatform.Web.ViewModels.InputModels;
   
    public class BookingController : BaseController
    {
        private readonly IGetAllService getAll;
        private readonly IBookingService bookingService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAvailableBooking checkBooking;

        public BookingController(IGetAllService getAll, IBookingService bookingService, UserManager<ApplicationUser> userManager, IAvailableBooking checkBooking)
        {
            this.getAll = getAll;
            this.bookingService = bookingService;
            this.userManager = userManager;
            this.checkBooking = checkBooking;
        }

        [Authorize]
        public IActionResult BookApointment()
        {
            BookingModel model = new BookingModel();
            model.BookingDate = DateTime.UtcNow.Date;
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> BookApointment(BookingModel bookingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bookingModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            string userId = user.Id;

            await this.bookingService.CreateBookingAsync(bookingModel, userId);
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

        [Authorize]
        public IActionResult GetUserBookings()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<ShowBookingViewModel> userBookings = this.bookingService.GetBookingsByUserId<ShowBookingViewModel>(userId);
            return this.View(userBookings);
        }

        [Authorize]
        public async Task<IActionResult> CancelBooking(string id)
        {
            await this.bookingService.CancelBookingAsync(id);

            return this.Redirect("/Booking/GetUserBookings");
        }

        [Authorize]
        public async Task<IActionResult> RemoveBooking(string id)
        {
            await this.bookingService.RemoveBookingAsync(id);

            return this.Redirect("/Booking/GetUserBookings");
        }

        [Authorize]
        public IActionResult EditBooking(string id)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var bookingModel = this.bookingService.GetUserBooking<BookingModel>(id, userId);

            return this.View(bookingModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditBooking(string id, BookingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.bookingService.EditBookingAsync(model, id);
            return this.Redirect("/Booking/GetUserBookings");
        }

        [HttpGet]
        public int CheckDate(int hospitalId, DateTime bookingDate)
        {
            bool result = this.checkBooking.IsBookingAvailable(hospitalId, bookingDate);

            if (result)
            {
                return 0;
            }

            return 1;
        }
    }
}
