namespace VaccinationPlatform.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    // using VaccinationPlatform.Services.Data;
    using VaccinationPlatform.Web.ViewModels.Administration.Dashboard;

    public class DashboardController : AdministrationController
    {
       // private readonly ISettingsService settingsService;
        public DashboardController()
        {
           // this.settingsService = settingsService;
        }

        public IActionResult Index()
        {
           // var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View();
        }
    }
}
