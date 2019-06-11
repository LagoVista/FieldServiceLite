using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Collections;
using System.Collections.Generic;

namespace LagoVista.FSLite.Models
{
    public enum Urgency
    {
        [EnumLabel(DeviceType.DeviceResourceTypes_Other, FSResources.Names.ServiceTicketTemplate_Urgency_CriticalSafety, typeof(FSResources))]
        CriticalSafety,
        [EnumLabel(DeviceType.DeviceResourceTypes_Other, FSResources.Names.ServiceTicketTemplate_Urgency_Important, typeof(FSResources))]
        Important,
        [EnumLabel(DeviceType.DeviceResourceTypes_Other, FSResources.Names.ServiceTicketTemplate_Urgency_Normal, typeof(FSResources))]
        Normal,
        [EnumLabel(DeviceType.DeviceResourceTypes_Other, FSResources.Names.ServiceTicketTemplate_Urgency_Low, typeof(FSResources))]
        LowPriority
    }

    public enum SkillLevels
    {
        [EnumLabel(DeviceType.DeviceResourceTypes_Other, FSResources.Names.ServiceTicketTemplate_Skill_High, typeof(FSResources))]
        High,
        [EnumLabel(DeviceType.DeviceResourceTypes_Other, FSResources.Names.ServiceTicketTemplate_Skill_Medium, typeof(FSResources))]
        Medium,
        [EnumLabel(DeviceType.DeviceResourceTypes_Other, FSResources.Names.ServiceTicketTemplate_Skill_Low, typeof(FSResources))]
        Low,
    }

    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.ServiceTicketTemplate_Title, FSResources.Names.ServiceTicketTemplate_Help,
        FSResources.Names.ServiceTicketTemplate_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]
    public class ServiceTicketTemplate : FSModelBase
    {

        public const string ServiceTicketTemplate_Urgency_CriticalSafety = "criticalsafety";
        public const string ServiceTicketTemplate_Urgency_Important = "important";
        public const string ServiceTicketTemplate_Urgency_Normal = "normal";
        public const string ServiceTicketTemplate_Urgency_Low = "low";


        public const string ServiceTicketTemplate_Skill_High = "high";
        public const string ServiceTicketTemplate_Skill_Medium = "medium";
        public const string ServiceTicketTemplate_Skill_Low = "low";

        public ServiceTicketTemplate()
        {
            TroubleshootingSteps = new List<TroubleshootingStep>();
            RequiredParts = new List<BOMItem>();
            AssociatedEquipment = new List<EntityHeader<Equipment>>();
            Instructions = new List<ServiceTicketTemplateInstruction>();
            Resources = new List<MediaResource>();
        }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Instructions, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public IEnumerable<ServiceTicketTemplateInstruction> Instructions { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_HoursEstimate, FieldType: FieldTypes.Decimal, ResourceType: typeof(FSResources))]
        public double HoursEstimate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_CostEstimate, FieldType: FieldTypes.Decimal, ResourceType: typeof(FSResources))]
        public double CostEstimate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_StatusType, WaterMark: FSResources.Names.ServiceTicketTemplate_StatusType_Select, HelpResource:FSResources.Names.ServiceTicketTemplate_StatusType_Help,  FieldType: FieldTypes.EntityHeaderPicker, IsRequired: true, ResourceType: typeof(FSResources))]
        public EntityHeader<StateSet> StatusType { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Urgency, WaterMark: FSResources.Names.ServiceTicketTemplate_Urgency_Select, IsRequired: true, EnumType: typeof(Urgency), FieldType: FieldTypes.Picker, ResourceType: typeof(FSResources))]
        public EntityHeader<Urgency> Urgency {get; set;}

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Skill, WaterMark: FSResources.Names.ServiceTicketTemplate_Skill_Select, IsRequired: true, EnumType: typeof(SkillLevels), FieldType: FieldTypes.Picker, ResourceType: typeof(FSResources))]
        public EntityHeader<SkillLevels> SkillLevel { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_TroubleshootingSteps, FieldType: FieldTypes.ChildList, IsRequired: true, ResourceType: typeof(FSResources))]
        public IEnumerable<TroubleshootingStep> TroubleshootingSteps { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_RequiredParts, FieldType: FieldTypes.ChildList,  ResourceType: typeof(FSResources))]
        public IEnumerable<BOMItem> RequiredParts { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Resources, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public IEnumerable<MediaResource> Resources { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_AssociatedEquipment, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public IEnumerable<EntityHeader<Equipment>> AssociatedEquipment { get; set; }
        public ServiceTicketTemplateSummary CreateSummary()
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
