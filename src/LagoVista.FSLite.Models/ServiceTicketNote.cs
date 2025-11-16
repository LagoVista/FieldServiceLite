// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: db62fa2e6093c3af11a5e52c8dca09656033d9cad48e02e601316556a8e9e4ec
// IndexVersion: 2
// --- END CODE INDEX META ---
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
        public string Id { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketNote_AddedBy, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public EntityHeader AddedBy { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketNote_DateStamp, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string DateStamp { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketNote_Note, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Note { get; set; }
    }
}
