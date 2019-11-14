using Eventos.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
