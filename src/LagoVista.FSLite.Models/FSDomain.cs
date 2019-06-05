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
