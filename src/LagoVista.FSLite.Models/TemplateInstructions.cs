using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.MediaServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.Models
{
    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.TemplateInstruction_Title, FSResources.Names.TemplateInstruction_Help,
       FSResources.Names.TemplateInstruction_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]
    public class ServiceTicketTemplateInstruction
    {
        public ServiceTicketTemplateInstruction()
        {
            Resources = new List<MediaResourceSummary>();
            Tools = new List<EquipmentSummary>();
        }

        public string Id { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateInstruction_StepId, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsUserEditable: true)]
        public string StepId { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Name { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateInstruction_Instruction, FieldType:FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Instructions { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateInstruction_Hints, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public string Hints { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateInstruction_Notes, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public string Notes { get; set; }


        [FormField(LabelResource: FSResources.Names.Common_Resources, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public List<EquipmentSummary> Tools { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Resources, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public List<MediaResourceSummary> Resources { get; set; }
    }
}
