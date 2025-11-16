// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: eb9081ec18836b087a65b4b2bc02291c309185800a1bffd0acc2d305eac7a730
// IndexVersion: 2
// --- END CODE INDEX META ---
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
