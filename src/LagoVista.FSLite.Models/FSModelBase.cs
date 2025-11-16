// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: ffe1904be5ef3edbec00b12c61c0bccab22e7ac5e092b6d35d9f0113e41d716f
// IndexVersion: 2
// --- END CODE INDEX META ---
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

