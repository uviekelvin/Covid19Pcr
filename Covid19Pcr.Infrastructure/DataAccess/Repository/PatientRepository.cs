using Covid19Pcr.Application.Interfaces;
using Covid19Pcr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Infrastructure.DataAccess.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly Covid19PcrContext _context;

        public PatientRepository(Covid19PcrContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Locations>> GetLocationWithLabsAndTestDays()
        {

            return await this._context.Locations.Include(x => x.Labs)
                .ThenInclude(x => x.TestDays).ToListAsync();
        }

        public async Task<Patients> GetPatientWithBooking(string email, string bookingCode)
        {
            //return await this._context.Patients.
            //      Include(x => x.Bookings.Where(a => a.BookingCode == bookingCode))
            //    .ThenInclude(x => x.TestDay)
            //    .ThenInclude(x => x.Lab)
            //    .ThenInclude(x => x.Location)
            //    .Include(x => x.Bookings)
            //    .FirstOrDefaultAsync(a => a.Email == email);

            var booking = await this._context.Bookings
                .Include(x => x.TestType)
                .Include(p => p.Patient)
               .Include(x => x.TestDay)
               .ThenInclude(x => x.Lab)
               .ThenInclude(x => x.Location)
               .FirstOrDefaultAsync(a => a.Patient.Email == email && a.BookingCode == bookingCode);
            return booking?.Patient;
        }
    }
}
