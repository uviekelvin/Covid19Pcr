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
    public class BookingCancelledDomainEventHandler : INotificationHandler<BookingCancelledDomainEvent>
    {
        public async Task Handle(BookingCancelledDomainEvent notification, CancellationToken cancellationToken)
        {
            ///Send an email to the patient about their cancelled booking

            await Task.CompletedTask;
        }
    }
}
