using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace VemDeZap.Domain.Commands.Usuario.AdicionarUsuario.Notifications
{
    public class AvisarAdministrados : INotificationHandler<AdicionarUsuarioNotification>
    {
        public async Task Handle(AdicionarUsuarioNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("notifica administrador");
        }
    }
}
