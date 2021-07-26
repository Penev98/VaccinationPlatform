namespace VaccinationPlatform.Services.Data.MedicalInfo
{
    using System.Collections.Generic;

    public interface IMedicalInfoService
    {
        public IEnumerable<string> GetAllDiseaseNames();

        public IEnumerable<T> GetDiseases<T>();
    }
}
