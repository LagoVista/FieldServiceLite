using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.Models
{
    public class TicketFilter
    {
        public string UserId { get; set; }
        public string TemplateId { get; set; }
        public string StatusKey { get; set; }
        public bool? IsClosed { get; set; }
        public string DeviceId { get; set; }
        public string ServiceBoardId { get; set; }
    }
}
