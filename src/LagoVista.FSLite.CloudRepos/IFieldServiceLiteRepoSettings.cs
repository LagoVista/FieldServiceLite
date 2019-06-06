using LagoVista.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.CloudRepos
{
    public interface IFieldServiceLiteRepoSettings
    {
        IConnectionSettings FieldServiceLiteDocDbStorage { get; set; }

        IConnectionSettings FieldServiceLiteTableStorage { get; set; }

        bool ShouldConsolidateCollections { get; }
    }
}
