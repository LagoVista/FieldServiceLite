using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Models.Resources;
using Newtonsoft.Json;
using System;

namespace LagoVista.FSLite.Models
{
    public class FSModelBase : IIDEntity, IValidateable, IOwnedEntity, INamedEntity, IAuditableEntity, INoSQLEntity
    {
        public FSModelBase()
        {
            Id = Guid.NewGuid().ToId();
        }

        [JsonProperty("id")]
        public String Id { get; set; }
        public bool IsPublic { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }
        public string CreationDate { get; set; }
        public string LastUpdatedDate { get; set; }
        public EntityHeader CreatedBy { get; set; }
        public EntityHeader LastUpdatedBy { get; set; }
        public string DatabaseName { get; set; }
        public string EntityType { get; set; }

        [ListColumn(HeaderResource: FSResources.Names.Common_Name, ResourceType: typeof(FSResources))]
        [FormField(LabelResource: FSResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources), IsRequired: true, IsUserEditable: true)]
        public string Name { get; set; }

        [ListColumn(HeaderResource: FSResources.Names.Common_Key, ResourceType: typeof(FSResources))]
        [FormField(LabelResource: FSResources.Names.Common_Key, HelpResource: FSResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: FSResources.Names.Common_Key_Validation, ResourceType: typeof(FSResources), IsRequired: true)]
        public string Key { get; set; }

        [FormField(LabelResource: FSResources.Names.Common_Description, IsRequired: false, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(FSResources))]
        public string Description { get; set; }
    }
}

