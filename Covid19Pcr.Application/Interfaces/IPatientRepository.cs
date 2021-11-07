using Covid19Pcr.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patients> GetPatientWithBooking(string email,string bookingCode);
        Task<IEnumerable<Locations>> GetLocationWithLabsAndTestDays();
    }
}
