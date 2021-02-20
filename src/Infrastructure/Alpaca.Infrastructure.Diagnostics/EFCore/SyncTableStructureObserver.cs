using Alpaca.Infrastructure.Logging;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Diagnostics.EFCore
{
    public class SyncTableStructureObserver : IObserver<KeyValuePair<string, object>>
    {
        public void OnCompleted()
        => throw new NotImplementedException();

        public void OnError(Exception error)
            => throw new NotImplementedException();

        public void OnNext(KeyValuePair<string, object> value)
        {
            System.Diagnostics.Trace.WriteLine($"Observer:{value.Key}");
            if (value.Key == RelationalEventId.MigrationApplying.Name)
            {
                var migrationEventData = (MigrationEventData)value.Value;
                string message = null;

                foreach (var upOperation in migrationEventData.Migration.UpOperations)
                {
                    if (upOperation is Microsoft.EntityFrameworkCore.Migrations.Operations.CreateTableOperation createTableOperation)
                    {
                        message = $"CREATE TABLE {createTableOperation.Name}";
                    }
                    else if (upOperation is Microsoft.EntityFrameworkCore.Migrations.Operations.CreateIndexOperation createInexOperation)
                    {
                        message = $"CREATE INDEX {createInexOperation.Name} ON {createInexOperation.Table}";
                    }
                    else if (upOperation is Microsoft.EntityFrameworkCore.Migrations.Operations.InsertDataOperation insertDataOperation)
                    {
                        message = $"INSERT INTO {insertDataOperation.Table}";
                    }

                    if (!string.IsNullOrWhiteSpace(message))
                        Logger.Debug($"EF Core Migration: {message}");

                    message = null;
                }
            }
        }
    }
}
