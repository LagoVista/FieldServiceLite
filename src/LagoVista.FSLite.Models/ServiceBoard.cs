using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.Models
{

    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.ServiceBoard_Title, FSResources.Names.ServiceBoard_Help,
        FSResources.Names.ServiceBoard_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]
    public class ServiceBoard : FSModelBase
    {
        [FormField(LabelResource: FSResources.Names.ServiceBoard_BoardOwner, WaterMark: FSResources.Names.ServiceBoard_BoardOwner_Select, HelpResource: FSResources.Names.ServiceBoard_BoardOwner_Help, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(FSResources))]
        public EntityHeader PrimaryContact { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceBoard_Abbreviation,HelpResource: FSResources.Names.ServiceBoard_Abbreviation_Help, ValidationRegEx: "^[a-zA-Z]{3}$", RegExValidationMessageResource: FSResources.Names.ServiceBoard_Abbreviation_Help, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public string BoardAbbreviation { get; set; }

        [FormField(LabelResource: FSResources.Names.ServiceBoard_SequenceNumber, HelpResource: FSResources.Names.ServiceBoard_SequenceNumber_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(FSResources))]
        public int TicketSequenceNumber { get; set; }

        public ServiceBoardSummary CreateSummary()
        {
            return new ServiceBoardSummary()
            {
                Description = Description,
                Id = Id,
                Key = Key,
                IsPublic = IsPublic,
                Name = Name,
            };
        }
    }

    public class ServiceBoardSummary : SummaryData
    {

    }
}
