using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.Models
{
    public class TicketStatusItems : FSModelBase
    {
        public TicketStatusItems()
        {
            Items = new List<TicketStatus>();
        }

        public List<TicketStatus> Items { get; set; }
    }

    public class TicketStatus
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public bool IsClosed { get; set; }

        [FormField(LabelResource: FSResources.Names.Template_Time_ToComplete_TimeSpan, HelpResource: FSResources.Names.Template_Time_ToComplete_TimeSpan_Help, FieldType: FieldTypes.Picker, EnumType: typeof(TimeToCompleteTimeSpans), ResourceType: typeof(FSResources), IsRequired: true)]
        public EntityHeader<TimeToCompleteTimeSpans> TimeToCompleteTimeSpan { get; set; }

        [FormField(LabelResource: FSResources.Names.Template_Time_ToComplete_Quantity, HelpResource: FSResources.Names.Template_Time_ToComplete_Quantity_Help, FieldType: FieldTypes.Decimal, ResourceType: typeof(FSResources), IsRequired: false)]
        public double? TimeToCompleteQuantity { get; set; }

        public bool IsDefault { get; set; }

        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }

        public string Code { get; set; }

    }
}
