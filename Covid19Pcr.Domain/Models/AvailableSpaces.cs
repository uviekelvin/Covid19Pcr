using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Domain.Models
{
    public class AvailableSpaces
    {
        public long LabId { get; set; }
        public long TestDayId { get; set; }
        public int SpaceAvailable { get; set; }
        public TestDays TestDay { get; set; }
        public Labs Lab { get; set; }


        public AvailableSpaces() { }
        public AvailableSpaces(int space, long labId)
        {
            this.LabId = labId;
            this.SpaceAvailable = space;
        }
        public void ReduceAvailabeSpace()
        {
            this.SpaceAvailable--;
        }

        public void IncreaseAvailableSpace()
        {
            this.SpaceAvailable++;
        }
    }
}
