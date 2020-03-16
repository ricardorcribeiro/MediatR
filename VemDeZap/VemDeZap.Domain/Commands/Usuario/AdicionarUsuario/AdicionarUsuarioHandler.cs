using MediatR;
using prmToolkit.NotificationPattern;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Interfaces.Repositories;

namespace VemDeZap.Domain.Commands.Usuario.AdicionarUsuario
{
    public class AdicionarUsuarioHandler : Notifiable, IRequestHandler<AdicionarUsuarioRequest, Response>
    {
        private readonly IrepositoryUsuario _repositoryUsuario;
        private readonly IMediator _mediator;

        public AdicionarUsuarioHandler(IrepositoryUsuario repositoryUsuario, IMediator mediator)
        {
            _repositoryUsuario = repositoryUsuario;
            _mediator = mediator;
        }

        public async Task<Response> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
        {
            //validar se o request veio preenchido
            if (request == null)
            {
                AddNotification("Request", "informe os dados do usuario.");
                return new Response(this);
            }

            //verificar se o usuario ja existe
            if (_repositoryUsuario.Existe(x=> x.Email == request.Email))
            {
                AddNotification("Email", "email ja existe.");
                return new Response(this);
            }

            Entities.Usuario usuario = new Entities.Usuario(request.PrimeiroNome, request.UltimoNome, request.Email, request.Senha);


            AddNotifications(usuario);

            if (IsInvalid())
                return new Response(this);

            _repositoryUsuario.Adicionar(usuario);

            var adicionarUsuarioNotification = new AdicionarUsuarioNotification(usuario);


            //disparo um evendo para quem esteja ouvindo, faça uma ação / nao e obrigatorio ter algum auvindo podendo ser implementado posteriormente 
            await _mediator.Publish(adicionarUsuarioNotification);

            return await Task.FromResult(new Response(this, usuario));

        }
    }
}
