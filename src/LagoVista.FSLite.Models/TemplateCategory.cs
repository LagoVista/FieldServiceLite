﻿using LagoVista.Core.Attributes;
using LagoVista.FSLite.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.FSLite.Models
{
    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.Template_Category, FSResources.Names.Template_Category_Help,
         FSResources.Names.Template_Cateogry_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]

    public class TemplateCategory : FSModelBase
    {

    }
}