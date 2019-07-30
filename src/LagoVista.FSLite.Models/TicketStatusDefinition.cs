using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Models.Resources;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.Models
{

    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.Status_Name, FSResources.Names.Status_Help,
     FSResources.Names.Status_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]
    public class TicketStatusDefinition : FSModelBase
    {
        public TicketStatusDefinition()
        {
            Items = new List<TicketStatus>();
        }

        public List<TicketStatus> Items { get; set; }

        public TicketStatusDefinitionSummary CreateSummary()
        {
            return new TicketStatusDefinitionSummary()
            {
                Description = Description,
                Id = Id,
                IsPublic = IsPublic,
                Key = Key,
                Name = Name,
            };
        }

        [CustomValidator]
        public void Validate(ValidationResult result)
        {
            if (Items.Count() == 0)
            {
                result.AddUserError("Must provide at least one status item.");
            }

            if (Items.Where(itm => itm.IsDefault).Count() == 0)
            {
                result.AddUserError("Must provide at least one item that is set as the default value.");
            }
            else if (Items.Where(itm => itm.IsDefault).Count() > 1)
            {
                result.AddUserError("Can only have one item that is set as the default status.");
            }
        }
    }

    public class TicketStatusDefinitionSummary : SummaryData
    {

    }

    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.Status_Name, FSResources.Names.Status_Help,
         FSResources.Names.Status_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]

    public class TicketStatus
    {
        public TicketStatus()
        {
            TimeAllowedInStatusTimeSpan = EntityHeader<TimeToCompleteTimeSpans>.Create(TimeToCompleteTimeSpans.NotApplicable);
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [FormField(LabelResource: FSResources.Names.Status_IsClosed, HelpResource: FSResources.Names.Status_IsClosed_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool IsClosed { get; set; }

        [FormField(LabelResource: FSResources.Names.Status_TimeAllowedInStatus, HelpResource: FSResources.Names.Status_TimeAllowedInStatus, FieldType: FieldTypes.Picker, EnumType: typeof(TimeToCompleteTimeSpans), ResourceType: typeof(FSResources), IsRequired: true)]
        public EntityHeader<TimeToCompleteTimeSpans> TimeAllowedInStatusTimeSpan { get; set; }

        [FormField(LabelResource: FSResources.Names.Status_TimeAllowedInStatus, HelpResource: FSResources.Names.Status_TimeAllowedInStatus, FieldType: FieldTypes.Decimal, ResourceType: typeof(FSResources), IsRequired: false)]
        public double? TimeAllowedInStatusQuantity { get; set; }

        [FormField(LabelResource: FSResources.Names.Status_IsDefault, HelpResource: FSResources.Names.Status_IsDefault_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool IsDefault { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Name { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Key, HelpResource: FSResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: FSResources.Names.Common_Key_Validation, ResourceType: typeof(FSResources), IsRequired: true)]
        public string Key { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Description, IsRequired: false, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(FSResources))]
        public string Description { get; set; }

        [FormField(LabelResource: FSResources.Names.Status_Code, HelpResource: FSResources.Names.Status_Code_Help, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: false, IsUserEditable: true)]
        public string Code { get; set; }

        [CustomValidator]
        public void Validate(ValidationResult result)
        {
            if (TimeAllowedInStatusTimeSpan.Value != TimeToCompleteTimeSpans.NotApplicable)
            {
                if(!TimeAllowedInStatusQuantity.HasValue)
                {
                    result.AddUserError($"{FSResources.Status_TimeAllowedInStatus_Quantity} is a required field.");
                }
            }
            else
            {
                TimeAllowedInStatusQuantity = null;
            }
        }
    }
}
