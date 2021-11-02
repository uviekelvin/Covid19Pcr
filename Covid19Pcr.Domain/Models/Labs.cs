
using Covid19Pcr.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Covid19Pcr.Domain.Models
{
    public class Labs : BaseEntity
    {
        public string Name { get; set; }
        public long LocationId { get; set; }
        public Locations Location { get; set; }


        private List<TestDays> _testDays = new List<TestDays>();

        public IReadOnlyCollection<TestDays> TestDays => _testDays;
        public void DeallocateSpace(long testDayId)
        {
            var availableSpace = this.TestDays.FirstOrDefault(x => x.Id == testDayId);
            if (availableSpace != null)
            {
                availableSpace.FreeSpace();
            }
        }

        public void AllocateSpace(long testDayId)
        {
            var availableSpace = this.TestDays.FirstOrDefault(x => x.Id == testDayId);
            if (availableSpace == null)
                throw new DomainException("No Availabe Space found");

            if (availableSpace.SpaceAvailable == 0)
                throw new DomainException("All spaces are fully booked");

            availableSpace.BookSpace();
        }
    }
}
