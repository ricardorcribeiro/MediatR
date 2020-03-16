using prmToolkit.NotificationPattern;
using System.Collections.Generic;
using VemDeZap.Domain.Entities.Base;

namespace VemDeZap.Domain.Commands
{
    public class Response
    {
        public Response(INotifiable notifiable)
        {
            this.Success = notifiable.IsValid();
            this.Notifications = notifiable.Notifications;
        }

        public Response(INotifiable notifiable, EntityBase data)
        {
            this.Success = notifiable.IsValid();
            this.Notifications = notifiable.Notifications;
            this.Data = data;
        }

        public IEnumerable<Notification> Notifications { get; }
        public bool Success { get; set; }
        public EntityBase Data { get; set; }
    }
}
