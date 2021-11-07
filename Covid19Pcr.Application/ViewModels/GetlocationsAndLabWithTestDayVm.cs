using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.ViewModels
{
    public class GetlocationsAndLabWithTestDayVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<LabVm> Labs { get; set; }
    }
}
