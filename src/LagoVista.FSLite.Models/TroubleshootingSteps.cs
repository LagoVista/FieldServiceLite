using LagoVista.Core.Attributes;
using LagoVista.FSLite.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.MediaServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.Models
{
    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.TroubleShootingStep_Title,
                FSResources.Names.TroubleShootingStep_Help, FSResources.Names.TroubleShootingStep_Description,
              EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(FSDomain))]
    public class TroubleshootingStep
    {
        public TroubleshootingStep()
        {
            Resources = new List<MediaResourceSummary>();
            Tools = new List<EquipmentSummary>();
        }

        public string Id { get; set; }

        [FormField(LabelResource: FSResources.Names.TroubleshootingStep_StepId, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string StepId { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Name { get; set; }

        [FormField(LabelResource: FSResources.Names.TroubleshootingStep_Instructions, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Instructions { get; set; }

        [FormField(LabelResource: FSResources.Names.TroubleshootingSteps_ExpectedOutcome, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string ExpectedOutcome { get; set; }

        [FormField(LabelResource: FSResources.Names.TroubleshootingStep_Problem, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Problem { get; set; }

        [FormField(LabelResource: FSResources.Names.TroubleshootingStep_Notes, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Notes { get; set; }


        [FormField(LabelResource: FSResources.Names.Common_Resources, FieldType: FieldTypes.ChildItem, ResourceType: typeof(FSResources))]
        public List<MediaResourceSummary> Resources { get; set; }

        [FormField(LabelResource: FSResources.Names.TroubleshootingStep_Equipment, FieldType: FieldTypes.ChildItem, ResourceType: typeof(FSResources))]
        public List<EquipmentSummary> Tools { get; set; }
    }
}
