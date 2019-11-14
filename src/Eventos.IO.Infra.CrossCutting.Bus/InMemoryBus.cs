using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Notifications;
using System;

namespace Eventos.IO.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IBus
    {
        // Propriedade estática Func <Delegate> que retorna um IServiceProvider e não recebe nenhum parâmetro
        // Método de acesso ao Container de injeção de dependência
        public static Func<IServiceProvider> ContainerAccessor { get; set; }

        // Propriedade estática do tipo IServiceProvider que obtem a referência da Func ContainerAccessor
        private static IServiceProvider Container => ContainerAccessor();

        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            // variável obj recebe o tipo do serviço (se o MessageType for DormainNotification, retorno o tipo
            // da interface IDomainNotification, se não retorno um IHandler)
            var obj = Container.GetService(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>));

            // Cast da variável obj para a chamada do método Handle, passando como parâmetro a mensagem (message)
            // Através desse cast é possível realizar a chamada do método Handle da interface IHandle para cada tipo de objeto
            ((IHandler<T>)obj).Handle(message);

        }
    }
}
