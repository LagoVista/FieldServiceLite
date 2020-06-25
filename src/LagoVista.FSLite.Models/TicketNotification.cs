using LagoVista.Core.Models;

namespace LagoVista.FSLite.Models
{
    public class TicketNotification
    {
        public string Timestamp { get; set; }

        public EntityHeader NotifiedUser { get; set; }
    }
}
