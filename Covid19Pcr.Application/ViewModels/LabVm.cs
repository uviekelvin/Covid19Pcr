using System.Collections.Generic;

namespace Covid19Pcr.Application.ViewModels
{
    public class LabVm
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<TestDayVm> TestDays { get; set; }
    }
}
