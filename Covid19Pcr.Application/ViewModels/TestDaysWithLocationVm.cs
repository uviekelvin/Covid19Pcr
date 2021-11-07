using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.ViewModels
{
    public class TestDaysWithLocationVm
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int AvailableSpace { get; set; }
        public string Location { get; set; }
        public string Lab { get; set; }
    }
}
