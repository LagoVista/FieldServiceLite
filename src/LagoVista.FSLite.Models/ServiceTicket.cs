using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.DeviceManagement.Core.Models;
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
            History = new List<ServiceTicketStatusHistory>();
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

        [FormField(LabelResource: FSResources.Names.ServiceTicket_StatusDate, FieldType: FieldTypes.DateTime, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: false)]
        public string StatusDate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Address, FieldType: FieldTypes.ChildItem, ResourceType: typeof(FSResources))]
        public Address Address { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Details, FieldType: FieldTypes.ChildItem, ResourceType: typeof(FSResources))]
        public EntityHeader Template { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Subject, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Subject { get; set; }
        
        [FormField(LabelResource: FSResources.Names.ServiceTicket_ServiceBoard, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources))]
        public EntityHeader<ServiceBoard> ServiceBoard { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_IsClosed, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public bool IsClosed { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_ClosedBy, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources))]
        public EntityHeader ClosedBy { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_DueDate, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsUserEditable: true)]
        public string DueDate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Notes, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<ServiceTicketNote> Notes { get; set; }
       
        [FormField(LabelResource: FSResources.Names.ServiceTicket_History, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<ServiceTicketStatusHistory> History { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_HoursEstimate, FieldType: FieldTypes.Decimal, ResourceType: typeof(FSResources))]
        public double HoursEstimate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_CostEstimate, FieldType: FieldTypes.Decimal, ResourceType: typeof(FSResources))]
        public double CostEstimate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_StatusType, WaterMark: FSResources.Names.ServiceTicketTemplate_StatusType_Select, HelpResource: FSResources.Names.ServiceTicketTemplate_StatusType_Help, FieldType: FieldTypes.EntityHeaderPicker, IsRequired: true, ResourceType: typeof(FSResources))]
        public EntityHeader<StateSet> StatusType { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Urgency, WaterMark: FSResources.Names.ServiceTicketTemplate_Urgency_Select, IsRequired: true, EnumType: typeof(Urgency), FieldType: FieldTypes.Picker, ResourceType: typeof(FSResources))]
        public EntityHeader<Urgency> Urgency { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Skill, WaterMark: FSResources.Names.ServiceTicketTemplate_Skill_Select, IsRequired: true, EnumType: typeof(SkillLevels), FieldType: FieldTypes.Picker, ResourceType: typeof(FSResources))]
        public EntityHeader<SkillLevels> SkillLevel { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_Instructions, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public IEnumerable<ServiceTicketTemplateInstruction> Instructions { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_RequiredParts, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public IEnumerable<BOMItem> RequiredParts { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Resources, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public IEnumerable<MediaResource> Resources { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_TroubleshootingSteps, FieldType: FieldTypes.ChildList, IsRequired: true, ResourceType: typeof(FSResources))]
        public IEnumerable<TroubleshootingStep> TroubleshootingSteps { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicketTemplate_AssociatedEquipment, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public IEnumerable<EntityHeader<Equipment>> AssociatedEquipment { get; set; }

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
        public string Status { get; set; }
        public string DueDate { get; set; }
        public string Board { get; set; }
        public string AssignedTo { get; set; }
        public string Company { get; set; }
    }

}
