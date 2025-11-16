// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: c79b7561f3cb4d5cf6fd446f5a632f12c0c8a6590210207ef29a23fe008f313e
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Models.Resources;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LagoVista.IoT.Deployment.Models;
using LagoVista.Core.Interfaces;

namespace LagoVista.FSLite.Models
{
    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.Status_Name, FSResources.Names.Status_Help,
     FSResources.Names.Status_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources),
        FactoryUrl: "/api/fslite/ticketstatusdefinition/factory", GetListUrl: "/api/fslite/ticketstatusdefinition", GetUrl: "/api/fslite/ticketstatusdefinition/{id}",
        DeleteUrl: "/api/fslite/ticketstatusdefinition/{id}", SaveUrl: "/api/fslite/ticketstatusdefinition")]
    public class TicketStatusDefinition : FSModelBase, ISummaryFactory, IFormDescriptor
    {
        public TicketStatusDefinition()
        {
            Items = new List<TicketStatus>();
        }


        [FormField(LabelResource: FSResources.Names.Status_Options, FieldType: FieldTypes.ChildListInline, FactoryUrl: "/api/fslite/ticketstatusdefinition/item/factory", ResourceType: typeof(FSResources))]
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

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Description),
                nameof(Items),
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

        ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }

    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.Status_Name, FSResources.Names.Status_Help,
     FSResources.Names.Status_Description, EntityDescriptionAttribute.EntityTypes.Summary, typeof(FSResources),
        FactoryUrl: "/api/fslite/ticketstatusdefinition/factory", GetListUrl: "/api/fslite/ticketstatusdefinition", GetUrl: "/api/fslite/ticketstatusdefinition/{id}",
        DeleteUrl: "/api/fslite/ticketstatusdefinition/{id}", SaveUrl: "/api/fslite/ticketstatusdefinition")]
    public class TicketStatusDefinitionSummary : SummaryData
    {

    }

    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.Status_Name, FSResources.Names.Status_Help,
         FSResources.Names.Status_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources), FactoryUrl: "/api/fslite/ticketstatusdefinition/item/factory")]

    public class TicketStatus: IFormDescriptor
    {
        public TicketStatus()
        {
            TimeAllowedInStatusTimeSpan = EntityHeader<TimeSpanIntervals>.Create(TimeSpanIntervals.NotApplicable);
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [FormField(LabelResource: FSResources.Names.Status_IsClosed, HelpResource: FSResources.Names.Status_IsClosed_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool IsClosed { get; set; }

        [FormField(LabelResource: FSResources.Names.Status_TimeAllowedInStatus, HelpResource: FSResources.Names.Status_TimeAllowedInStatus, FieldType: FieldTypes.Picker, EnumType: typeof(TimeSpanIntervals), ResourceType: typeof(FSResources), IsRequired: true)]
        public EntityHeader<TimeSpanIntervals> TimeAllowedInStatusTimeSpan { get; set; }

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

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                  nameof(Name),
                  nameof(Key),
                  nameof(Code),
                  nameof(IsDefault),
                  nameof(IsDefault),
                  nameof(TimeAllowedInStatusTimeSpan),
                  nameof(TimeAllowedInStatusQuantity),
                  nameof(Description)
            };
        }

        [CustomValidator]
        public void Validate(ValidationResult result)
        {
            if (TimeAllowedInStatusTimeSpan.Value != TimeSpanIntervals.NotApplicable)
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
