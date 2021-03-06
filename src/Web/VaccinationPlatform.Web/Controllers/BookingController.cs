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
    using VaccinationPlatform.Services.Data.Booking;
    using VaccinationPlatform.Web.ViewModels;
    using VaccinationPlatform.Web.ViewModels.InputModels;

    public class BookingController : BaseController
    {
        private readonly IBookingService bookingService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAvailableBooking checkBooking;

        public BookingController(IBookingService bookingService, UserManager<ApplicationUser> userManager, IAvailableBooking checkBooking)
        {
            this.bookingService = bookingService;
            this.userManager = userManager;
            this.checkBooking = checkBooking;
        }

        [Authorize]
        public IActionResult BookApointment(BookingModel model, DateTime bookDate)
        {
            if (bookDate.Year < 2020)
            {
                model.BookingDate = DateTime.UtcNow.Date;
            }

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
        public async Task<IActionResult> CancelBooking(string id, int isAdmin)
        {
            await this.bookingService.CancelBookingAsync(id);

            if (this.User.IsInRole("Administrator") && isAdmin == 1)
            {
                return this.Redirect("/Admin/AllBookings");
            }

            return this.Redirect("/Booking/GetUserBookings");
        }

        [Authorize]
        public async Task<IActionResult> RemoveBooking(string id, int isAdmin)
        {
            await this.bookingService.RemoveBookingAsync(id);

            if (this.User.IsInRole("Administrator") && isAdmin == 1)
            {
                return this.Redirect("/Admin/AllBookings");
            }

            return this.Redirect("/Booking/GetUserBookings");
        }

        [Authorize]
        public IActionResult EditBooking(string id)
        {
            // string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bookingModel = this.bookingService.GetUserBooking<BookingModel>(id/*, userId*/);

            return this.View(bookingModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditBooking(string id, BookingModel model, int isAdmin)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.bookingService.EditBookingAsync(model, id);

            if (this.User.IsInRole("Administrator") && isAdmin == 1)
            {
                return this.Redirect("/Admin/AllBookings");
            }

            return this.Redirect("/Booking/GetUserBookings");
        }

        [HttpGet]
        public int CheckDate(int hospitalId, DateTime bookingDate)
        {
            bool freeDateCheck = this.checkBooking.IsBookingAvailable(hospitalId, bookingDate);
            bool pastDateCheck = this.checkBooking.IsBookingInThePast(bookingDate);

            // Booking should be free AND not in the past
            if (freeDateCheck == true && pastDateCheck == false)
            {
                return 0;
            }

            return 1;
        }
    }
}
