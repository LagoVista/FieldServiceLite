using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Models.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LagoVista.FSLite.Models
{
    public class FSModelBase : EntityBase, IValidateable, IDescriptionEntity
    {
        public FSModelBase()
        {
            Id = Guid.NewGuid().ToId();
        }

        [FormField(LabelResource: FSResources.Names.Common_Description, IsRequired: false, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(FSResources))]
        public string Description { get; set; }
    }
}

