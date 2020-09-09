using MediatR;
using Shopping.Domain.Commands.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Domain.Notifications
{
    public class ApplicationInsightsEvents : INotificationHandler<Notification>
    {
        public async Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Recependo notificação 1");
            });
        }
    }
}
