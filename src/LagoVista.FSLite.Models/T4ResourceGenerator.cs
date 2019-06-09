/*6/9/2019 12:26:25*/
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
//Resources:FSResources:Common_UniqueId

		public static string Common_UniqueId { get { return GetResourceString("Common_UniqueId"); } }
//Resources:FSResources:Common_ValidationErrors

		public static string Common_ValidationErrors { get { return GetResourceString("Common_ValidationErrors"); } }
//Resources:FSResources:ServiceTicket_Address

		public static string ServiceTicket_Address { get { return GetResourceString("ServiceTicket_Address"); } }
//Resources:FSResources:ServiceTicket_AssignedTo

		public static string ServiceTicket_AssignedTo { get { return GetResourceString("ServiceTicket_AssignedTo"); } }
//Resources:FSResources:ServiceTicket_ClosedBy

		public static string ServiceTicket_ClosedBy { get { return GetResourceString("ServiceTicket_ClosedBy"); } }
//Resources:FSResources:ServiceTicket_Company

		public static string ServiceTicket_Company { get { return GetResourceString("ServiceTicket_Company"); } }
//Resources:FSResources:ServiceTicket_Description

		public static string ServiceTicket_Description { get { return GetResourceString("ServiceTicket_Description"); } }
//Resources:FSResources:ServiceTicket_Details

		public static string ServiceTicket_Details { get { return GetResourceString("ServiceTicket_Details"); } }
//Resources:FSResources:ServiceTicket_Device

		public static string ServiceTicket_Device { get { return GetResourceString("ServiceTicket_Device"); } }
//Resources:FSResources:ServiceTicket_DueDate

		public static string ServiceTicket_DueDate { get { return GetResourceString("ServiceTicket_DueDate"); } }
//Resources:FSResources:ServiceTicket_Help

		public static string ServiceTicket_Help { get { return GetResourceString("ServiceTicket_Help"); } }
//Resources:FSResources:ServiceTicket_History

		public static string ServiceTicket_History { get { return GetResourceString("ServiceTicket_History"); } }
//Resources:FSResources:ServiceTicket_IsClosed

		public static string ServiceTicket_IsClosed { get { return GetResourceString("ServiceTicket_IsClosed"); } }
//Resources:FSResources:ServiceTicket_Notes

		public static string ServiceTicket_Notes { get { return GetResourceString("ServiceTicket_Notes"); } }
//Resources:FSResources:ServiceTicket_Status

		public static string ServiceTicket_Status { get { return GetResourceString("ServiceTicket_Status"); } }
//Resources:FSResources:ServiceTicket_StatusDate

		public static string ServiceTicket_StatusDate { get { return GetResourceString("ServiceTicket_StatusDate"); } }
//Resources:FSResources:ServiceTicket_Subject

		public static string ServiceTicket_Subject { get { return GetResourceString("ServiceTicket_Subject"); } }
//Resources:FSResources:ServiceTicket_TicketId

		public static string ServiceTicket_TicketId { get { return GetResourceString("ServiceTicket_TicketId"); } }
//Resources:FSResources:ServiceTicket_Title

		public static string ServiceTicket_Title { get { return GetResourceString("ServiceTicket_Title"); } }
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
//Resources:FSResources:ServiceTicketStatusHistory_Title

		public static string ServiceTicketStatusHistory_Title { get { return GetResourceString("ServiceTicketStatusHistory_Title"); } }
//Resources:FSResources:ServiceTicketTemplate_AssociatedEquipment

		public static string ServiceTicketTemplate_AssociatedEquipment { get { return GetResourceString("ServiceTicketTemplate_AssociatedEquipment"); } }
//Resources:FSResources:ServiceTicketTemplate_CostEstimate

		public static string ServiceTicketTemplate_CostEstimate { get { return GetResourceString("ServiceTicketTemplate_CostEstimate"); } }
//Resources:FSResources:ServiceTicketTemplate_Description

		public static string ServiceTicketTemplate_Description { get { return GetResourceString("ServiceTicketTemplate_Description"); } }
//Resources:FSResources:ServiceTicketTemplate_Help

		public static string ServiceTicketTemplate_Help { get { return GetResourceString("ServiceTicketTemplate_Help"); } }
//Resources:FSResources:ServiceTicketTemplate_HoursEstimate

		public static string ServiceTicketTemplate_HoursEstimate { get { return GetResourceString("ServiceTicketTemplate_HoursEstimate"); } }
//Resources:FSResources:ServiceTicketTemplate_Instructions

		public static string ServiceTicketTemplate_Instructions { get { return GetResourceString("ServiceTicketTemplate_Instructions"); } }
//Resources:FSResources:ServiceTicketTemplate_RequiredParts

		public static string ServiceTicketTemplate_RequiredParts { get { return GetResourceString("ServiceTicketTemplate_RequiredParts"); } }
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
//Resources:FSResources:ServiceTicketTemplate_Title

		public static string ServiceTicketTemplate_Title { get { return GetResourceString("ServiceTicketTemplate_Title"); } }
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
			public const string Common_UniqueId = "Common_UniqueId";
			public const string Common_ValidationErrors = "Common_ValidationErrors";
			public const string ServiceTicket_Address = "ServiceTicket_Address";
			public const string ServiceTicket_AssignedTo = "ServiceTicket_AssignedTo";
			public const string ServiceTicket_ClosedBy = "ServiceTicket_ClosedBy";
			public const string ServiceTicket_Company = "ServiceTicket_Company";
			public const string ServiceTicket_Description = "ServiceTicket_Description";
			public const string ServiceTicket_Details = "ServiceTicket_Details";
			public const string ServiceTicket_Device = "ServiceTicket_Device";
			public const string ServiceTicket_DueDate = "ServiceTicket_DueDate";
			public const string ServiceTicket_Help = "ServiceTicket_Help";
			public const string ServiceTicket_History = "ServiceTicket_History";
			public const string ServiceTicket_IsClosed = "ServiceTicket_IsClosed";
			public const string ServiceTicket_Notes = "ServiceTicket_Notes";
			public const string ServiceTicket_Status = "ServiceTicket_Status";
			public const string ServiceTicket_StatusDate = "ServiceTicket_StatusDate";
			public const string ServiceTicket_Subject = "ServiceTicket_Subject";
			public const string ServiceTicket_TicketId = "ServiceTicket_TicketId";
			public const string ServiceTicket_Title = "ServiceTicket_Title";
			public const string ServiceTicketNote_AddedBy = "ServiceTicketNote_AddedBy";
			public const string ServiceTicketNote_DateStamp = "ServiceTicketNote_DateStamp";
			public const string ServiceTicketNote_Description = "ServiceTicketNote_Description";
			public const string ServiceTicketNote_Help = "ServiceTicketNote_Help";
			public const string ServiceTicketNote_Note = "ServiceTicketNote_Note";
			public const string ServiceTicketNote_Title = "ServiceTicketNote_Title";
			public const string ServiceTicketStatusHistory_AddedBy = "ServiceTicketStatusHistory_AddedBy";
			public const string ServiceTicketStatusHistory_DateStamp = "ServiceTicketStatusHistory_DateStamp";
			public const string ServiceTicketStatusHistory_Description = "ServiceTicketStatusHistory_Description";
			public const string ServiceTicketStatusHistory_Help = "ServiceTicketStatusHistory_Help";
			public const string ServiceTicketStatusHistory_Notes = "ServiceTicketStatusHistory_Notes";
			public const string ServiceTicketStatusHistory_Status = "ServiceTicketStatusHistory_Status";
			public const string ServiceTicketStatusHistory_Title = "ServiceTicketStatusHistory_Title";
			public const string ServiceTicketTemplate_AssociatedEquipment = "ServiceTicketTemplate_AssociatedEquipment";
			public const string ServiceTicketTemplate_CostEstimate = "ServiceTicketTemplate_CostEstimate";
			public const string ServiceTicketTemplate_Description = "ServiceTicketTemplate_Description";
			public const string ServiceTicketTemplate_Help = "ServiceTicketTemplate_Help";
			public const string ServiceTicketTemplate_HoursEstimate = "ServiceTicketTemplate_HoursEstimate";
			public const string ServiceTicketTemplate_Instructions = "ServiceTicketTemplate_Instructions";
			public const string ServiceTicketTemplate_RequiredParts = "ServiceTicketTemplate_RequiredParts";
			public const string ServiceTicketTemplate_Skill = "ServiceTicketTemplate_Skill";
			public const string ServiceTicketTemplate_Skill_High = "ServiceTicketTemplate_Skill_High";
			public const string ServiceTicketTemplate_Skill_Low = "ServiceTicketTemplate_Skill_Low";
			public const string ServiceTicketTemplate_Skill_Medium = "ServiceTicketTemplate_Skill_Medium";
			public const string ServiceTicketTemplate_Skill_Select = "ServiceTicketTemplate_Skill_Select";
			public const string ServiceTicketTemplate_Title = "ServiceTicketTemplate_Title";
			public const string ServiceTicketTemplate_TroubleshootingSteps = "ServiceTicketTemplate_TroubleshootingSteps";
			public const string ServiceTicketTemplate_Urgency = "ServiceTicketTemplate_Urgency";
			public const string ServiceTicketTemplate_Urgency_CriticalSafety = "ServiceTicketTemplate_Urgency_CriticalSafety";
			public const string ServiceTicketTemplate_Urgency_Important = "ServiceTicketTemplate_Urgency_Important";
			public const string ServiceTicketTemplate_Urgency_Low = "ServiceTicketTemplate_Urgency_Low";
			public const string ServiceTicketTemplate_Urgency_Normal = "ServiceTicketTemplate_Urgency_Normal";
			public const string ServiceTicketTemplate_Urgency_Select = "ServiceTicketTemplate_Urgency_Select";
		}
	}
}

