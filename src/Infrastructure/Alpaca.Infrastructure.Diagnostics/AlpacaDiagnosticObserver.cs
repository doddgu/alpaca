using Alpaca.Infrastructure.Diagnostics.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Alpaca.Infrastructure.Diagnostics
{
    public class AlpacaDiagnosticObserver : IObserver<DiagnosticListener>
    {
        public void OnCompleted()
            => throw new NotImplementedException();

        public void OnError(Exception error)
            => throw new NotImplementedException();

        public void OnNext(DiagnosticListener value)
        {
            if (value.Name == DbLoggerCategory.Name)
            {
                value.Subscribe(new SyncTableStructureObserver());
            }
        }
    }
}
