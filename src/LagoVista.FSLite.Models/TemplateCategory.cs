using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;

namespace LagoVista.FSLite.Models
{
    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.Template_Category, FSResources.Names.Template_Category_Help,
         FSResources.Names.Template_Cateogry_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]

    public class TemplateCategory : FSModelBase
    {
        public TemplateCategorySummary CreateSummary()
        {
            return new TemplateCategorySummary()
            {
                Description = Description,
                Id = Id,
                IsPublic = IsPublic,
                Key = Key,
                Name = Name,
            };
        }
    }

    public class TemplateCategorySummary : SummaryData
    {

    }
}
