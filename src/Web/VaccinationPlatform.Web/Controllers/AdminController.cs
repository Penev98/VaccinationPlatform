namespace VaccinationPlatform.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services.Data.Booking;
    using VaccinationPlatform.Web.ViewModels.Administration;

    public class AdminController : BaseController
    {
        private readonly IBookingService bookingService;

        public AdminController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AllBookings()
        {
            IEnumerable<AllBookingsInfoViewModel> models = this.bookingService.GetAllBookings<AllBookingsInfoViewModel>();

            return this.View(models);
            
        }
    }
}
