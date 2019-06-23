using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Models.Resources;

namespace LagoVista.FSLite.Models
{
    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.ServiceTicketNote_Title, FSResources.Names.ServiceTicketStatusHistory_Help,
        FSResources.Names.ServiceTicketStatusHistory_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]
    public class ServiceTicketNote : IValidateable
    {
        [FormField(LabelResource: FSResources.Names.ServiceTicketNote_AddedBy, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]

        public EntityHeader AddedBy { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketNote_DateStamp, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string DateStamp { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketNote_Note, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Note { get; set; }
    }
}
