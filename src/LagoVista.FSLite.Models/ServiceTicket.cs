using LagoVista.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.Models
{
    public class ServiceTicket : FSModelBase
    {
        public string TicketId { get; set; }

        public EntityHeader AssignedToId { get; set; }

        public string Subject { get; set; }

        public string DueDate { get; set; }

        public string Status { get; set; }
        public string StatusDate { get; set; }

        public List<ServiceTicketNote> Notes { get; set; }
        public List<ServiceTicketStatusHistory> History { get; set; }
    }

    public class ServiceTicketStatusHistory
    {
        public string DateStamp { get; set; }
        public EntityHeader ChangedBy { get; set; }
        public string Status { get; set; }

        public string Notes { get; set; }
    }

    public class ServiceTicketNote
    {
        public EntityHeader AddedBy { get; set; }
        public string DateStamp { get; set; }

        public string Note { get; set; }
    }
}
