using LagoVista.Core.Attributes;
using LagoVista.FSLite.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.Models
{
    public enum Urgency
    {
        LifeSafety,
        Important,
        Normal,
        LowPriority
    }

    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.ServiceTicketTemplate_Title, FSResources.Names.ServiceTicketTemplate_Help, 
        FSResources.Names.ServiceTicketTemplate_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]
    public class ServiceTicketTemplate : FSModelBase
    {
       public string Instructions { get; set; }
    }
}
