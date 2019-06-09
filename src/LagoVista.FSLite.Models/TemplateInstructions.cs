using LagoVista.Core.Attributes;
using LagoVista.FSLite.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Models;
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
            Resources = new List<MediaResource>();
        }

        public string Id { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateInstruction_StepId, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsUserEditable: true)]
        public string StepId { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Name { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateInstruction_Instruction, FieldType:FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Instruction { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateInstruction_Hints, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public string Hints { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Resources, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public List<MediaResource> Resources { get; set; }
    }
}
