using Covid19Pcr.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.ViewModels
{
    public class TestResultVm
    {
        public string Lab { get; set; }
        public string Location { get; set; }
        public string Patient { get; set; }
        public DateTime ScheduleDate { get; set; }
        public LabResultTypes ResultType { get; set; }
        public string Remarks { get; set; }
    }
}
