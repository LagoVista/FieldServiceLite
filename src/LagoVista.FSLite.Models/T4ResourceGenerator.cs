/*12/19/2023 6:26:50 AM*/
using System.Globalization;
using System.Reflection;

//Resources:FSResources:Common_CreatedBy
namespace LagoVista.FSLite.Models.Resources
{
	public class FSResources
	{
        private static global::System.Resources.ResourceManager _resourceManager;
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static global::System.Resources.ResourceManager ResourceManager 
		{
            get 
			{
                if (object.ReferenceEquals(_resourceManager, null)) 
				{
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LagoVista.FSLite.Models.Resources.FSResources", typeof(FSResources).GetTypeInfo().Assembly);
                    _resourceManager = temp;
                }
                return _resourceManager;
            }
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static string GetResourceString(string key, params string[] tokens)
		{
			var culture = CultureInfo.CurrentCulture;;
            var str = ResourceManager.GetString(key, culture);

			for(int i = 0; i < tokens.Length; i += 2)
				str = str.Replace(tokens[i], tokens[i+1]);
										
            return str;
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
		/*
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static HtmlString GetResourceHtmlString(string key, params string[] tokens)
		{
			var str = GetResourceString(key, tokens);
							
			if(str.StartsWith("HTML:"))
				str = str.Substring(5);

			return new HtmlString(str);
        }*/
		
		public static string Common_CreatedBy { get { return GetResourceString("Common_CreatedBy"); } }
//Resources:FSResources:Common_CreationDate

		public static string Common_CreationDate { get { return GetResourceString("Common_CreationDate"); } }
//Resources:FSResources:Common_Description

		public static string Common_Description { get { return GetResourceString("Common_Description"); } }
//Resources:FSResources:Common_IsPublic

		public static string Common_IsPublic { get { return GetResourceString("Common_IsPublic"); } }
//Resources:FSResources:Common_IsRequired

		public static string Common_IsRequired { get { return GetResourceString("Common_IsRequired"); } }
//Resources:FSResources:Common_IsValid

		public static string Common_IsValid { get { return GetResourceString("Common_IsValid"); } }
//Resources:FSResources:Common_Key

		public static string Common_Key { get { return GetResourceString("Common_Key"); } }
//Resources:FSResources:Common_Key_Help

		public static string Common_Key_Help { get { return GetResourceString("Common_Key_Help"); } }
//Resources:FSResources:Common_Key_Validation

		public static string Common_Key_Validation { get { return GetResourceString("Common_Key_Validation"); } }
//Resources:FSResources:Common_LastUpdated

		public static string Common_LastUpdated { get { return GetResourceString("Common_LastUpdated"); } }
//Resources:FSResources:Common_LastUpdatedBy

		public static string Common_LastUpdatedBy { get { return GetResourceString("Common_LastUpdatedBy"); } }
//Resources:FSResources:Common_Name

		public static string Common_Name { get { return GetResourceString("Common_Name"); } }
//Resources:FSResources:Common_Note

		public static string Common_Note { get { return GetResourceString("Common_Note"); } }
//Resources:FSResources:Common_Notes

		public static string Common_Notes { get { return GetResourceString("Common_Notes"); } }
//Resources:FSResources:Common_PageNumberOne

		public static string Common_PageNumberOne { get { return GetResourceString("Common_PageNumberOne"); } }
//Resources:FSResources:Common_PartNumber

		public static string Common_PartNumber { get { return GetResourceString("Common_PartNumber"); } }
//Resources:FSResources:Common_Resources

		public static string Common_Resources { get { return GetResourceString("Common_Resources"); } }
//Resources:FSResources:Common_UniqueId

		public static string Common_UniqueId { get { return GetResourceString("Common_UniqueId"); } }
//Resources:FSResources:Common_ValidationErrors

		public static string Common_ValidationErrors { get { return GetResourceString("Common_ValidationErrors"); } }
//Resources:FSResources:Instructions_Hints_Default

		public static string Instructions_Hints_Default { get { return GetResourceString("Instructions_Hints_Default"); } }
//Resources:FSResources:Instructions_Hints_Help

		public static string Instructions_Hints_Help { get { return GetResourceString("Instructions_Hints_Help"); } }
//Resources:FSResources:Instructions_Hints_Label

		public static string Instructions_Hints_Label { get { return GetResourceString("Instructions_Hints_Label"); } }
//Resources:FSResources:Instructions_Hints_Show

		public static string Instructions_Hints_Show { get { return GetResourceString("Instructions_Hints_Show"); } }
//Resources:FSResources:Instructions_Instructions_Default

		public static string Instructions_Instructions_Default { get { return GetResourceString("Instructions_Instructions_Default"); } }
//Resources:FSResources:Instructions_Instructions_Help

		public static string Instructions_Instructions_Help { get { return GetResourceString("Instructions_Instructions_Help"); } }
//Resources:FSResources:Instructions_Instructions_Label

		public static string Instructions_Instructions_Label { get { return GetResourceString("Instructions_Instructions_Label"); } }
//Resources:FSResources:Instructions_Instructions_Show

		public static string Instructions_Instructions_Show { get { return GetResourceString("Instructions_Instructions_Show"); } }
//Resources:FSResources:Instructions_Name_Default

		public static string Instructions_Name_Default { get { return GetResourceString("Instructions_Name_Default"); } }
//Resources:FSResources:Instructions_Name_Label

		public static string Instructions_Name_Label { get { return GetResourceString("Instructions_Name_Label"); } }
//Resources:FSResources:Instructions_Name_Show

		public static string Instructions_Name_Show { get { return GetResourceString("Instructions_Name_Show"); } }
//Resources:FSResources:Instructions_Notes_Default

		public static string Instructions_Notes_Default { get { return GetResourceString("Instructions_Notes_Default"); } }
//Resources:FSResources:Instructions_Notes_Label

		public static string Instructions_Notes_Label { get { return GetResourceString("Instructions_Notes_Label"); } }
//Resources:FSResources:Instructions_Notes_Show

		public static string Instructions_Notes_Show { get { return GetResourceString("Instructions_Notes_Show"); } }
//Resources:FSResources:Instructions_Resource_Help

		public static string Instructions_Resource_Help { get { return GetResourceString("Instructions_Resource_Help"); } }
//Resources:FSResources:Instructions_Resources_Default

		public static string Instructions_Resources_Default { get { return GetResourceString("Instructions_Resources_Default"); } }
//Resources:FSResources:Instructions_Resources_Label

		public static string Instructions_Resources_Label { get { return GetResourceString("Instructions_Resources_Label"); } }
//Resources:FSResources:Instructions_Resources_Show

		public static string Instructions_Resources_Show { get { return GetResourceString("Instructions_Resources_Show"); } }
//Resources:FSResources:Instructions_StepId_Default

		public static string Instructions_StepId_Default { get { return GetResourceString("Instructions_StepId_Default"); } }
//Resources:FSResources:Instructions_StepId_Label

		public static string Instructions_StepId_Label { get { return GetResourceString("Instructions_StepId_Label"); } }
//Resources:FSResources:Instructions_StepId_Show

		public static string Instructions_StepId_Show { get { return GetResourceString("Instructions_StepId_Show"); } }
//Resources:FSResources:Instructions_Tools_Default

		public static string Instructions_Tools_Default { get { return GetResourceString("Instructions_Tools_Default"); } }
//Resources:FSResources:Instructions_Tools_Help

		public static string Instructions_Tools_Help { get { return GetResourceString("Instructions_Tools_Help"); } }
//Resources:FSResources:Instructions_Tools_Label

		public static string Instructions_Tools_Label { get { return GetResourceString("Instructions_Tools_Label"); } }
//Resources:FSResources:Instructions_Tools_Show

		public static string Instructions_Tools_Show { get { return GetResourceString("Instructions_Tools_Show"); } }
//Resources:FSResources:PartKit_Description

		public static string PartKit_Description { get { return GetResourceString("PartKit_Description"); } }
//Resources:FSResources:PartKit_Help

		public static string PartKit_Help { get { return GetResourceString("PartKit_Help"); } }
//Resources:FSResources:PartKit_KitNumber

		public static string PartKit_KitNumber { get { return GetResourceString("PartKit_KitNumber"); } }
//Resources:FSResources:PartKit_Name

		public static string PartKit_Name { get { return GetResourceString("PartKit_Name"); } }
//Resources:FSResources:PartKits_Title

		public static string PartKits_Title { get { return GetResourceString("PartKits_Title"); } }
//Resources:FSResources:PartsKit

		public static string PartsKit { get { return GetResourceString("PartsKit"); } }
//Resources:FSResources:PartsKit_Parts

		public static string PartsKit_Parts { get { return GetResourceString("PartsKit_Parts"); } }
//Resources:FSResources:ServiceBoard_Abbreviation

		public static string ServiceBoard_Abbreviation { get { return GetResourceString("ServiceBoard_Abbreviation"); } }
//Resources:FSResources:ServiceBoard_Abbreviation_Help

		public static string ServiceBoard_Abbreviation_Help { get { return GetResourceString("ServiceBoard_Abbreviation_Help"); } }
//Resources:FSResources:ServiceBoard_BoardOwner

		public static string ServiceBoard_BoardOwner { get { return GetResourceString("ServiceBoard_BoardOwner"); } }
//Resources:FSResources:ServiceBoard_BoardOwner_Help

		public static string ServiceBoard_BoardOwner_Help { get { return GetResourceString("ServiceBoard_BoardOwner_Help"); } }
//Resources:FSResources:ServiceBoard_BoardOwner_Select

		public static string ServiceBoard_BoardOwner_Select { get { return GetResourceString("ServiceBoard_BoardOwner_Select"); } }
//Resources:FSResources:ServiceBoard_Description

		public static string ServiceBoard_Description { get { return GetResourceString("ServiceBoard_Description"); } }
//Resources:FSResources:ServiceBoard_Help

		public static string ServiceBoard_Help { get { return GetResourceString("ServiceBoard_Help"); } }
//Resources:FSResources:ServiceBoard_SequenceNumber

		public static string ServiceBoard_SequenceNumber { get { return GetResourceString("ServiceBoard_SequenceNumber"); } }
//Resources:FSResources:ServiceBoard_SequenceNumber_Help

		public static string ServiceBoard_SequenceNumber_Help { get { return GetResourceString("ServiceBoard_SequenceNumber_Help"); } }
//Resources:FSResources:ServiceBoard_Title

		public static string ServiceBoard_Title { get { return GetResourceString("ServiceBoard_Title"); } }
//Resources:FSResources:ServiceBoards_Title

		public static string ServiceBoards_Title { get { return GetResourceString("ServiceBoards_Title"); } }
//Resources:FSResources:ServiceTicekt_SilenceNotifications

		public static string ServiceTicekt_SilenceNotifications { get { return GetResourceString("ServiceTicekt_SilenceNotifications"); } }
//Resources:FSResources:ServiceTicket_Address

		public static string ServiceTicket_Address { get { return GetResourceString("ServiceTicket_Address"); } }
//Resources:FSResources:ServiceTicket_AssignedTo

		public static string ServiceTicket_AssignedTo { get { return GetResourceString("ServiceTicket_AssignedTo"); } }
//Resources:FSResources:ServiceTicket_ClosedBy

		public static string ServiceTicket_ClosedBy { get { return GetResourceString("ServiceTicket_ClosedBy"); } }
//Resources:FSResources:ServiceTicket_ClosedDate

		public static string ServiceTicket_ClosedDate { get { return GetResourceString("ServiceTicket_ClosedDate"); } }
//Resources:FSResources:ServiceTicket_Company

		public static string ServiceTicket_Company { get { return GetResourceString("ServiceTicket_Company"); } }
//Resources:FSResources:ServiceTicket_Description

		public static string ServiceTicket_Description { get { return GetResourceString("ServiceTicket_Description"); } }
//Resources:FSResources:ServiceTicket_Details

		public static string ServiceTicket_Details { get { return GetResourceString("ServiceTicket_Details"); } }
//Resources:FSResources:ServiceTicket_Device

		public static string ServiceTicket_Device { get { return GetResourceString("ServiceTicket_Device"); } }
//Resources:FSResources:ServiceTicket_DeviceRepo

		public static string ServiceTicket_DeviceRepo { get { return GetResourceString("ServiceTicket_DeviceRepo"); } }
//Resources:FSResources:ServiceTicket_DueDate

		public static string ServiceTicket_DueDate { get { return GetResourceString("ServiceTicket_DueDate"); } }
//Resources:FSResources:ServiceTicket_Help

		public static string ServiceTicket_Help { get { return GetResourceString("ServiceTicket_Help"); } }
//Resources:FSResources:ServiceTicket_History

		public static string ServiceTicket_History { get { return GetResourceString("ServiceTicket_History"); } }
//Resources:FSResources:ServiceTicket_IsClosed

		public static string ServiceTicket_IsClosed { get { return GetResourceString("ServiceTicket_IsClosed"); } }
//Resources:FSResources:ServiceTicket_IsViewed

		public static string ServiceTicket_IsViewed { get { return GetResourceString("ServiceTicket_IsViewed"); } }
//Resources:FSResources:ServiceTicket_LastNotification

		public static string ServiceTicket_LastNotification { get { return GetResourceString("ServiceTicket_LastNotification"); } }
//Resources:FSResources:ServiceTicket_LastNotifiedUser

		public static string ServiceTicket_LastNotifiedUser { get { return GetResourceString("ServiceTicket_LastNotifiedUser"); } }
//Resources:FSResources:ServiceTicket_NextNotification

		public static string ServiceTicket_NextNotification { get { return GetResourceString("ServiceTicket_NextNotification"); } }
//Resources:FSResources:ServiceTicket_Notes

		public static string ServiceTicket_Notes { get { return GetResourceString("ServiceTicket_Notes"); } }
//Resources:FSResources:ServiceTicket_ServiceBoard

		public static string ServiceTicket_ServiceBoard { get { return GetResourceString("ServiceTicket_ServiceBoard"); } }
//Resources:FSResources:ServiceTicket_Status

		public static string ServiceTicket_Status { get { return GetResourceString("ServiceTicket_Status"); } }
//Resources:FSResources:ServiceTicket_StatusDate

		public static string ServiceTicket_StatusDate { get { return GetResourceString("ServiceTicket_StatusDate"); } }
//Resources:FSResources:ServiceTicket_StatusDueDate

		public static string ServiceTicket_StatusDueDate { get { return GetResourceString("ServiceTicket_StatusDueDate"); } }
//Resources:FSResources:ServiceTicket_StatusDueDate_Help

		public static string ServiceTicket_StatusDueDate_Help { get { return GetResourceString("ServiceTicket_StatusDueDate_Help"); } }
//Resources:FSResources:ServiceTicket_Subject

		public static string ServiceTicket_Subject { get { return GetResourceString("ServiceTicket_Subject"); } }
//Resources:FSResources:ServiceTicket_TicketId

		public static string ServiceTicket_TicketId { get { return GetResourceString("ServiceTicket_TicketId"); } }
//Resources:FSResources:ServiceTicket_Title

		public static string ServiceTicket_Title { get { return GetResourceString("ServiceTicket_Title"); } }
//Resources:FSResources:ServiceTicket_ViewedBy

		public static string ServiceTicket_ViewedBy { get { return GetResourceString("ServiceTicket_ViewedBy"); } }
//Resources:FSResources:ServiceTicket_ViewedDate

		public static string ServiceTicket_ViewedDate { get { return GetResourceString("ServiceTicket_ViewedDate"); } }
//Resources:FSResources:ServiceTicketNote_AddedBy

		public static string ServiceTicketNote_AddedBy { get { return GetResourceString("ServiceTicketNote_AddedBy"); } }
//Resources:FSResources:ServiceTicketNote_DateStamp

		public static string ServiceTicketNote_DateStamp { get { return GetResourceString("ServiceTicketNote_DateStamp"); } }
//Resources:FSResources:ServiceTicketNote_Description

		public static string ServiceTicketNote_Description { get { return GetResourceString("ServiceTicketNote_Description"); } }
//Resources:FSResources:ServiceTicketNote_Help

		public static string ServiceTicketNote_Help { get { return GetResourceString("ServiceTicketNote_Help"); } }
//Resources:FSResources:ServiceTicketNote_Note

		public static string ServiceTicketNote_Note { get { return GetResourceString("ServiceTicketNote_Note"); } }
//Resources:FSResources:ServiceTicketNote_Title

		public static string ServiceTicketNote_Title { get { return GetResourceString("ServiceTicketNote_Title"); } }
//Resources:FSResources:ServiceTickets_Title

		public static string ServiceTickets_Title { get { return GetResourceString("ServiceTickets_Title"); } }
//Resources:FSResources:ServiceTicketStatusHistory_AddedBy

		public static string ServiceTicketStatusHistory_AddedBy { get { return GetResourceString("ServiceTicketStatusHistory_AddedBy"); } }
//Resources:FSResources:ServiceTicketStatusHistory_DateStamp

		public static string ServiceTicketStatusHistory_DateStamp { get { return GetResourceString("ServiceTicketStatusHistory_DateStamp"); } }
//Resources:FSResources:ServiceTicketStatusHistory_Description

		public static string ServiceTicketStatusHistory_Description { get { return GetResourceString("ServiceTicketStatusHistory_Description"); } }
//Resources:FSResources:ServiceTicketStatusHistory_Help

		public static string ServiceTicketStatusHistory_Help { get { return GetResourceString("ServiceTicketStatusHistory_Help"); } }
//Resources:FSResources:ServiceTicketStatusHistory_Notes

		public static string ServiceTicketStatusHistory_Notes { get { return GetResourceString("ServiceTicketStatusHistory_Notes"); } }
//Resources:FSResources:ServiceTicketStatusHistory_Status

		public static string ServiceTicketStatusHistory_Status { get { return GetResourceString("ServiceTicketStatusHistory_Status"); } }
//Resources:FSResources:ServiceTicketStatusHistory_StatusDueDate

		public static string ServiceTicketStatusHistory_StatusDueDate { get { return GetResourceString("ServiceTicketStatusHistory_StatusDueDate"); } }
//Resources:FSResources:ServiceTicketStatusHistory_Title

		public static string ServiceTicketStatusHistory_Title { get { return GetResourceString("ServiceTicketStatusHistory_Title"); } }
//Resources:FSResources:ServiceTicketTemplate_Category

		public static string ServiceTicketTemplate_Category { get { return GetResourceString("ServiceTicketTemplate_Category"); } }
//Resources:FSResources:ServiceTicketTemplate_Category_Help

		public static string ServiceTicketTemplate_Category_Help { get { return GetResourceString("ServiceTicketTemplate_Category_Help"); } }
//Resources:FSResources:ServiceTicketTemplate_Categroy_WaterMark

		public static string ServiceTicketTemplate_Categroy_WaterMark { get { return GetResourceString("ServiceTicketTemplate_Categroy_WaterMark"); } }
//Resources:FSResources:ServiceTicketTemplate_CostEstimate

		public static string ServiceTicketTemplate_CostEstimate { get { return GetResourceString("ServiceTicketTemplate_CostEstimate"); } }
//Resources:FSResources:ServiceTicketTemplate_DefaultAssigned

		public static string ServiceTicketTemplate_DefaultAssigned { get { return GetResourceString("ServiceTicketTemplate_DefaultAssigned"); } }
//Resources:FSResources:ServiceTicketTemplate_DefaultContact

		public static string ServiceTicketTemplate_DefaultContact { get { return GetResourceString("ServiceTicketTemplate_DefaultContact"); } }
//Resources:FSResources:ServiceTicketTemplate_DefaultContact_Help

		public static string ServiceTicketTemplate_DefaultContact_Help { get { return GetResourceString("ServiceTicketTemplate_DefaultContact_Help"); } }
//Resources:FSResources:ServiceTicketTemplate_DefaultContact_Select

		public static string ServiceTicketTemplate_DefaultContact_Select { get { return GetResourceString("ServiceTicketTemplate_DefaultContact_Select"); } }
//Resources:FSResources:ServiceTicketTemplate_DefaultDescription

		public static string ServiceTicketTemplate_DefaultDescription { get { return GetResourceString("ServiceTicketTemplate_DefaultDescription"); } }
//Resources:FSResources:ServiceTicketTemplate_DefaultDescription_Help

		public static string ServiceTicketTemplate_DefaultDescription_Help { get { return GetResourceString("ServiceTicketTemplate_DefaultDescription_Help"); } }
//Resources:FSResources:ServiceTicketTemplate_DefaultSubject

		public static string ServiceTicketTemplate_DefaultSubject { get { return GetResourceString("ServiceTicketTemplate_DefaultSubject"); } }
//Resources:FSResources:ServiceTicketTemplate_DefaultSubject_Help

		public static string ServiceTicketTemplate_DefaultSubject_Help { get { return GetResourceString("ServiceTicketTemplate_DefaultSubject_Help"); } }
//Resources:FSResources:ServiceTicketTemplate_Description

		public static string ServiceTicketTemplate_Description { get { return GetResourceString("ServiceTicketTemplate_Description"); } }
//Resources:FSResources:ServiceTicketTemplate_DeviceConfig

		public static string ServiceTicketTemplate_DeviceConfig { get { return GetResourceString("ServiceTicketTemplate_DeviceConfig"); } }
//Resources:FSResources:ServiceTicketTemplate_DeviceConfig_Help

		public static string ServiceTicketTemplate_DeviceConfig_Help { get { return GetResourceString("ServiceTicketTemplate_DeviceConfig_Help"); } }
//Resources:FSResources:ServiceTicketTemplate_DeviceConfig_Select

		public static string ServiceTicketTemplate_DeviceConfig_Select { get { return GetResourceString("ServiceTicketTemplate_DeviceConfig_Select"); } }
//Resources:FSResources:ServiceTicketTemplate_DeviceType

		public static string ServiceTicketTemplate_DeviceType { get { return GetResourceString("ServiceTicketTemplate_DeviceType"); } }
//Resources:FSResources:ServiceTicketTemplate_DeviceType_Help

		public static string ServiceTicketTemplate_DeviceType_Help { get { return GetResourceString("ServiceTicketTemplate_DeviceType_Help"); } }
//Resources:FSResources:ServiceTicketTemplate_DeviceType_Select

		public static string ServiceTicketTemplate_DeviceType_Select { get { return GetResourceString("ServiceTicketTemplate_DeviceType_Select"); } }
//Resources:FSResources:ServiceTicketTemplate_Help

		public static string ServiceTicketTemplate_Help { get { return GetResourceString("ServiceTicketTemplate_Help"); } }
//Resources:FSResources:ServiceTicketTemplate_HoursEstimate

		public static string ServiceTicketTemplate_HoursEstimate { get { return GetResourceString("ServiceTicketTemplate_HoursEstimate"); } }
//Resources:FSResources:ServiceTicketTemplate_Instructions

		public static string ServiceTicketTemplate_Instructions { get { return GetResourceString("ServiceTicketTemplate_Instructions"); } }
//Resources:FSResources:ServiceTicketTemplate_OpenReminderNotification_Quantity

		public static string ServiceTicketTemplate_OpenReminderNotification_Quantity { get { return GetResourceString("ServiceTicketTemplate_OpenReminderNotification_Quantity"); } }
//Resources:FSResources:ServiceTicketTemplate_OpenReminderNotification_TimeSpan

		public static string ServiceTicketTemplate_OpenReminderNotification_TimeSpan { get { return GetResourceString("ServiceTicketTemplate_OpenReminderNotification_TimeSpan"); } }
//Resources:FSResources:ServiceTicketTemplate_OpenReminderNotification_TimeSpan_Help

		public static string ServiceTicketTemplate_OpenReminderNotification_TimeSpan_Help { get { return GetResourceString("ServiceTicketTemplate_OpenReminderNotification_TimeSpan_Help"); } }
//Resources:FSResources:ServiceTicketTemplate_PartsKits

		public static string ServiceTicketTemplate_PartsKits { get { return GetResourceString("ServiceTicketTemplate_PartsKits"); } }
//Resources:FSResources:ServiceTicketTemplate_ServiceParts

		public static string ServiceTicketTemplate_ServiceParts { get { return GetResourceString("ServiceTicketTemplate_ServiceParts"); } }
//Resources:FSResources:ServiceTicketTemplate_Skill

		public static string ServiceTicketTemplate_Skill { get { return GetResourceString("ServiceTicketTemplate_Skill"); } }
//Resources:FSResources:ServiceTicketTemplate_Skill_High

		public static string ServiceTicketTemplate_Skill_High { get { return GetResourceString("ServiceTicketTemplate_Skill_High"); } }
//Resources:FSResources:ServiceTicketTemplate_Skill_Low

		public static string ServiceTicketTemplate_Skill_Low { get { return GetResourceString("ServiceTicketTemplate_Skill_Low"); } }
//Resources:FSResources:ServiceTicketTemplate_Skill_Medium

		public static string ServiceTicketTemplate_Skill_Medium { get { return GetResourceString("ServiceTicketTemplate_Skill_Medium"); } }
//Resources:FSResources:ServiceTicketTemplate_Skill_Select

		public static string ServiceTicketTemplate_Skill_Select { get { return GetResourceString("ServiceTicketTemplate_Skill_Select"); } }
//Resources:FSResources:ServiceTicketTemplate_StatusType

		public static string ServiceTicketTemplate_StatusType { get { return GetResourceString("ServiceTicketTemplate_StatusType"); } }
//Resources:FSResources:ServiceTicketTemplate_StatusType_Help

		public static string ServiceTicketTemplate_StatusType_Help { get { return GetResourceString("ServiceTicketTemplate_StatusType_Help"); } }
//Resources:FSResources:ServiceTicketTemplate_StatusType_Select

		public static string ServiceTicketTemplate_StatusType_Select { get { return GetResourceString("ServiceTicketTemplate_StatusType_Select"); } }
//Resources:FSResources:ServiceTicketTemplate_Title

		public static string ServiceTicketTemplate_Title { get { return GetResourceString("ServiceTicketTemplate_Title"); } }
//Resources:FSResources:ServiceTicketTemplate_Tools

		public static string ServiceTicketTemplate_Tools { get { return GetResourceString("ServiceTicketTemplate_Tools"); } }
//Resources:FSResources:ServiceTicketTemplate_TroubleshootingSteps

		public static string ServiceTicketTemplate_TroubleshootingSteps { get { return GetResourceString("ServiceTicketTemplate_TroubleshootingSteps"); } }
//Resources:FSResources:ServiceTicketTemplate_Urgency

		public static string ServiceTicketTemplate_Urgency { get { return GetResourceString("ServiceTicketTemplate_Urgency"); } }
//Resources:FSResources:ServiceTicketTemplate_Urgency_CriticalSafety

		public static string ServiceTicketTemplate_Urgency_CriticalSafety { get { return GetResourceString("ServiceTicketTemplate_Urgency_CriticalSafety"); } }
//Resources:FSResources:ServiceTicketTemplate_Urgency_Important

		public static string ServiceTicketTemplate_Urgency_Important { get { return GetResourceString("ServiceTicketTemplate_Urgency_Important"); } }
//Resources:FSResources:ServiceTicketTemplate_Urgency_Low

		public static string ServiceTicketTemplate_Urgency_Low { get { return GetResourceString("ServiceTicketTemplate_Urgency_Low"); } }
//Resources:FSResources:ServiceTicketTemplate_Urgency_Normal

		public static string ServiceTicketTemplate_Urgency_Normal { get { return GetResourceString("ServiceTicketTemplate_Urgency_Normal"); } }
//Resources:FSResources:ServiceTicketTemplate_Urgency_Select

		public static string ServiceTicketTemplate_Urgency_Select { get { return GetResourceString("ServiceTicketTemplate_Urgency_Select"); } }
//Resources:FSResources:ServiceTicketTemplateDefault_Assigned_Help

		public static string ServiceTicketTemplateDefault_Assigned_Help { get { return GetResourceString("ServiceTicketTemplateDefault_Assigned_Help"); } }
//Resources:FSResources:ServiceTicketTemplates_Title

		public static string ServiceTicketTemplates_Title { get { return GetResourceString("ServiceTicketTemplates_Title"); } }
//Resources:FSResources:SP_Name_Show

		public static string SP_Name_Show { get { return GetResourceString("SP_Name_Show"); } }
//Resources:FSResources:Status_Code

		public static string Status_Code { get { return GetResourceString("Status_Code"); } }
//Resources:FSResources:Status_Code_Help

		public static string Status_Code_Help { get { return GetResourceString("Status_Code_Help"); } }
//Resources:FSResources:Status_Description

		public static string Status_Description { get { return GetResourceString("Status_Description"); } }
//Resources:FSResources:Status_Help

		public static string Status_Help { get { return GetResourceString("Status_Help"); } }
//Resources:FSResources:Status_IsClosed

		public static string Status_IsClosed { get { return GetResourceString("Status_IsClosed"); } }
//Resources:FSResources:Status_IsClosed_Help

		public static string Status_IsClosed_Help { get { return GetResourceString("Status_IsClosed_Help"); } }
//Resources:FSResources:Status_IsDefault

		public static string Status_IsDefault { get { return GetResourceString("Status_IsDefault"); } }
//Resources:FSResources:Status_IsDefault_Help

		public static string Status_IsDefault_Help { get { return GetResourceString("Status_IsDefault_Help"); } }
//Resources:FSResources:Status_Name

		public static string Status_Name { get { return GetResourceString("Status_Name"); } }
//Resources:FSResources:Status_Options

		public static string Status_Options { get { return GetResourceString("Status_Options"); } }
//Resources:FSResources:Status_TimeAllowedInStatus

		public static string Status_TimeAllowedInStatus { get { return GetResourceString("Status_TimeAllowedInStatus"); } }
//Resources:FSResources:Status_TimeAllowedInStatus_Help

		public static string Status_TimeAllowedInStatus_Help { get { return GetResourceString("Status_TimeAllowedInStatus_Help"); } }
//Resources:FSResources:Status_TimeAllowedInStatus_Quantity

		public static string Status_TimeAllowedInStatus_Quantity { get { return GetResourceString("Status_TimeAllowedInStatus_Quantity"); } }
//Resources:FSResources:StatusItems_Description

		public static string StatusItems_Description { get { return GetResourceString("StatusItems_Description"); } }
//Resources:FSResources:StatusItems_Name

		public static string StatusItems_Name { get { return GetResourceString("StatusItems_Name"); } }
//Resources:FSResources:Template_Categories

		public static string Template_Categories { get { return GetResourceString("Template_Categories"); } }
//Resources:FSResources:Template_Category

		public static string Template_Category { get { return GetResourceString("Template_Category"); } }
//Resources:FSResources:Template_Category_Help

		public static string Template_Category_Help { get { return GetResourceString("Template_Category_Help"); } }
//Resources:FSResources:Template_Cateogry_Description

		public static string Template_Cateogry_Description { get { return GetResourceString("Template_Cateogry_Description"); } }
//Resources:FSResources:Template_Exclusive

		public static string Template_Exclusive { get { return GetResourceString("Template_Exclusive"); } }
//Resources:FSResources:Template_Exclusive_Help

		public static string Template_Exclusive_Help { get { return GetResourceString("Template_Exclusive_Help"); } }
//Resources:FSResources:Template_Time_ToComplete_Days

		public static string Template_Time_ToComplete_Days { get { return GetResourceString("Template_Time_ToComplete_Days"); } }
//Resources:FSResources:Template_Time_ToComplete_Hours

		public static string Template_Time_ToComplete_Hours { get { return GetResourceString("Template_Time_ToComplete_Hours"); } }
//Resources:FSResources:Template_Time_ToComplete_Minutes

		public static string Template_Time_ToComplete_Minutes { get { return GetResourceString("Template_Time_ToComplete_Minutes"); } }
//Resources:FSResources:Template_Time_ToComplete_NotApplicable

		public static string Template_Time_ToComplete_NotApplicable { get { return GetResourceString("Template_Time_ToComplete_NotApplicable"); } }
//Resources:FSResources:Template_Time_ToComplete_Quantity

		public static string Template_Time_ToComplete_Quantity { get { return GetResourceString("Template_Time_ToComplete_Quantity"); } }
//Resources:FSResources:Template_Time_ToComplete_Quantity_Help

		public static string Template_Time_ToComplete_Quantity_Help { get { return GetResourceString("Template_Time_ToComplete_Quantity_Help"); } }
//Resources:FSResources:Template_Time_ToComplete_Select

		public static string Template_Time_ToComplete_Select { get { return GetResourceString("Template_Time_ToComplete_Select"); } }
//Resources:FSResources:Template_Time_ToComplete_TimeSpan

		public static string Template_Time_ToComplete_TimeSpan { get { return GetResourceString("Template_Time_ToComplete_TimeSpan"); } }
//Resources:FSResources:Template_Time_ToComplete_TimeSpan_Help

		public static string Template_Time_ToComplete_TimeSpan_Help { get { return GetResourceString("Template_Time_ToComplete_TimeSpan_Help"); } }
//Resources:FSResources:TemplateCategory_CostEstimate_Default

		public static string TemplateCategory_CostEstimate_Default { get { return GetResourceString("TemplateCategory_CostEstimate_Default"); } }
//Resources:FSResources:TemplateCategory_CostEstimate_Help

		public static string TemplateCategory_CostEstimate_Help { get { return GetResourceString("TemplateCategory_CostEstimate_Help"); } }
//Resources:FSResources:TemplateCategory_CostEstimate_Label

		public static string TemplateCategory_CostEstimate_Label { get { return GetResourceString("TemplateCategory_CostEstimate_Label"); } }
//Resources:FSResources:TemplateCategory_CostEstimate_Show

		public static string TemplateCategory_CostEstimate_Show { get { return GetResourceString("TemplateCategory_CostEstimate_Show"); } }
//Resources:FSResources:TemplateCategory_DueDate_Default

		public static string TemplateCategory_DueDate_Default { get { return GetResourceString("TemplateCategory_DueDate_Default"); } }
//Resources:FSResources:TemplateCategory_DueDate_Label

		public static string TemplateCategory_DueDate_Label { get { return GetResourceString("TemplateCategory_DueDate_Label"); } }
//Resources:FSResources:TemplateCategory_DueDate_label_Help

		public static string TemplateCategory_DueDate_label_Help { get { return GetResourceString("TemplateCategory_DueDate_label_Help"); } }
//Resources:FSResources:TemplateCategory_HoursEstimate_Default

		public static string TemplateCategory_HoursEstimate_Default { get { return GetResourceString("TemplateCategory_HoursEstimate_Default"); } }
//Resources:FSResources:TemplateCategory_HoursEstimate_Help

		public static string TemplateCategory_HoursEstimate_Help { get { return GetResourceString("TemplateCategory_HoursEstimate_Help"); } }
//Resources:FSResources:TemplateCategory_HoursEstimate_Label

		public static string TemplateCategory_HoursEstimate_Label { get { return GetResourceString("TemplateCategory_HoursEstimate_Label"); } }
//Resources:FSResources:TemplateCategory_HoursEstimate_Show

		public static string TemplateCategory_HoursEstimate_Show { get { return GetResourceString("TemplateCategory_HoursEstimate_Show"); } }
//Resources:FSResources:TemplateCategory_Instructions_Configuration

		public static string TemplateCategory_Instructions_Configuration { get { return GetResourceString("TemplateCategory_Instructions_Configuration"); } }
//Resources:FSResources:TemplateCategory_Instructions_Default

		public static string TemplateCategory_Instructions_Default { get { return GetResourceString("TemplateCategory_Instructions_Default"); } }
//Resources:FSResources:TemplateCategory_Instructions_Label

		public static string TemplateCategory_Instructions_Label { get { return GetResourceString("TemplateCategory_Instructions_Label"); } }
//Resources:FSResources:TemplateCategory_Instructions_label_Help

		public static string TemplateCategory_Instructions_label_Help { get { return GetResourceString("TemplateCategory_Instructions_label_Help"); } }
//Resources:FSResources:TemplateCategory_IsClosed_Default

		public static string TemplateCategory_IsClosed_Default { get { return GetResourceString("TemplateCategory_IsClosed_Default"); } }
//Resources:FSResources:TemplateCategory_IsClosed_Label

		public static string TemplateCategory_IsClosed_Label { get { return GetResourceString("TemplateCategory_IsClosed_Label"); } }
//Resources:FSResources:TemplateCategory_IsViewed_Default

		public static string TemplateCategory_IsViewed_Default { get { return GetResourceString("TemplateCategory_IsViewed_Default"); } }
//Resources:FSResources:TemplateCategory_IsViewed_Label

		public static string TemplateCategory_IsViewed_Label { get { return GetResourceString("TemplateCategory_IsViewed_Label"); } }
//Resources:FSResources:TemplateCategory_IsViewed_Show

		public static string TemplateCategory_IsViewed_Show { get { return GetResourceString("TemplateCategory_IsViewed_Show"); } }
//Resources:FSResources:TemplateCategory_PartsKit_Default

		public static string TemplateCategory_PartsKit_Default { get { return GetResourceString("TemplateCategory_PartsKit_Default"); } }
//Resources:FSResources:TemplateCategory_PartsKit_Help

		public static string TemplateCategory_PartsKit_Help { get { return GetResourceString("TemplateCategory_PartsKit_Help"); } }
//Resources:FSResources:TemplateCategory_PartsKit_Label

		public static string TemplateCategory_PartsKit_Label { get { return GetResourceString("TemplateCategory_PartsKit_Label"); } }
//Resources:FSResources:TemplateCategory_PartsKit_Show

		public static string TemplateCategory_PartsKit_Show { get { return GetResourceString("TemplateCategory_PartsKit_Show"); } }
//Resources:FSResources:TemplateCategory_PrimaryContact_Default

		public static string TemplateCategory_PrimaryContact_Default { get { return GetResourceString("TemplateCategory_PrimaryContact_Default"); } }
//Resources:FSResources:TemplateCategory_PrimaryContactLabel

		public static string TemplateCategory_PrimaryContactLabel { get { return GetResourceString("TemplateCategory_PrimaryContactLabel"); } }
//Resources:FSResources:TemplateCategory_PrimaryContactLabel_Help

		public static string TemplateCategory_PrimaryContactLabel_Help { get { return GetResourceString("TemplateCategory_PrimaryContactLabel_Help"); } }
//Resources:FSResources:TemplateCategory_Resources_Default

		public static string TemplateCategory_Resources_Default { get { return GetResourceString("TemplateCategory_Resources_Default"); } }
//Resources:FSResources:TemplateCategory_Resources_Label

		public static string TemplateCategory_Resources_Label { get { return GetResourceString("TemplateCategory_Resources_Label"); } }
//Resources:FSResources:TemplateCategory_ServiceBoard_Default

		public static string TemplateCategory_ServiceBoard_Default { get { return GetResourceString("TemplateCategory_ServiceBoard_Default"); } }
//Resources:FSResources:TemplateCategory_ServiceBoard_Label

		public static string TemplateCategory_ServiceBoard_Label { get { return GetResourceString("TemplateCategory_ServiceBoard_Label"); } }
//Resources:FSResources:TemplateCategory_ServiceParts_Default

		public static string TemplateCategory_ServiceParts_Default { get { return GetResourceString("TemplateCategory_ServiceParts_Default"); } }
//Resources:FSResources:TemplateCategory_ServiceParts_Help

		public static string TemplateCategory_ServiceParts_Help { get { return GetResourceString("TemplateCategory_ServiceParts_Help"); } }
//Resources:FSResources:TemplateCategory_ServiceParts_Label

		public static string TemplateCategory_ServiceParts_Label { get { return GetResourceString("TemplateCategory_ServiceParts_Label"); } }
//Resources:FSResources:TemplateCategory_ServiceParts_Show

		public static string TemplateCategory_ServiceParts_Show { get { return GetResourceString("TemplateCategory_ServiceParts_Show"); } }
//Resources:FSResources:TemplateCategory_Show_Resource

		public static string TemplateCategory_Show_Resource { get { return GetResourceString("TemplateCategory_Show_Resource"); } }
//Resources:FSResources:TemplateCategory_Show_Resource_Help

		public static string TemplateCategory_Show_Resource_Help { get { return GetResourceString("TemplateCategory_Show_Resource_Help"); } }
//Resources:FSResources:TemplateCategory_Show_Tools

		public static string TemplateCategory_Show_Tools { get { return GetResourceString("TemplateCategory_Show_Tools"); } }
//Resources:FSResources:TemplateCategory_Show_Tools_Help

		public static string TemplateCategory_Show_Tools_Help { get { return GetResourceString("TemplateCategory_Show_Tools_Help"); } }
//Resources:FSResources:TemplateCategory_Show_TS

		public static string TemplateCategory_Show_TS { get { return GetResourceString("TemplateCategory_Show_TS"); } }
//Resources:FSResources:TemplateCategory_Show_TS_Help

		public static string TemplateCategory_Show_TS_Help { get { return GetResourceString("TemplateCategory_Show_TS_Help"); } }
//Resources:FSResources:TemplateCategory_ShowDueDate

		public static string TemplateCategory_ShowDueDate { get { return GetResourceString("TemplateCategory_ShowDueDate"); } }
//Resources:FSResources:TemplateCategory_ShowInstructions

		public static string TemplateCategory_ShowInstructions { get { return GetResourceString("TemplateCategory_ShowInstructions"); } }
//Resources:FSResources:TemplateCategory_ShowInstructions_Help

		public static string TemplateCategory_ShowInstructions_Help { get { return GetResourceString("TemplateCategory_ShowInstructions_Help"); } }
//Resources:FSResources:TemplateCategory_ShowStatusDate

		public static string TemplateCategory_ShowStatusDate { get { return GetResourceString("TemplateCategory_ShowStatusDate"); } }
//Resources:FSResources:TemplateCategory_ShowStatusDueDate

		public static string TemplateCategory_ShowStatusDueDate { get { return GetResourceString("TemplateCategory_ShowStatusDueDate"); } }
//Resources:FSResources:TemplateCategory_ShowTools_Label

		public static string TemplateCategory_ShowTools_Label { get { return GetResourceString("TemplateCategory_ShowTools_Label"); } }
//Resources:FSResources:TemplateCategory_SkillLevel_Default

		public static string TemplateCategory_SkillLevel_Default { get { return GetResourceString("TemplateCategory_SkillLevel_Default"); } }
//Resources:FSResources:TemplateCategory_SkillLevel_Label

		public static string TemplateCategory_SkillLevel_Label { get { return GetResourceString("TemplateCategory_SkillLevel_Label"); } }
//Resources:FSResources:TemplateCategory_SkillLevel_Show

		public static string TemplateCategory_SkillLevel_Show { get { return GetResourceString("TemplateCategory_SkillLevel_Show"); } }
//Resources:FSResources:TemplateCategory_Status_Default

		public static string TemplateCategory_Status_Default { get { return GetResourceString("TemplateCategory_Status_Default"); } }
//Resources:FSResources:TemplateCategory_Status_Help

		public static string TemplateCategory_Status_Help { get { return GetResourceString("TemplateCategory_Status_Help"); } }
//Resources:FSResources:TemplateCategory_Status_Label

		public static string TemplateCategory_Status_Label { get { return GetResourceString("TemplateCategory_Status_Label"); } }
//Resources:FSResources:TemplateCategory_StatusDate_Default

		public static string TemplateCategory_StatusDate_Default { get { return GetResourceString("TemplateCategory_StatusDate_Default"); } }
//Resources:FSResources:TemplateCategory_StatusDate_Label

		public static string TemplateCategory_StatusDate_Label { get { return GetResourceString("TemplateCategory_StatusDate_Label"); } }
//Resources:FSResources:TemplateCategory_StatusDate_label_Help

		public static string TemplateCategory_StatusDate_label_Help { get { return GetResourceString("TemplateCategory_StatusDate_label_Help"); } }
//Resources:FSResources:TemplateCategory_StatusDueDate_Default

		public static string TemplateCategory_StatusDueDate_Default { get { return GetResourceString("TemplateCategory_StatusDueDate_Default"); } }
//Resources:FSResources:TemplateCategory_StatusDueDate_Label

		public static string TemplateCategory_StatusDueDate_Label { get { return GetResourceString("TemplateCategory_StatusDueDate_Label"); } }
//Resources:FSResources:TemplateCategory_StatusDueDate_label_Help

		public static string TemplateCategory_StatusDueDate_label_Help { get { return GetResourceString("TemplateCategory_StatusDueDate_label_Help"); } }
//Resources:FSResources:TemplateCategory_Subject_Default

		public static string TemplateCategory_Subject_Default { get { return GetResourceString("TemplateCategory_Subject_Default"); } }
//Resources:FSResources:TemplateCategory_Subject_Help

		public static string TemplateCategory_Subject_Help { get { return GetResourceString("TemplateCategory_Subject_Help"); } }
//Resources:FSResources:TemplateCategory_Subject_Label

		public static string TemplateCategory_Subject_Label { get { return GetResourceString("TemplateCategory_Subject_Label"); } }
//Resources:FSResources:TemplateCategory_TicketLabel

		public static string TemplateCategory_TicketLabel { get { return GetResourceString("TemplateCategory_TicketLabel"); } }
//Resources:FSResources:TemplateCategory_TicketLabel_Default

		public static string TemplateCategory_TicketLabel_Default { get { return GetResourceString("TemplateCategory_TicketLabel_Default"); } }
//Resources:FSResources:TemplateCategory_TicketLabel_Help

		public static string TemplateCategory_TicketLabel_Help { get { return GetResourceString("TemplateCategory_TicketLabel_Help"); } }
//Resources:FSResources:TemplateCategory_Tools_Default

		public static string TemplateCategory_Tools_Default { get { return GetResourceString("TemplateCategory_Tools_Default"); } }
//Resources:FSResources:TemplateCategory_TroubleshootingSteps_Configuration

		public static string TemplateCategory_TroubleshootingSteps_Configuration { get { return GetResourceString("TemplateCategory_TroubleshootingSteps_Configuration"); } }
//Resources:FSResources:TemplateCategory_TroubleshootingSteps_Default

		public static string TemplateCategory_TroubleshootingSteps_Default { get { return GetResourceString("TemplateCategory_TroubleshootingSteps_Default"); } }
//Resources:FSResources:TemplateCategory_TS_Label

		public static string TemplateCategory_TS_Label { get { return GetResourceString("TemplateCategory_TS_Label"); } }
//Resources:FSResources:TemplateCategory_Urgency_Default

		public static string TemplateCategory_Urgency_Default { get { return GetResourceString("TemplateCategory_Urgency_Default"); } }
//Resources:FSResources:TemplateCategory_Urgency_Label

		public static string TemplateCategory_Urgency_Label { get { return GetResourceString("TemplateCategory_Urgency_Label"); } }
//Resources:FSResources:TemplateCategory_Urgency_Show

		public static string TemplateCategory_Urgency_Show { get { return GetResourceString("TemplateCategory_Urgency_Show"); } }
//Resources:FSResources:TemplateInstruction_Description

		public static string TemplateInstruction_Description { get { return GetResourceString("TemplateInstruction_Description"); } }
//Resources:FSResources:TemplateInstruction_Help

		public static string TemplateInstruction_Help { get { return GetResourceString("TemplateInstruction_Help"); } }
//Resources:FSResources:TemplateInstruction_Hints

		public static string TemplateInstruction_Hints { get { return GetResourceString("TemplateInstruction_Hints"); } }
//Resources:FSResources:TemplateInstruction_Instruction

		public static string TemplateInstruction_Instruction { get { return GetResourceString("TemplateInstruction_Instruction"); } }
//Resources:FSResources:TemplateInstruction_Notes

		public static string TemplateInstruction_Notes { get { return GetResourceString("TemplateInstruction_Notes"); } }
//Resources:FSResources:TemplateInstruction_StepId

		public static string TemplateInstruction_StepId { get { return GetResourceString("TemplateInstruction_StepId"); } }
//Resources:FSResources:TemplateInstruction_Title

		public static string TemplateInstruction_Title { get { return GetResourceString("TemplateInstruction_Title"); } }
//Resources:FSResources:TroubleShootingStep_Description

		public static string TroubleShootingStep_Description { get { return GetResourceString("TroubleShootingStep_Description"); } }
//Resources:FSResources:TroubleshootingStep_Equipment

		public static string TroubleshootingStep_Equipment { get { return GetResourceString("TroubleshootingStep_Equipment"); } }
//Resources:FSResources:TroubleShootingStep_Help

		public static string TroubleShootingStep_Help { get { return GetResourceString("TroubleShootingStep_Help"); } }
//Resources:FSResources:TroubleshootingStep_Instructions

		public static string TroubleshootingStep_Instructions { get { return GetResourceString("TroubleshootingStep_Instructions"); } }
//Resources:FSResources:TroubleshootingStep_Notes

		public static string TroubleshootingStep_Notes { get { return GetResourceString("TroubleshootingStep_Notes"); } }
//Resources:FSResources:TroubleshootingStep_Problem

		public static string TroubleshootingStep_Problem { get { return GetResourceString("TroubleshootingStep_Problem"); } }
//Resources:FSResources:TroubleshootingStep_Resources

		public static string TroubleshootingStep_Resources { get { return GetResourceString("TroubleshootingStep_Resources"); } }
//Resources:FSResources:TroubleshootingStep_StepId

		public static string TroubleshootingStep_StepId { get { return GetResourceString("TroubleshootingStep_StepId"); } }
//Resources:FSResources:TroubleShootingStep_Title

		public static string TroubleShootingStep_Title { get { return GetResourceString("TroubleShootingStep_Title"); } }
//Resources:FSResources:TroubleshootingSteps_ExpectedOutcome

		public static string TroubleshootingSteps_ExpectedOutcome { get { return GetResourceString("TroubleshootingSteps_ExpectedOutcome"); } }
//Resources:FSResources:TS_ExpectedOutcome_Default

		public static string TS_ExpectedOutcome_Default { get { return GetResourceString("TS_ExpectedOutcome_Default"); } }
//Resources:FSResources:TS_ExpectedOutcome_Help

		public static string TS_ExpectedOutcome_Help { get { return GetResourceString("TS_ExpectedOutcome_Help"); } }
//Resources:FSResources:TS_ExpectedOutcome_Label

		public static string TS_ExpectedOutcome_Label { get { return GetResourceString("TS_ExpectedOutcome_Label"); } }
//Resources:FSResources:TS_ExpectedOutcome_Show

		public static string TS_ExpectedOutcome_Show { get { return GetResourceString("TS_ExpectedOutcome_Show"); } }
//Resources:FSResources:TS_Instructions_Default

		public static string TS_Instructions_Default { get { return GetResourceString("TS_Instructions_Default"); } }
//Resources:FSResources:TS_Instructions_Help

		public static string TS_Instructions_Help { get { return GetResourceString("TS_Instructions_Help"); } }
//Resources:FSResources:TS_Instructions_Label

		public static string TS_Instructions_Label { get { return GetResourceString("TS_Instructions_Label"); } }
//Resources:FSResources:TS_Instructions_Show

		public static string TS_Instructions_Show { get { return GetResourceString("TS_Instructions_Show"); } }
//Resources:FSResources:TS_Name_Default

		public static string TS_Name_Default { get { return GetResourceString("TS_Name_Default"); } }
//Resources:FSResources:TS_Name_Label

		public static string TS_Name_Label { get { return GetResourceString("TS_Name_Label"); } }
//Resources:FSResources:TS_Name_Show

		public static string TS_Name_Show { get { return GetResourceString("TS_Name_Show"); } }
//Resources:FSResources:TS_Notes_Default

		public static string TS_Notes_Default { get { return GetResourceString("TS_Notes_Default"); } }
//Resources:FSResources:TS_Notes_Label

		public static string TS_Notes_Label { get { return GetResourceString("TS_Notes_Label"); } }
//Resources:FSResources:TS_Notes_Show

		public static string TS_Notes_Show { get { return GetResourceString("TS_Notes_Show"); } }
//Resources:FSResources:TS_Problem_Default

		public static string TS_Problem_Default { get { return GetResourceString("TS_Problem_Default"); } }
//Resources:FSResources:TS_Problem_Help

		public static string TS_Problem_Help { get { return GetResourceString("TS_Problem_Help"); } }
//Resources:FSResources:TS_Problem_Label

		public static string TS_Problem_Label { get { return GetResourceString("TS_Problem_Label"); } }
//Resources:FSResources:TS_Problem_Show

		public static string TS_Problem_Show { get { return GetResourceString("TS_Problem_Show"); } }
//Resources:FSResources:TS_Resources_Default

		public static string TS_Resources_Default { get { return GetResourceString("TS_Resources_Default"); } }
//Resources:FSResources:TS_Resources_Help

		public static string TS_Resources_Help { get { return GetResourceString("TS_Resources_Help"); } }
//Resources:FSResources:TS_Resources_Show

		public static string TS_Resources_Show { get { return GetResourceString("TS_Resources_Show"); } }
//Resources:FSResources:TS_Resourcess_Label

		public static string TS_Resourcess_Label { get { return GetResourceString("TS_Resourcess_Label"); } }
//Resources:FSResources:TS_StepId_Default

		public static string TS_StepId_Default { get { return GetResourceString("TS_StepId_Default"); } }
//Resources:FSResources:TS_StepId_Label

		public static string TS_StepId_Label { get { return GetResourceString("TS_StepId_Label"); } }
//Resources:FSResources:TS_StepId_Show

		public static string TS_StepId_Show { get { return GetResourceString("TS_StepId_Show"); } }
//Resources:FSResources:TS_Tools_Default

		public static string TS_Tools_Default { get { return GetResourceString("TS_Tools_Default"); } }
//Resources:FSResources:TS_Tools_Help

		public static string TS_Tools_Help { get { return GetResourceString("TS_Tools_Help"); } }
//Resources:FSResources:TS_Tools_Label

		public static string TS_Tools_Label { get { return GetResourceString("TS_Tools_Label"); } }
//Resources:FSResources:TS_Tools_Show

		public static string TS_Tools_Show { get { return GetResourceString("TS_Tools_Show"); } }

		public static class Names
		{
			public const string Common_CreatedBy = "Common_CreatedBy";
			public const string Common_CreationDate = "Common_CreationDate";
			public const string Common_Description = "Common_Description";
			public const string Common_IsPublic = "Common_IsPublic";
			public const string Common_IsRequired = "Common_IsRequired";
			public const string Common_IsValid = "Common_IsValid";
			public const string Common_Key = "Common_Key";
			public const string Common_Key_Help = "Common_Key_Help";
			public const string Common_Key_Validation = "Common_Key_Validation";
			public const string Common_LastUpdated = "Common_LastUpdated";
			public const string Common_LastUpdatedBy = "Common_LastUpdatedBy";
			public const string Common_Name = "Common_Name";
			public const string Common_Note = "Common_Note";
			public const string Common_Notes = "Common_Notes";
			public const string Common_PageNumberOne = "Common_PageNumberOne";
			public const string Common_PartNumber = "Common_PartNumber";
			public const string Common_Resources = "Common_Resources";
			public const string Common_UniqueId = "Common_UniqueId";
			public const string Common_ValidationErrors = "Common_ValidationErrors";
			public const string Instructions_Hints_Default = "Instructions_Hints_Default";
			public const string Instructions_Hints_Help = "Instructions_Hints_Help";
			public const string Instructions_Hints_Label = "Instructions_Hints_Label";
			public const string Instructions_Hints_Show = "Instructions_Hints_Show";
			public const string Instructions_Instructions_Default = "Instructions_Instructions_Default";
			public const string Instructions_Instructions_Help = "Instructions_Instructions_Help";
			public const string Instructions_Instructions_Label = "Instructions_Instructions_Label";
			public const string Instructions_Instructions_Show = "Instructions_Instructions_Show";
			public const string Instructions_Name_Default = "Instructions_Name_Default";
			public const string Instructions_Name_Label = "Instructions_Name_Label";
			public const string Instructions_Name_Show = "Instructions_Name_Show";
			public const string Instructions_Notes_Default = "Instructions_Notes_Default";
			public const string Instructions_Notes_Label = "Instructions_Notes_Label";
			public const string Instructions_Notes_Show = "Instructions_Notes_Show";
			public const string Instructions_Resource_Help = "Instructions_Resource_Help";
			public const string Instructions_Resources_Default = "Instructions_Resources_Default";
			public const string Instructions_Resources_Label = "Instructions_Resources_Label";
			public const string Instructions_Resources_Show = "Instructions_Resources_Show";
			public const string Instructions_StepId_Default = "Instructions_StepId_Default";
			public const string Instructions_StepId_Label = "Instructions_StepId_Label";
			public const string Instructions_StepId_Show = "Instructions_StepId_Show";
			public const string Instructions_Tools_Default = "Instructions_Tools_Default";
			public const string Instructions_Tools_Help = "Instructions_Tools_Help";
			public const string Instructions_Tools_Label = "Instructions_Tools_Label";
			public const string Instructions_Tools_Show = "Instructions_Tools_Show";
			public const string PartKit_Description = "PartKit_Description";
			public const string PartKit_Help = "PartKit_Help";
			public const string PartKit_KitNumber = "PartKit_KitNumber";
			public const string PartKit_Name = "PartKit_Name";
			public const string PartKits_Title = "PartKits_Title";
			public const string PartsKit = "PartsKit";
			public const string PartsKit_Parts = "PartsKit_Parts";
			public const string ServiceBoard_Abbreviation = "ServiceBoard_Abbreviation";
			public const string ServiceBoard_Abbreviation_Help = "ServiceBoard_Abbreviation_Help";
			public const string ServiceBoard_BoardOwner = "ServiceBoard_BoardOwner";
			public const string ServiceBoard_BoardOwner_Help = "ServiceBoard_BoardOwner_Help";
			public const string ServiceBoard_BoardOwner_Select = "ServiceBoard_BoardOwner_Select";
			public const string ServiceBoard_Description = "ServiceBoard_Description";
			public const string ServiceBoard_Help = "ServiceBoard_Help";
			public const string ServiceBoard_SequenceNumber = "ServiceBoard_SequenceNumber";
			public const string ServiceBoard_SequenceNumber_Help = "ServiceBoard_SequenceNumber_Help";
			public const string ServiceBoard_Title = "ServiceBoard_Title";
			public const string ServiceBoards_Title = "ServiceBoards_Title";
			public const string ServiceTicekt_SilenceNotifications = "ServiceTicekt_SilenceNotifications";
			public const string ServiceTicket_Address = "ServiceTicket_Address";
			public const string ServiceTicket_AssignedTo = "ServiceTicket_AssignedTo";
			public const string ServiceTicket_ClosedBy = "ServiceTicket_ClosedBy";
			public const string ServiceTicket_ClosedDate = "ServiceTicket_ClosedDate";
			public const string ServiceTicket_Company = "ServiceTicket_Company";
			public const string ServiceTicket_Description = "ServiceTicket_Description";
			public const string ServiceTicket_Details = "ServiceTicket_Details";
			public const string ServiceTicket_Device = "ServiceTicket_Device";
			public const string ServiceTicket_DeviceRepo = "ServiceTicket_DeviceRepo";
			public const string ServiceTicket_DueDate = "ServiceTicket_DueDate";
			public const string ServiceTicket_Help = "ServiceTicket_Help";
			public const string ServiceTicket_History = "ServiceTicket_History";
			public const string ServiceTicket_IsClosed = "ServiceTicket_IsClosed";
			public const string ServiceTicket_IsViewed = "ServiceTicket_IsViewed";
			public const string ServiceTicket_LastNotification = "ServiceTicket_LastNotification";
			public const string ServiceTicket_LastNotifiedUser = "ServiceTicket_LastNotifiedUser";
			public const string ServiceTicket_NextNotification = "ServiceTicket_NextNotification";
			public const string ServiceTicket_Notes = "ServiceTicket_Notes";
			public const string ServiceTicket_ServiceBoard = "ServiceTicket_ServiceBoard";
			public const string ServiceTicket_Status = "ServiceTicket_Status";
			public const string ServiceTicket_StatusDate = "ServiceTicket_StatusDate";
			public const string ServiceTicket_StatusDueDate = "ServiceTicket_StatusDueDate";
			public const string ServiceTicket_StatusDueDate_Help = "ServiceTicket_StatusDueDate_Help";
			public const string ServiceTicket_Subject = "ServiceTicket_Subject";
			public const string ServiceTicket_TicketId = "ServiceTicket_TicketId";
			public const string ServiceTicket_Title = "ServiceTicket_Title";
			public const string ServiceTicket_ViewedBy = "ServiceTicket_ViewedBy";
			public const string ServiceTicket_ViewedDate = "ServiceTicket_ViewedDate";
			public const string ServiceTicketNote_AddedBy = "ServiceTicketNote_AddedBy";
			public const string ServiceTicketNote_DateStamp = "ServiceTicketNote_DateStamp";
			public const string ServiceTicketNote_Description = "ServiceTicketNote_Description";
			public const string ServiceTicketNote_Help = "ServiceTicketNote_Help";
			public const string ServiceTicketNote_Note = "ServiceTicketNote_Note";
			public const string ServiceTicketNote_Title = "ServiceTicketNote_Title";
			public const string ServiceTickets_Title = "ServiceTickets_Title";
			public const string ServiceTicketStatusHistory_AddedBy = "ServiceTicketStatusHistory_AddedBy";
			public const string ServiceTicketStatusHistory_DateStamp = "ServiceTicketStatusHistory_DateStamp";
			public const string ServiceTicketStatusHistory_Description = "ServiceTicketStatusHistory_Description";
			public const string ServiceTicketStatusHistory_Help = "ServiceTicketStatusHistory_Help";
			public const string ServiceTicketStatusHistory_Notes = "ServiceTicketStatusHistory_Notes";
			public const string ServiceTicketStatusHistory_Status = "ServiceTicketStatusHistory_Status";
			public const string ServiceTicketStatusHistory_StatusDueDate = "ServiceTicketStatusHistory_StatusDueDate";
			public const string ServiceTicketStatusHistory_Title = "ServiceTicketStatusHistory_Title";
			public const string ServiceTicketTemplate_Category = "ServiceTicketTemplate_Category";
			public const string ServiceTicketTemplate_Category_Help = "ServiceTicketTemplate_Category_Help";
			public const string ServiceTicketTemplate_Categroy_WaterMark = "ServiceTicketTemplate_Categroy_WaterMark";
			public const string ServiceTicketTemplate_CostEstimate = "ServiceTicketTemplate_CostEstimate";
			public const string ServiceTicketTemplate_DefaultAssigned = "ServiceTicketTemplate_DefaultAssigned";
			public const string ServiceTicketTemplate_DefaultContact = "ServiceTicketTemplate_DefaultContact";
			public const string ServiceTicketTemplate_DefaultContact_Help = "ServiceTicketTemplate_DefaultContact_Help";
			public const string ServiceTicketTemplate_DefaultContact_Select = "ServiceTicketTemplate_DefaultContact_Select";
			public const string ServiceTicketTemplate_DefaultDescription = "ServiceTicketTemplate_DefaultDescription";
			public const string ServiceTicketTemplate_DefaultDescription_Help = "ServiceTicketTemplate_DefaultDescription_Help";
			public const string ServiceTicketTemplate_DefaultSubject = "ServiceTicketTemplate_DefaultSubject";
			public const string ServiceTicketTemplate_DefaultSubject_Help = "ServiceTicketTemplate_DefaultSubject_Help";
			public const string ServiceTicketTemplate_Description = "ServiceTicketTemplate_Description";
			public const string ServiceTicketTemplate_DeviceConfig = "ServiceTicketTemplate_DeviceConfig";
			public const string ServiceTicketTemplate_DeviceConfig_Help = "ServiceTicketTemplate_DeviceConfig_Help";
			public const string ServiceTicketTemplate_DeviceConfig_Select = "ServiceTicketTemplate_DeviceConfig_Select";
			public const string ServiceTicketTemplate_DeviceType = "ServiceTicketTemplate_DeviceType";
			public const string ServiceTicketTemplate_DeviceType_Help = "ServiceTicketTemplate_DeviceType_Help";
			public const string ServiceTicketTemplate_DeviceType_Select = "ServiceTicketTemplate_DeviceType_Select";
			public const string ServiceTicketTemplate_Help = "ServiceTicketTemplate_Help";
			public const string ServiceTicketTemplate_HoursEstimate = "ServiceTicketTemplate_HoursEstimate";
			public const string ServiceTicketTemplate_Instructions = "ServiceTicketTemplate_Instructions";
			public const string ServiceTicketTemplate_OpenReminderNotification_Quantity = "ServiceTicketTemplate_OpenReminderNotification_Quantity";
			public const string ServiceTicketTemplate_OpenReminderNotification_TimeSpan = "ServiceTicketTemplate_OpenReminderNotification_TimeSpan";
			public const string ServiceTicketTemplate_OpenReminderNotification_TimeSpan_Help = "ServiceTicketTemplate_OpenReminderNotification_TimeSpan_Help";
			public const string ServiceTicketTemplate_PartsKits = "ServiceTicketTemplate_PartsKits";
			public const string ServiceTicketTemplate_ServiceParts = "ServiceTicketTemplate_ServiceParts";
			public const string ServiceTicketTemplate_Skill = "ServiceTicketTemplate_Skill";
			public const string ServiceTicketTemplate_Skill_High = "ServiceTicketTemplate_Skill_High";
			public const string ServiceTicketTemplate_Skill_Low = "ServiceTicketTemplate_Skill_Low";
			public const string ServiceTicketTemplate_Skill_Medium = "ServiceTicketTemplate_Skill_Medium";
			public const string ServiceTicketTemplate_Skill_Select = "ServiceTicketTemplate_Skill_Select";
			public const string ServiceTicketTemplate_StatusType = "ServiceTicketTemplate_StatusType";
			public const string ServiceTicketTemplate_StatusType_Help = "ServiceTicketTemplate_StatusType_Help";
			public const string ServiceTicketTemplate_StatusType_Select = "ServiceTicketTemplate_StatusType_Select";
			public const string ServiceTicketTemplate_Title = "ServiceTicketTemplate_Title";
			public const string ServiceTicketTemplate_Tools = "ServiceTicketTemplate_Tools";
			public const string ServiceTicketTemplate_TroubleshootingSteps = "ServiceTicketTemplate_TroubleshootingSteps";
			public const string ServiceTicketTemplate_Urgency = "ServiceTicketTemplate_Urgency";
			public const string ServiceTicketTemplate_Urgency_CriticalSafety = "ServiceTicketTemplate_Urgency_CriticalSafety";
			public const string ServiceTicketTemplate_Urgency_Important = "ServiceTicketTemplate_Urgency_Important";
			public const string ServiceTicketTemplate_Urgency_Low = "ServiceTicketTemplate_Urgency_Low";
			public const string ServiceTicketTemplate_Urgency_Normal = "ServiceTicketTemplate_Urgency_Normal";
			public const string ServiceTicketTemplate_Urgency_Select = "ServiceTicketTemplate_Urgency_Select";
			public const string ServiceTicketTemplateDefault_Assigned_Help = "ServiceTicketTemplateDefault_Assigned_Help";
			public const string ServiceTicketTemplates_Title = "ServiceTicketTemplates_Title";
			public const string SP_Name_Show = "SP_Name_Show";
			public const string Status_Code = "Status_Code";
			public const string Status_Code_Help = "Status_Code_Help";
			public const string Status_Description = "Status_Description";
			public const string Status_Help = "Status_Help";
			public const string Status_IsClosed = "Status_IsClosed";
			public const string Status_IsClosed_Help = "Status_IsClosed_Help";
			public const string Status_IsDefault = "Status_IsDefault";
			public const string Status_IsDefault_Help = "Status_IsDefault_Help";
			public const string Status_Name = "Status_Name";
			public const string Status_Options = "Status_Options";
			public const string Status_TimeAllowedInStatus = "Status_TimeAllowedInStatus";
			public const string Status_TimeAllowedInStatus_Help = "Status_TimeAllowedInStatus_Help";
			public const string Status_TimeAllowedInStatus_Quantity = "Status_TimeAllowedInStatus_Quantity";
			public const string StatusItems_Description = "StatusItems_Description";
			public const string StatusItems_Name = "StatusItems_Name";
			public const string Template_Categories = "Template_Categories";
			public const string Template_Category = "Template_Category";
			public const string Template_Category_Help = "Template_Category_Help";
			public const string Template_Cateogry_Description = "Template_Cateogry_Description";
			public const string Template_Exclusive = "Template_Exclusive";
			public const string Template_Exclusive_Help = "Template_Exclusive_Help";
			public const string Template_Time_ToComplete_Days = "Template_Time_ToComplete_Days";
			public const string Template_Time_ToComplete_Hours = "Template_Time_ToComplete_Hours";
			public const string Template_Time_ToComplete_Minutes = "Template_Time_ToComplete_Minutes";
			public const string Template_Time_ToComplete_NotApplicable = "Template_Time_ToComplete_NotApplicable";
			public const string Template_Time_ToComplete_Quantity = "Template_Time_ToComplete_Quantity";
			public const string Template_Time_ToComplete_Quantity_Help = "Template_Time_ToComplete_Quantity_Help";
			public const string Template_Time_ToComplete_Select = "Template_Time_ToComplete_Select";
			public const string Template_Time_ToComplete_TimeSpan = "Template_Time_ToComplete_TimeSpan";
			public const string Template_Time_ToComplete_TimeSpan_Help = "Template_Time_ToComplete_TimeSpan_Help";
			public const string TemplateCategory_CostEstimate_Default = "TemplateCategory_CostEstimate_Default";
			public const string TemplateCategory_CostEstimate_Help = "TemplateCategory_CostEstimate_Help";
			public const string TemplateCategory_CostEstimate_Label = "TemplateCategory_CostEstimate_Label";
			public const string TemplateCategory_CostEstimate_Show = "TemplateCategory_CostEstimate_Show";
			public const string TemplateCategory_DueDate_Default = "TemplateCategory_DueDate_Default";
			public const string TemplateCategory_DueDate_Label = "TemplateCategory_DueDate_Label";
			public const string TemplateCategory_DueDate_label_Help = "TemplateCategory_DueDate_label_Help";
			public const string TemplateCategory_HoursEstimate_Default = "TemplateCategory_HoursEstimate_Default";
			public const string TemplateCategory_HoursEstimate_Help = "TemplateCategory_HoursEstimate_Help";
			public const string TemplateCategory_HoursEstimate_Label = "TemplateCategory_HoursEstimate_Label";
			public const string TemplateCategory_HoursEstimate_Show = "TemplateCategory_HoursEstimate_Show";
			public const string TemplateCategory_Instructions_Configuration = "TemplateCategory_Instructions_Configuration";
			public const string TemplateCategory_Instructions_Default = "TemplateCategory_Instructions_Default";
			public const string TemplateCategory_Instructions_Label = "TemplateCategory_Instructions_Label";
			public const string TemplateCategory_Instructions_label_Help = "TemplateCategory_Instructions_label_Help";
			public const string TemplateCategory_IsClosed_Default = "TemplateCategory_IsClosed_Default";
			public const string TemplateCategory_IsClosed_Label = "TemplateCategory_IsClosed_Label";
			public const string TemplateCategory_IsViewed_Default = "TemplateCategory_IsViewed_Default";
			public const string TemplateCategory_IsViewed_Label = "TemplateCategory_IsViewed_Label";
			public const string TemplateCategory_IsViewed_Show = "TemplateCategory_IsViewed_Show";
			public const string TemplateCategory_PartsKit_Default = "TemplateCategory_PartsKit_Default";
			public const string TemplateCategory_PartsKit_Help = "TemplateCategory_PartsKit_Help";
			public const string TemplateCategory_PartsKit_Label = "TemplateCategory_PartsKit_Label";
			public const string TemplateCategory_PartsKit_Show = "TemplateCategory_PartsKit_Show";
			public const string TemplateCategory_PrimaryContact_Default = "TemplateCategory_PrimaryContact_Default";
			public const string TemplateCategory_PrimaryContactLabel = "TemplateCategory_PrimaryContactLabel";
			public const string TemplateCategory_PrimaryContactLabel_Help = "TemplateCategory_PrimaryContactLabel_Help";
			public const string TemplateCategory_Resources_Default = "TemplateCategory_Resources_Default";
			public const string TemplateCategory_Resources_Label = "TemplateCategory_Resources_Label";
			public const string TemplateCategory_ServiceBoard_Default = "TemplateCategory_ServiceBoard_Default";
			public const string TemplateCategory_ServiceBoard_Label = "TemplateCategory_ServiceBoard_Label";
			public const string TemplateCategory_ServiceParts_Default = "TemplateCategory_ServiceParts_Default";
			public const string TemplateCategory_ServiceParts_Help = "TemplateCategory_ServiceParts_Help";
			public const string TemplateCategory_ServiceParts_Label = "TemplateCategory_ServiceParts_Label";
			public const string TemplateCategory_ServiceParts_Show = "TemplateCategory_ServiceParts_Show";
			public const string TemplateCategory_Show_Resource = "TemplateCategory_Show_Resource";
			public const string TemplateCategory_Show_Resource_Help = "TemplateCategory_Show_Resource_Help";
			public const string TemplateCategory_Show_Tools = "TemplateCategory_Show_Tools";
			public const string TemplateCategory_Show_Tools_Help = "TemplateCategory_Show_Tools_Help";
			public const string TemplateCategory_Show_TS = "TemplateCategory_Show_TS";
			public const string TemplateCategory_Show_TS_Help = "TemplateCategory_Show_TS_Help";
			public const string TemplateCategory_ShowDueDate = "TemplateCategory_ShowDueDate";
			public const string TemplateCategory_ShowInstructions = "TemplateCategory_ShowInstructions";
			public const string TemplateCategory_ShowInstructions_Help = "TemplateCategory_ShowInstructions_Help";
			public const string TemplateCategory_ShowStatusDate = "TemplateCategory_ShowStatusDate";
			public const string TemplateCategory_ShowStatusDueDate = "TemplateCategory_ShowStatusDueDate";
			public const string TemplateCategory_ShowTools_Label = "TemplateCategory_ShowTools_Label";
			public const string TemplateCategory_SkillLevel_Default = "TemplateCategory_SkillLevel_Default";
			public const string TemplateCategory_SkillLevel_Label = "TemplateCategory_SkillLevel_Label";
			public const string TemplateCategory_SkillLevel_Show = "TemplateCategory_SkillLevel_Show";
			public const string TemplateCategory_Status_Default = "TemplateCategory_Status_Default";
			public const string TemplateCategory_Status_Help = "TemplateCategory_Status_Help";
			public const string TemplateCategory_Status_Label = "TemplateCategory_Status_Label";
			public const string TemplateCategory_StatusDate_Default = "TemplateCategory_StatusDate_Default";
			public const string TemplateCategory_StatusDate_Label = "TemplateCategory_StatusDate_Label";
			public const string TemplateCategory_StatusDate_label_Help = "TemplateCategory_StatusDate_label_Help";
			public const string TemplateCategory_StatusDueDate_Default = "TemplateCategory_StatusDueDate_Default";
			public const string TemplateCategory_StatusDueDate_Label = "TemplateCategory_StatusDueDate_Label";
			public const string TemplateCategory_StatusDueDate_label_Help = "TemplateCategory_StatusDueDate_label_Help";
			public const string TemplateCategory_Subject_Default = "TemplateCategory_Subject_Default";
			public const string TemplateCategory_Subject_Help = "TemplateCategory_Subject_Help";
			public const string TemplateCategory_Subject_Label = "TemplateCategory_Subject_Label";
			public const string TemplateCategory_TicketLabel = "TemplateCategory_TicketLabel";
			public const string TemplateCategory_TicketLabel_Default = "TemplateCategory_TicketLabel_Default";
			public const string TemplateCategory_TicketLabel_Help = "TemplateCategory_TicketLabel_Help";
			public const string TemplateCategory_Tools_Default = "TemplateCategory_Tools_Default";
			public const string TemplateCategory_TroubleshootingSteps_Configuration = "TemplateCategory_TroubleshootingSteps_Configuration";
			public const string TemplateCategory_TroubleshootingSteps_Default = "TemplateCategory_TroubleshootingSteps_Default";
			public const string TemplateCategory_TS_Label = "TemplateCategory_TS_Label";
			public const string TemplateCategory_Urgency_Default = "TemplateCategory_Urgency_Default";
			public const string TemplateCategory_Urgency_Label = "TemplateCategory_Urgency_Label";
			public const string TemplateCategory_Urgency_Show = "TemplateCategory_Urgency_Show";
			public const string TemplateInstruction_Description = "TemplateInstruction_Description";
			public const string TemplateInstruction_Help = "TemplateInstruction_Help";
			public const string TemplateInstruction_Hints = "TemplateInstruction_Hints";
			public const string TemplateInstruction_Instruction = "TemplateInstruction_Instruction";
			public const string TemplateInstruction_Notes = "TemplateInstruction_Notes";
			public const string TemplateInstruction_StepId = "TemplateInstruction_StepId";
			public const string TemplateInstruction_Title = "TemplateInstruction_Title";
			public const string TroubleShootingStep_Description = "TroubleShootingStep_Description";
			public const string TroubleshootingStep_Equipment = "TroubleshootingStep_Equipment";
			public const string TroubleShootingStep_Help = "TroubleShootingStep_Help";
			public const string TroubleshootingStep_Instructions = "TroubleshootingStep_Instructions";
			public const string TroubleshootingStep_Notes = "TroubleshootingStep_Notes";
			public const string TroubleshootingStep_Problem = "TroubleshootingStep_Problem";
			public const string TroubleshootingStep_Resources = "TroubleshootingStep_Resources";
			public const string TroubleshootingStep_StepId = "TroubleshootingStep_StepId";
			public const string TroubleShootingStep_Title = "TroubleShootingStep_Title";
			public const string TroubleshootingSteps_ExpectedOutcome = "TroubleshootingSteps_ExpectedOutcome";
			public const string TS_ExpectedOutcome_Default = "TS_ExpectedOutcome_Default";
			public const string TS_ExpectedOutcome_Help = "TS_ExpectedOutcome_Help";
			public const string TS_ExpectedOutcome_Label = "TS_ExpectedOutcome_Label";
			public const string TS_ExpectedOutcome_Show = "TS_ExpectedOutcome_Show";
			public const string TS_Instructions_Default = "TS_Instructions_Default";
			public const string TS_Instructions_Help = "TS_Instructions_Help";
			public const string TS_Instructions_Label = "TS_Instructions_Label";
			public const string TS_Instructions_Show = "TS_Instructions_Show";
			public const string TS_Name_Default = "TS_Name_Default";
			public const string TS_Name_Label = "TS_Name_Label";
			public const string TS_Name_Show = "TS_Name_Show";
			public const string TS_Notes_Default = "TS_Notes_Default";
			public const string TS_Notes_Label = "TS_Notes_Label";
			public const string TS_Notes_Show = "TS_Notes_Show";
			public const string TS_Problem_Default = "TS_Problem_Default";
			public const string TS_Problem_Help = "TS_Problem_Help";
			public const string TS_Problem_Label = "TS_Problem_Label";
			public const string TS_Problem_Show = "TS_Problem_Show";
			public const string TS_Resources_Default = "TS_Resources_Default";
			public const string TS_Resources_Help = "TS_Resources_Help";
			public const string TS_Resources_Show = "TS_Resources_Show";
			public const string TS_Resourcess_Label = "TS_Resourcess_Label";
			public const string TS_StepId_Default = "TS_StepId_Default";
			public const string TS_StepId_Label = "TS_StepId_Label";
			public const string TS_StepId_Show = "TS_StepId_Show";
			public const string TS_Tools_Default = "TS_Tools_Default";
			public const string TS_Tools_Help = "TS_Tools_Help";
			public const string TS_Tools_Label = "TS_Tools_Label";
			public const string TS_Tools_Show = "TS_Tools_Show";
		}
	}
}

