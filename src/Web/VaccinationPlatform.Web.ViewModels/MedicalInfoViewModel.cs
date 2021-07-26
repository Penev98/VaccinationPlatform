namespace VaccinationPlatform.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using VaccinationPlatform.Data.Models;
    using VaccinationPlatform.Services.Mapping;

    public class MedicalInfoViewModel : IMapFrom<Disease>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Information { get; set; }

        public virtual ICollection<VaccineViewModel> Vacciness { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Disease, MedicalInfoViewModel>()
                .ForMember(x => x.Vacciness, opt =>
                    opt.MapFrom(x => x.Vaccines.Select(x => new VaccineViewModel { Name = x.Name, Information = x.Information })));
        }
    }
}
