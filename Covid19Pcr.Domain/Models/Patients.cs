

using Covid19Pcr.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Covid19Pcr.Domain.Models
{
    public class Patients : BaseEntity
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName => $"{FirstName},{SurName}";
        private List<Bookings> _bookings = new List<Bookings>();


        public IReadOnlyCollection<Bookings> Bookings => _bookings;
        public Patients() { }

        public Patients(string firstName, string surName, string email, string phoneNumber)
        {
            this.FirstName = firstName;
            this.Email = email;
            this.SurName = surName;
            this.PhoneNumber = phoneNumber;
        }


        public void CreateBooking(TestDays testDay, long testTypeId)
        {

            if (this._bookings.Any(a => a.TestDayId == testDay.Id && a.Status == Enums.BookingStatus.Booked))
                throw new DomainException("You already scheduled a test for this day");
            var booking = new Models.Bookings(testDay, testTypeId);
            booking.Patient = this;
            this._bookings.Add(booking);
        }
    }
}
