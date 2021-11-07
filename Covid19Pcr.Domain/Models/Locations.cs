using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Domain.Models
{
    public class Locations : BaseEntity
    {
        public string Name { get; set; }

        private List<Labs> _labs= new List<Labs>();

        public IReadOnlyCollection<Labs> Labs => _labs;
    }
}
