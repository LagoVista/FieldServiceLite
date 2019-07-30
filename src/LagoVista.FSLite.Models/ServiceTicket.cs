using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;
using LagoVista.IoT.Deployment.Admin.Models;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.DeviceManagement.Core.Models;
using LagoVista.MediaServices.Models;
using System;
using System.Collections.Generic;

namespace LagoVista.FSLite.Models
{
    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.ServiceTicket_Title, FSResources.Names.ServiceTicket_Help,
     FSResources.Names.ServiceTicket_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]
    public class ServiceTicket : FSModelBase
    {
        public ServiceTicket()
        {
            Notes = new List<ServiceTicketNote>();
            Resources = new List<MediaResourceSummary>();
            History = new List<ServiceTicketStatusHistory>();

            Instructions = new List<SectionGrouping<ServiceTicketTemplateInstruction>>();
            ServiceParts = new List<SectionGrouping<BOMItem>>();
            Tools = new List<EquipmentSummary>();
            TroubleshootingSteps = new List<SectionGrouping<TroubleshootingStep>>();
        }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_TicketId, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string TicketId { get; set; }

        public string DeviceLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Device, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public EntityHeader<Device> Device { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_AssignedTo, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources))]
        public EntityHeader AssignedTo { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Status, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public EntityHeader Status { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_IsViewed, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public bool IsViewed { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_ViewedBy, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsUserEditable: false)]
        public EntityHeader ViewedBy { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_ViewedDate, FieldType: FieldTypes.Text, IsUserEditable: false, ResourceType: typeof(FSResources))]
        public string ViewedDate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_StatusDate, FieldType: FieldTypes.DateTime, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: false)]
        public string StatusDate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Address, FieldType: FieldTypes.ChildItem, ResourceType: typeof(FSResources))]
        public Address Address { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Details, FieldType: FieldTypes.ChildItem, ResourceType: typeof(FSResources))]
        public EntityHeader<ServiceTicketTemplate> Template { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Subject, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Subject { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_ServiceBoard, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources))]
        public EntityHeader<ServiceBoard> ServiceBoard { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_IsClosed, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public bool IsClosed { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_ClosedBy, FieldType: FieldTypes.Text, IsUserEditable: false, ResourceType: typeof(FSResources))]
        public EntityHeader ClosedBy { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_ClosedDate, FieldType: FieldTypes.Text, IsUserEditable: false, ResourceType: typeof(FSResources))]
        public string ClosedDate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_DueDate, FieldType: FieldTypes.DateTime, ResourceType: typeof(FSResources), IsUserEditable: true)]
        public string DueDate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_StatusDueDate, HelpResource: FSResources.Names.ServiceTicket_StatusDueDate_Help, FieldType: FieldTypes.DateTime, ResourceType: typeof(FSResources), IsUserEditable: true)]
        public string StatusDueDate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Notes, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<ServiceTicketNote> Notes { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_History, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<ServiceTicketStatusHistory> History { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_HoursEstimate, FieldType: FieldTypes.Decimal, ResourceType: typeof(FSResources))]
        public double HoursEstimate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_CostEstimate, FieldType: FieldTypes.Decimal, ResourceType: typeof(FSResources))]
        public double CostEstimate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_StatusType, WaterMark: FSResources.Names.ServiceTicketTemplate_StatusType_Select, HelpResource: FSResources.Names.ServiceTicketTemplate_StatusType_Help, FieldType: FieldTypes.EntityHeaderPicker, IsRequired: true, ResourceType: typeof(FSResources))]
        public EntityHeader<TicketStatusDefinition> StatusType { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Urgency, WaterMark: FSResources.Names.ServiceTicketTemplate_Urgency_Select, IsRequired: true, EnumType: typeof(Urgency), FieldType: FieldTypes.Picker, ResourceType: typeof(FSResources))]
        public EntityHeader<Urgency> Urgency { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Skill, WaterMark: FSResources.Names.ServiceTicketTemplate_Skill_Select, IsRequired: true, EnumType: typeof(SkillLevels), FieldType: FieldTypes.Picker, ResourceType: typeof(FSResources))]
        public EntityHeader<SkillLevels> SkillLevel { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Instructions, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<SectionGrouping<ServiceTicketTemplateInstruction>> Instructions { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_ServiceParts, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<SectionGrouping<BOMItem>> ServiceParts { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Resources, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public IEnumerable<MediaResourceSummary> Resources { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_TroubleshootingSteps, FieldType: FieldTypes.ChildList, IsRequired: true, ResourceType: typeof(FSResources))]
        public List<SectionGrouping<TroubleshootingStep>> TroubleshootingSteps { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Tools, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<EquipmentSummary> Tools { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_PartsKits, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<PartsKitSummary> PartsKits { get; set; }


        [FormField(LabelResource: FSResources.Names.ServiceTicket_DeviceRepo, FieldType: FieldTypes.ChildItem, ResourceType: typeof(FSResources))]
        public EntityHeader DeviceRepo { get; set; }

        public ServiceTicketSummary CreateSummary()
        {
            return new ServiceTicketSummary()
            {
                Id = Id,
                Subject = Subject,
                DeviceId = Device != null ? Device.Id : "-",
                Device = Device != null ? Device.Text : "-",
                IsClosed = IsClosed,
                Status = Status.Text,
                Board = ServiceBoard != null ? ServiceBoard.Text : "-",
                DueDate = string.IsNullOrEmpty(DueDate) ? "-" : DueDate,
                StatusDueDate = string.IsNullOrEmpty(StatusDueDate) ? "-" : StatusDueDate,
                ClosedBy = EntityHeader.IsNullOrEmpty(ClosedBy) ? "-" : ClosedBy.Text,
                ViewedBy = EntityHeader.IsNullOrEmpty(ViewedBy) ? "-" : ViewedBy.Text,
                ViewedDate = string.IsNullOrEmpty(ViewedDate) ? "-" : ViewedDate,
                ClosedDate = string.IsNullOrEmpty(ClosedDate) ? "-" : ClosedDate,
                AssignedTo = AssignedTo != null ? AssignedTo.Text : "-",
                TicketId = TicketId,
            };
        }
    }

    public class ServiceTicketSummary
    {
        public string Id { get; set; }
        public string TicketId { get; set; }
        public string Subject { get; set; }
        public string DeviceId { get; set; }
        public string Device { get; set; }
        public bool IsClosed { get; set; }
        public string ClosedBy { get; set; }
        public string ClosedDate { get; set; }
        public bool IsViewed { get; set; }
        public string ViewedBy { get; set; }
        public string ViewedDate { get; set; }
        public string Status { get; set; }
        public string DueDate { get; set; }
        public string StatusDueDate { get; set; }
        public string Board { get; set; }
        public string AssignedTo { get; set; }
        public string Company { get; set; }
    }

}
