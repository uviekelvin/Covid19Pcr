using Covid19Pcr.Domain.Exceptions;
using System;

namespace Covid19Pcr.Domain.Models
{
    public class TestDays : BaseEntity
    {
        public DateTime Date { get; set; }
        public int SpaceAvailable { get; set; }
        public long LabId { get; set; }
        public Labs Lab { get; set; }
        public void BookSpace()
        {
            if (SpaceAvailable == 0)
                throw new DomainException("No available space to book");
            this.SpaceAvailable--;
        }

        public void FreeSpace()
        {
            this.SpaceAvailable++;
        }
    }
}
