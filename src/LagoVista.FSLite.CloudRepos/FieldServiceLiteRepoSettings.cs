using LagoVista.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.CloudRepos
{
    public class FieldServiceLiteRepoSettings : IFieldServiceLiteRepoSettings
    {
        public IConnectionSettings FieldServiceLiteDocDbStorage { get; }
        public IConnectionSettings FieldServiceLiteTableStorage { get; }

        public FieldServiceLiteRepoSettings(IConfiguration configuration)
        {
            FieldServiceLiteDocDbStorage = configuration.CreateDefaultDBStorageSettings();
            FieldServiceLiteTableStorage = configuration.CreateDefaultTableStorageSettings();
        }
    }
}
