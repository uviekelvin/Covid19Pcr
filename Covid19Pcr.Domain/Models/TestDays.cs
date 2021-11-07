using Covid19Pcr.Domain.Exceptions;
using System;

namespace Covid19Pcr.Domain.Models
{
    public class TestDays : BaseEntity
    {
        public DateTime Date { get; set; }
        public int AvailableSpace { get; set; }
        public long LabId { get; set; }
        public Labs Lab { get; set; }

        public TestDays() { }

        public TestDays(DateTime date, int availableSpace)
        {
            if (date.Date < DateTime.Now.Date)
                throw new DomainException("Cannot allocate test in the past");

            if (availableSpace == 0)
                throw new DomainException("Please select a valid available space");
        }
        public void BookSpace()
        {
            if (AvailableSpace == 0)
                throw new DomainException("No available space to book");
            this.AvailableSpace--;
        }

        public void FreeSpace()
        {
            this.AvailableSpace++;
        }
    }
}
