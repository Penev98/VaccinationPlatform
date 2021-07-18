namespace VaccinationPlatform.Data.Models
{
    using VaccinationPlatform.Data.Common.Models;

    public class Image : BaseDeletableModel<int>
    {
        public string Url { get; set; }

        public int HospitalId { get; set; }

        public Hospital Hospital { get; set; }
    }
}
