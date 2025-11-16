// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: ab8a319da44faa856ccf3d77df65222d5e0b8906ee829731b71fefa35add26dc
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Collections.Generic;

namespace LagoVista.FSLite.Models
{
    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.PartsKit, FSResources.Names.PartKit_Help,
     FSResources.Names.PartKit_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources),
        GetListUrl: "/api/fslite/partskits", GetUrl: "/api/fslite/partskit/{id}", SaveUrl: "/api/fslite/partskit",
        DeleteUrl: "/api/fslite/partskit/{id}", FactoryUrl: "/api/fslite/partskit/factory")]
    public class PartsKit : FSModelBase, ISummaryFactory
    {
        public PartsKit()
        {
            Parts = new List<SectionGrouping<BOMItem>>();
        }

        [FormField(LabelResource: FSResources.Names.PartKit_KitNumber, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true)]
        public string KitNumber { get; set; }

        [FormField(LabelResource: FSResources.Names.PartsKit_Parts, FieldType: FieldTypes.ChildList, ResourceType: typeof(FSResources))]
        public List<SectionGrouping<BOMItem>> Parts { get; set; }

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

        Core.Interfaces.ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }


    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.PartKits_Title, FSResources.Names.PartKit_Help,
     FSResources.Names.PartKit_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources),
        GetListUrl: "/api/fslite/partskits", GetUrl: "/api/fslite/partskit/{id}", SaveUrl: "/api/fslite/partskit",
        DeleteUrl: "/api/fslite/partskit/{id}", FactoryUrl: "/api/fslite/partskit/factory")]
    public class PartsKitSummary : SummaryData
    {

    }
}
