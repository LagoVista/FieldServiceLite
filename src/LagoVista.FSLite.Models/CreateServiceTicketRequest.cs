using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.Models
{
    public class CreateServiceTicketRequest
    {
        public string ServiceTicketTemplateId { get; set; }
        public string DeviceId { get; set; }
        public string DueDate { get; set; }
    }
}
