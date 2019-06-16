using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;
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

        [FormField(LabelResource: FSResources.Names.ServiceTicket_TicketId, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string TicketId { get; set; }

        public string DeviceLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Device, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public EntityHeader<Device> Device { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_AssignedTo, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources))]
        public EntityHeader AssignedTo { get; set; }
        [FormField(LabelResource: FSResources.Names.ServiceTicket_Status, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public EntityHeader Status { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_StatusDate, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: false)]
        public string StatusDate { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Address, FieldType: FieldTypes.ChildItem, ResourceType: typeof(FSResources))]
        public Address Address { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Details, FieldType: FieldTypes.ChildItem, ResourceType: typeof(FSResources))]
        public EntityHeader<ServiceTicketTemplate> Details { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_AssignedTo, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources))]
        public EntityHeader Company { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceTicket_Subject, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Subject { get; set; }




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

        public ServiceTicketSummary CreateSummary()
        {
            return new ServiceTicketSummary()
            {
                Id = Id,
                Subject = Subject,
                DeviceId = Device != null ? Device.Id : "-",
                IsClosed = IsClosed,
                Status = Status.Text,
                DueDate = DueDate,
                AssignedTo = AssignedTo.Text,
                Company = Company.Text
            };
        }
    }

    public class ServiceTicketSummary
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string DeviceId { get; set; }
        public bool IsClosed { get; set; }
        public string Status { get; set; }
        public string DueDate { get; set; }
        public string AssignedTo { get; set; }
        public string Company { get; set; }
    }

}
