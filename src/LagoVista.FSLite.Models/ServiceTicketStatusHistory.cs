using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;

namespace LagoVista.FSLite.Models
{
    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.ServiceTicketStatusHistory_Title, FSResources.Names.ServiceTicketStatusHistory_Help,
        FSResources.Names.ServiceTicketStatusHistory_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]
    public class ServiceTicketStatusHistory
    {
        [FormField(LabelResource: FSResources.Names.ServiceTicketStatusHistory_DateStamp, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string DateStamp { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketStatusHistory_AddedBy, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public EntityHeader AddedBy { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketStatusHistory_Status, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Status { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketStatusHistory_Notes, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Note { get; set; }
    }
}
