// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 047ddd4917537f361f5fa7619dc127a2c58729b234db25a1f442a455932247c7
// IndexVersion: 2
// --- END CODE INDEX META ---
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
