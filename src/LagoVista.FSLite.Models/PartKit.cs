using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Collections.Generic;

namespace LagoVista.FSLite.Models
{
    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.PartsKit, FSResources.Names.PartKit_Help,
     FSResources.Names.PartKit_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]
    public class PartsKit : FSModelBase
    {
        public PartsKit()
        {
            Parts = new List<BOMItem>();
        }

        [FormField(LabelResource: FSResources.Names.PartKit_KitNumber, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true)]
        public string KitNumber { get; set; }

        [FormField(LabelResource: FSResources.Names.PartsKit_Parts, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<BOMItem> Parts { get; set; }

        public PartsKitSummary CreateSummary()
        {
            return new PartsKitSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Key = Key,
                Name = Name,
                Description = Description,
            };
        }
    }

    public class PartsKitSummary : SummaryData
    {

    }
}
