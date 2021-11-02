using Covid19Pcr.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.Events
{
    
    public class BookingCreatedDomainEventHandler : INotificationHandler<BookingCreatedDomainEvent>
    {
       
       
        public async Task Handle(BookingCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            ///Send an email notification to the patient about their booking reservation
            await Task.CompletedTask;

        }
    }
}
