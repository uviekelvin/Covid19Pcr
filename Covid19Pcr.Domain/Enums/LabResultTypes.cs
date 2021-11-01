using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Domain.Enums
{
    public enum LabResultTypes
    {
        Positive = 1,
        Negative = 2
    }

    public enum BookingStatus
    {
        Booked = 1,
        Completed = 2,
        Cancelled = 3
    }
}
