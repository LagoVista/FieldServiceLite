using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.Models
{
    public class CreateServiceTicketRequest
    {
        public string BoardId { get; set; }
        public string TemplateId { get; set; }
        public string RepoId { get; set; }
        public string DeviceId { get; set; }
        public string Subject { get; set; }
    }
}
