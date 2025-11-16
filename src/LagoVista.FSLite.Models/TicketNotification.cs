// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 20a6338809e9195b41741539a4235cc3776f7761067579cf38df09b0797a7bad
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models;

namespace LagoVista.FSLite.Models
{
    public class TicketNotification
    {
        public string Timestamp { get; set; }

        public EntityHeader NotifiedUser { get; set; }
    }
}
