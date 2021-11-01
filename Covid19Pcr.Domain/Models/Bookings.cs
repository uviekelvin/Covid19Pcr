using Covid19Pcr.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Domain.Models
{
    public class Bookings : BaseEntity
    {
        public string Patient { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public BookingStatus Status { get; set; }
        public string BookingCode { get; set; }
        public long TestTypeId { get; set; }
        public TestTypes TestType { get; set; }
        public long LabId { get; set; }
        public Labs Lab { get; set; }

    }
}
