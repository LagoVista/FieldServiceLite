/*6/5/2019 07:40:25*/
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
//Resources:FSResources:ServiceTicket_Description

		public static string ServiceTicket_Description { get { return GetResourceString("ServiceTicket_Description"); } }
//Resources:FSResources:ServiceTicket_Help

		public static string ServiceTicket_Help { get { return GetResourceString("ServiceTicket_Help"); } }
//Resources:FSResources:ServiceTicket_Title

		public static string ServiceTicket_Title { get { return GetResourceString("ServiceTicket_Title"); } }
//Resources:FSResources:ServiceTicketTemplate_Description

		public static string ServiceTicketTemplate_Description { get { return GetResourceString("ServiceTicketTemplate_Description"); } }
//Resources:FSResources:ServiceTicketTemplate_Help

		public static string ServiceTicketTemplate_Help { get { return GetResourceString("ServiceTicketTemplate_Help"); } }
//Resources:FSResources:ServiceTicketTemplate_Title

		public static string ServiceTicketTemplate_Title { get { return GetResourceString("ServiceTicketTemplate_Title"); } }

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
			public const string ServiceTicket_Description = "ServiceTicket_Description";
			public const string ServiceTicket_Help = "ServiceTicket_Help";
			public const string ServiceTicket_Title = "ServiceTicket_Title";
			public const string ServiceTicketTemplate_Description = "ServiceTicketTemplate_Description";
			public const string ServiceTicketTemplate_Help = "ServiceTicketTemplate_Help";
			public const string ServiceTicketTemplate_Title = "ServiceTicketTemplate_Title";
		}
	}
}

