using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.ViewModels
{
    public class BookingCapacityVm
    {
        public string Location { get; set; }
        public string Lab { get; set; }
        public int AvailableSpace { get; set; }

        public DateTime Date { get; set; }
    }
}
