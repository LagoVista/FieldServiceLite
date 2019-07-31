using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.FSLite.Models.Resources;

namespace LagoVista.FSLite.Models
{
    [EntityDescription(FSDomain.FieldServiceLite, FSResources.Names.Template_Category, FSResources.Names.Template_Category_Help,
         FSResources.Names.Template_Cateogry_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(FSResources))]
    public class TemplateCategory : FSModelBase
    {
        public TemplateCategory()
        {
            InstructionConfiguration = new InstructionsConfiguration();
            TroubleshootingConfiguration = new TroubleshootingConfiguration();

            InstructionsLabel = FSResources.TemplateCategory_Instructions_Default;
            TroubleshootingStepsLabel = FSResources.TemplateCategory_TroubleshootingSteps_Default;
            PrimaryContactLabel = FSResources.TemplateCategory_PrimaryContact_Default;
            ResourcesLabel = FSResources.TemplateCategory_Resources_Default;
            CostEstimateLabel = FSResources.TemplateCategory_CostEstimate_Default;
            HoursEstimateLabel = FSResources.TemplateCategory_HoursEstimate_Default;
            ServicePartsLabel = FSResources.TemplateCategory_ServiceParts_Default;
            ToolsLabel = FSResources.TemplateCategory_Tools_Default;
            PartsKitsLabel = FSResources.TemplateCategory_PartsKit_Default;
            UrgencyLabel = FSResources.TemplateCategory_Urgency_Default;
            SkillLevelLabel = FSResources.TemplateCategory_TicketLabel_Default;
            TicketLabel = FSResources.TemplateCategory_TicketLabel_Default;
            SubjectLabel = FSResources.TemplateCategory_Subject_Default;
            IsViewedLabel = FSResources.TemplateCategory_IsViewed_Default;
            IsClosedLabel = FSResources.TemplateCategory_IsClosed_Default;
            StatusLabel = FSResources.TemplateCategory_Status_Default;
            SubjectLabel = FSResources.TemplateCategory_Subject_Default;
            ServiceBoardLabel = FSResources.TemplateCategory_ServiceBoard_Default;
            StatusDateLabel = FSResources.TemplateCategory_StatusDate_Default;
            StatusDueDateLabel = FSResources.TemplateCategory_StatusDueDate_Default;
            DueDateLabel = FSResources.TemplateCategory_DueDate_Default;

            ShowCostEstimate = true;
            ShowHoursEstimate = true;
            ShowInstructions = true;
            ShowResources = true;
            ShowServiceParts = true;
            ShowTools = true;
            ShowPartsKits = true;
            ShowUrgency = true;
            ShowSkillLevel = true;
            ShowIsViewed = true;
            ShowTroubleshootingSteps = true;
            ShowDueDate = true;
            ShowStatusDate = true;
            ShowStatusDueDate = true;
        }

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

        [FormField(LabelResource: FSResources.Names.TemplateCategory_TicketLabel, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_TicketLabel_Help, ResourceType: typeof(FSResources))]
        public string TicketLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateCategory_Subject_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_Subject_Help, ResourceType: typeof(FSResources))]
        public string SubjectLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateCategory_Status_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_Status_Help, ResourceType: typeof(FSResources))]
        public string StatusLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateCategory_IsClosed_Label, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public string IsClosedLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateCategory_IsViewed_Show,  FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowIsViewed { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_IsViewed_Label, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public string IsViewedLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateCategory_PrimaryContactLabel, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_PrimaryContactLabel_Help, ResourceType: typeof(FSResources))]
        public string PrimaryContactLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateCategory_ServiceBoard_Label, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public string ServiceBoardLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_ShowInstructions, HelpResource: FSResources.Names.TemplateCategory_Instructions_label_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowInstructions { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_Instructions_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_Instructions_label_Help, ResourceType: typeof(FSResources))]
        public string InstructionsLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_ShowDueDate, HelpResource: FSResources.Names.TemplateCategory_DueDate_label_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowDueDate { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_DueDate_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_Instructions_label_Help, ResourceType: typeof(FSResources))]
        public string DueDateLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_ShowStatusDate, HelpResource: FSResources.Names.TemplateCategory_StatusDate_label_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowStatusDate { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_StatusDate_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_StatusDate_label_Help, ResourceType: typeof(FSResources))]
        public string StatusDateLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_ShowStatusDueDate, HelpResource: FSResources.Names.TemplateCategory_StatusDueDate_label_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowStatusDueDate { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_StatusDueDate_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_StatusDueDate_label_Help, ResourceType: typeof(FSResources))]
        public string StatusDueDateLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_Urgency_Show, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowUrgency { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_Urgency_Label, FieldType: FieldTypes.Text,ResourceType: typeof(FSResources))]
        public string UrgencyLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_SkillLevel_Show, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowSkillLevel { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_SkillLevel_Label, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public string SkillLevelLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_Show_TS, HelpResource: FSResources.Names.TemplateCategory_Show_TS_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowTroubleshootingSteps { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_TS_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_Show_TS_Help, ResourceType: typeof(FSResources))]
        public string TroubleshootingStepsLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_Show_Resource, HelpResource: FSResources.Names.TemplateCategory_Show_Resource_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowResources { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_Resources_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_Show_Resource_Help, ResourceType: typeof(FSResources))]
        public string ResourcesLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_CostEstimate_Show, HelpResource: FSResources.Names.TemplateCategory_CostEstimate_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowCostEstimate { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_CostEstimate_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_CostEstimate_Help, ResourceType: typeof(FSResources))]
        public string CostEstimateLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_HoursEstimate_Show, HelpResource: FSResources.Names.TemplateCategory_HoursEstimate_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowHoursEstimate { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_HoursEstimate_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_HoursEstimate_Help, ResourceType: typeof(FSResources))]
        public string HoursEstimateLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_ServiceParts_Show, HelpResource: FSResources.Names.TemplateCategory_ServiceParts_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowServiceParts { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_ServiceParts_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_ServiceParts_Help, ResourceType: typeof(FSResources))]
        public string ServicePartsLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_PartsKit_Show, HelpResource: FSResources.Names.TemplateCategory_PartsKit_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowPartsKits { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_PartsKit_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_PartsKit_Help, ResourceType: typeof(FSResources))]
        public string PartsKitsLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.TemplateCategory_Show_Tools, HelpResource:FSResources.Names.TemplateCategory_Show_Tools_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowTools { get; set; }
        [FormField(LabelResource: FSResources.Names.TemplateCategory_ShowTools_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TemplateCategory_Show_Tools_Help, ResourceType: typeof(FSResources))]
        public string ToolsLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateCategory_Instructions_Configuration, FieldType: FieldTypes.ChildView, ResourceType: typeof(FSResources))]
        public InstructionsConfiguration InstructionConfiguration { get; set; }

        [FormField(LabelResource: FSResources.Names.TemplateCategory_TroubleshootingSteps_Configuration, FieldType: FieldTypes.ChildView, ResourceType: typeof(FSResources))]
        public TroubleshootingConfiguration TroubleshootingConfiguration { get; set; }
    }
    

    public class TemplateCategorySummary : SummaryData
    {

    }

    public class InstructionsConfiguration
    {
        public InstructionsConfiguration()
        {
            NameLabel = FSResources.Instructions_Name_Default;
            InstructionsLabel = FSResources.Instructions_Instructions_Default;
            HintsLabel = FSResources.Instructions_Hints_Default;
            ToolsLabel = FSResources.Instructions_Tools_Default;
            NotesLabel = FSResources.Instructions_Notes_Default;
            ResourcesLabel = FSResources.Instructions_Resources_Default;

            ShowName = true;
            ShowInstructions = true;
            ShowHints = true;
            ShowTools = true;
            ShowResources = true;
            ShowNotes = true;
        }

        [FormField(LabelResource: FSResources.Names.Instructions_Name_Show, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowName { get; set; }
        [FormField(LabelResource: FSResources.Names.Instructions_Name_Label, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public string NameLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.Instructions_Instructions_Show, HelpResource: FSResources.Names.Instructions_Instructions_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowInstructions { get; set; }
        [FormField(LabelResource: FSResources.Names.Instructions_Instructions_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.Instructions_Instructions_Help, ResourceType: typeof(FSResources))]
        public string InstructionsLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.Instructions_Hints_Show, HelpResource: FSResources.Names.Instructions_Hints_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowHints { get; set; }
        [FormField(LabelResource: FSResources.Names.Instructions_Hints_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.Instructions_Hints_Help, ResourceType: typeof(FSResources))]
        public string HintsLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.Instructions_Notes_Show, HelpResource: FSResources.Names.Instructions_Hints_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowNotes { get; set; }
        [FormField(LabelResource: FSResources.Names.Instructions_Notes_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.Instructions_Hints_Help, ResourceType: typeof(FSResources))]
        public string NotesLabel { get; set; }


        [FormField(LabelResource: FSResources.Names.Instructions_Tools_Show, HelpResource: FSResources.Names.Instructions_Tools_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowTools { get; set; }
        [FormField(LabelResource: FSResources.Names.Instructions_Tools_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.Instructions_Tools_Help, ResourceType: typeof(FSResources))]
        public string ToolsLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.Instructions_Resources_Show, HelpResource: FSResources.Names.Instructions_Resources_Default, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowResources { get; set; }
        [FormField(LabelResource: FSResources.Names.Instructions_Resources_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.Instructions_Resources_Default, ResourceType: typeof(FSResources))]
        public string ResourcesLabel { get; set; }
    }

    public class TroubleshootingConfiguration
    {
        public TroubleshootingConfiguration()
        {
            InstructionsLabel = FSResources.TS_Instructions_Default;
            ProblemLabel = FSResources.TS_Problem_Default;
            NotesLabel = FSResources.TS_Notes_Default;
            ExpectedOutcomeLabel = FSResources.TS_ExpectedOutcome_Default;
            NameLabel = FSResources.TS_Notes_Default;
            ResourcesLabel = FSResources.TS_Resources_Default;
            ToolsLabel = FSResources.TS_Tools_Default;

            ShowName = true;
            ShowInstructions = true;
            ShowProblem = true;
            ShowNotes = true;
            ShowExpectedOutcome = true;
            ShowResources = true;
            ShowTools = true;
        }

        [FormField(LabelResource: FSResources.Names.TS_Instructions_Show, HelpResource: FSResources.Names.TS_Instructions_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowInstructions { get; set; }
        [FormField(LabelResource: FSResources.Names.TS_Instructions_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TS_Instructions_Help, ResourceType: typeof(FSResources))]
        public string InstructionsLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TS_Problem_Show, HelpResource: FSResources.Names.TS_Problem_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowProblem { get; set; }
        [FormField(LabelResource: FSResources.Names.TS_Problem_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TS_Problem_Help, ResourceType: typeof(FSResources))]
        public string ProblemLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TS_Notes_Show, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowNotes { get; set; }
        [FormField(LabelResource: FSResources.Names.TS_Notes_Label, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public string NotesLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TS_ExpectedOutcome_Show, HelpResource: FSResources.Names.TS_ExpectedOutcome_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowExpectedOutcome { get; set; }
        [FormField(LabelResource: FSResources.Names.TS_ExpectedOutcome_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TS_ExpectedOutcome_Help, ResourceType: typeof(FSResources))]
        public string ExpectedOutcomeLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TS_Name_Show, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowName { get; set; }
        [FormField(LabelResource: FSResources.Names.TS_Name_Label, FieldType: FieldTypes.Text, ResourceType: typeof(FSResources))]
        public string NameLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TS_Resources_Show, HelpResource: FSResources.Names.TS_Resources_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowResources { get; set; }
        [FormField(LabelResource: FSResources.Names.TS_Resourcess_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TS_Resources_Help, ResourceType: typeof(FSResources))]
        public string ResourcesLabel { get; set; }

        [FormField(LabelResource: FSResources.Names.TS_Tools_Show, HelpResource: FSResources.Names.TS_Tools_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(FSResources))]
        public bool ShowTools { get; set; }
        [FormField(LabelResource: FSResources.Names.TS_Tools_Label, FieldType: FieldTypes.Text, HelpResource: FSResources.Names.TS_Tools_Help, ResourceType: typeof(FSResources))]
        public string ToolsLabel { get; set; }
    }
}
