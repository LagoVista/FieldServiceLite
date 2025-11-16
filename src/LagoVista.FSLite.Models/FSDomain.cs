// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 2934a0bec2fd175194330380caf568a55a37c67bba5007636bbf5d3f19ca439e
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.Core.Models.UIMetaData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.Models
{
    [DomainDescriptor]

    public class FSDomain
    {
        public const string FieldServiceLite = "FieldSerivceLite";


        [DomainDescription(FieldServiceLite)]
        public static DomainDescription StateMachineDomainDescription
        {
            get
            {
                return new DomainDescription()
                {
                    Description = "Very Basic Field Service Ticketing System",
                    DomainType = DomainDescription.DomainTypes.BusinessObject,
                    Name = "Field Service Lite",
                    CurrentVersion = new LagoVista.Core.Models.VersionInfo()
                    {
                        Major = 0,
                        Minor = 8,
                        Build = 001,
                        DateStamp = new DateTime(2016, 12, 20),
                        Revision = 1,
                        ReleaseNotes = "Initial unstable preview"
                    }
                };
            }
        }
    }
}
