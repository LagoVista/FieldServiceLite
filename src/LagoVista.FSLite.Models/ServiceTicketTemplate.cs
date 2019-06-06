using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;

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

        public ServiceTicketTemplateSummary GCreateSummary()
        {
            return new ServiceTicketTemplateSummary()
            {
                Description = Description,
                Id = Id,
                IsPublic = false,
                Key = Key,
                Name = Name
            };
        }
    }

    public class ServiceTicketTemplateSummary : SummaryData
    {

    }

}
