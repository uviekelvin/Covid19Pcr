using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Domain.Models
{
    public class Labs : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public long LocationId { get; set; }
        public Locations Location { get; set; }
    }
}
