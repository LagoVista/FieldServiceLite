using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.MediaServices.Models;
using System.Collections;
using System.Collections.Generic;

namespace LagoVista.FSLite.Models
{
    public enum Urgency
    {
        [EnumLabel(ServiceTicketTemplate.ServiceTicketTemplate_Urgency_CriticalSafety, FSResources.Names.ServiceTicketTemplate_Urgency_CriticalSafety, typeof(FSResources))]
        CriticalSafety,
        [EnumLabel(ServiceTicketTemplate.ServiceTicketTemplate_Urgency_Important, FSResources.Names.ServiceTicketTemplate_Urgency_Important, typeof(FSResources))]
        Important,
        [EnumLabel(ServiceTicketTemplate.ServiceTicketTemplate_Urgency_Normal, FSResources.Names.ServiceTicketTemplate_Urgency_Normal, typeof(FSResources))]
        Normal,
        [EnumLabel(ServiceTicketTemplate.ServiceTicketTemplate_Urgency_Low, FSResources.Names.ServiceTicketTemplate_Urgency_Low, typeof(FSResources))]
        LowPriority
    }

    public enum SkillLevels
    {
        [EnumLabel(ServiceTicketTemplate.ServiceTicketTemplate_Skill_High, FSResources.Names.ServiceTicketTemplate_Skill_High, typeof(FSResources))]
        High,
        [EnumLabel(ServiceTicketTemplate.ServiceTicketTemplate_Skill_Medium, FSResources.Names.ServiceTicketTemplate_Skill_Medium, typeof(FSResources))]
        Medium,
        [EnumLabel(ServiceTicketTemplate.ServiceTicketTemplate_Skill_Low, FSResources.Names.ServiceTicketTemplate_Skill_Low, typeof(FSResources))]
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
            TroubleshootingSteps = new List<SectionGrouping<TroubleshootingStep>>();
            ServiceParts = new List<SectionGrouping<BOMItem>>();
            Tools = new List<SectionGrouping<EntityHeader<Equipment>>>();
            Instructions = new List<SectionGrouping<ServiceTicketTemplateInstruction>>();
            PartsKits = new List<EntityHeader<PartsKit>>();
            Resources = new List<MediaResourceSummary>();
        }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_DeviceType, WaterMark: FSResources.Names.ServiceTicketTemplate_DeviceType_Select, HelpResource: FSResources.Names.ServiceTicketTemplate_DeviceType_Help, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources))]
        public EntityHeader DeviceType { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_DeviceConfig, WaterMark: FSResources.Names.ServiceTicketTemplate_DeviceConfig_Select, HelpResource: FSResources.Names.ServiceTicketTemplate_DeviceConfig_Help, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources))]
        public EntityHeader DeviceConfiguration { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Category, WaterMark: FSResources.Names.ServiceTicketTemplate_Categroy_WaterMark, HelpResource: FSResources.Names.ServiceTicketTemplate_Category_Help, FieldType: FieldTypes.EntityHeaderPicker, IsRequired:true, ResourceType: typeof(FSResources))]
        public EntityHeader<TemplateCategory> TemplateCategory { get; set; }


        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Instructions, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<SectionGrouping<ServiceTicketTemplateInstruction>> Instructions { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_HoursEstimate, FieldType: FieldTypes.Decimal, ResourceType: typeof(FSResources))]
        public double HoursEstimate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_CostEstimate, FieldType: FieldTypes.Decimal, ResourceType: typeof(FSResources))]
        public double CostEstimate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_StatusType, WaterMark: FSResources.Names.ServiceTicketTemplate_StatusType_Select, HelpResource:FSResources.Names.ServiceTicketTemplate_StatusType_Help,  FieldType: FieldTypes.EntityHeaderPicker, IsRequired: true, ResourceType: typeof(FSResources))]
        public EntityHeader<StateSet> StatusType { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_DefaultContact, WaterMark: FSResources.Names.ServiceTicketTemplate_DefaultContact_Select, HelpResource: FSResources.Names.ServiceTicketTemplate_DefaultContact_Help, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources))]
        public EntityHeader DefaultContact { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Urgency, WaterMark: FSResources.Names.ServiceTicketTemplate_Urgency_Select, IsRequired: true, EnumType: typeof(Urgency), FieldType: FieldTypes.Picker, ResourceType: typeof(FSResources))]
        public EntityHeader<Urgency> Urgency {get; set;}

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Skill, WaterMark: FSResources.Names.ServiceTicketTemplate_Skill_Select, IsRequired: true, EnumType: typeof(SkillLevels), FieldType: FieldTypes.Picker, ResourceType: typeof(FSResources))]
        public EntityHeader<SkillLevels> SkillLevel { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_TroubleshootingSteps, FieldType: FieldTypes.ChildList, IsRequired: true, ResourceType: typeof(FSResources))]
        public List<SectionGrouping<TroubleshootingStep>> TroubleshootingSteps { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_ServiceParts, FieldType: FieldTypes.ChildList,  ResourceType: typeof(FSResources))]
        public List<SectionGrouping<BOMItem>> ServiceParts { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_PartsKits, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<EntityHeader<PartsKit>> PartsKits { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Resources, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<MediaResourceSummary> Resources { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Tools, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<SectionGrouping<EntityHeader<Equipment>>> Tools { get; set; }




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
