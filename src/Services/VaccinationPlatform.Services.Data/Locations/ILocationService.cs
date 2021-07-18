using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VaccinationPlatform.Services.Data.Locations
{
     public interface ILocationService
    {
        public IEnumerable<T> GetModels<T>();
    }
}
