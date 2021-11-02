using Covid19Pcr.Common.Helpers;
using Covid19Pcr.Domain.Enums;
using Covid19Pcr.Domain.Events;
using Covid19Pcr.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Domain.Models
{
    public class Bookings : BaseEntity
    {

        public BookingStatus Status { get; set; }
        public string BookingCode { get; private set; }
        public long PatientId { get; set; }
        public Patients Patient { get; set; }
        public long TestTypeId { get; set; }
        public long TestDayId { get; set; }
        public TestTypes TestType { get; set; }
        public TestDays TestDay { get; set; }

        public TestResults TestResult { get; set; }

        public Bookings()
        {
            this.BookingCode = Utility.GenerateRandomString(10, "1234567890");
        }

        public Bookings(TestDays testDay, long testTypeId)
        {
            if (this.TestDay.Date < DateTime.Now.Date)
                throw new DomainException("Cannot Schduled booking in the past");
            this.TestDayId = testDay.Id;
            this.TestDay = testDay;
            this.TestTypeId = testTypeId;
            this.BookingCode = Utility.GenerateRandomString(10, "1234567890");
            this.TestDay.BookSpace();
            this.AddDomainEvent(new BookingCreatedDomainEvent
            {
                Bookings = this
            });
        }
        public void CancelBooking()
        {
            if (this.Status == BookingStatus.Completed)
                throw new DomainException("This booking cannot be cancelled");
            if (this.Status == BookingStatus.Cancelled)
                throw new DomainException("Booking already cancelled");
            this.TestDay.FreeSpace();
        }

    }


}
