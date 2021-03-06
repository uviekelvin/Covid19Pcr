using Covid19Pcr.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Domain.Events
{
    public class BookingCreatedDomainEvent : INotification
    {
        public Bookings Bookings { get; set; }
    }
}
