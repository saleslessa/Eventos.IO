using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Eventos.Events;
using System;

namespace Eventos.IO.Domain.Eventos.EventHandlers
{
    public class EventosEventHandler :
        IHandler<EventoRegistradoEvent>,
        IHandler<EventoAtualizadoEvent>,
        IHandler<EventoExcluidoEvent>
    {
        
        public void Handle(EventoRegistradoEvent message)
        {
            //Enviar email, gerar log, etc...
        }

        public void Handle(EventoAtualizadoEvent message)
        {
            //Enviar email, gerar log, etc...
        }

        public void Handle(EventoExcluidoEvent message)
        {
            //Enviar email, gerar log, etc...
        }
    }
}

