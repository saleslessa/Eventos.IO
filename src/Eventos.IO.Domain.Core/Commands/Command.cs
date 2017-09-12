using Eventos.IO.Domain.Core.Events;
using System;

namespace Eventos.IO.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
