namespace VaccinationPlatform.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using VaccinationPlatform.Services.Data;
    using VaccinationPlatform.Web.ViewModels.InputModels;

    public class BookingController : BaseController
    {
        private readonly IGetAllService getAll;

        public BookingController(IGetAllService getAll)
        {
            this.getAll = getAll;
        }
        public IActionResult BookApointment()
        {
            BookingModel model = new BookingModel();
            model.Districts = this.getAll.GetDistricts();
            return this.View();
        }

        //[System.Web.Mvc.HttpPost]
        //public async Task<IActionResult> BookApointment(BookingModel bookingModel)
        //{
        //    return this.Redirect("/");
        //}
    }
}
