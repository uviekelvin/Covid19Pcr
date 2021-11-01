using Covid19Pcr.Domain.Enums;

namespace Covid19Pcr.Domain.Models
{
    public class TestResults
    {
        public LabResultTypes ResultType { get; set; }
        public string Remarks { get; set; }
        public long BookingId { get; set; }
        public Bookings Booking { get;set;  }
    }
}
