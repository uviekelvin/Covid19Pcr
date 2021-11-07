using Covid19Pcr.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.ViewModels
{
    public class BookingVm
    {

        public string BookingCode { get; set; }
        public DateTime ScheduledDate { get; set; }

        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TestType { get; set; }

        public string Lab { get; set; }
        public string Location { get; set; }

        public TestResults TestResult { get; set; }
    }
}
