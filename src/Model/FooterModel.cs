using System;
using System.Reflection;
using Zone.UmbracoMapper;

namespace Graph.Components.Navigation
{
	public class FooterModel
	{
		[MultilineText]
		[PropertyMapping(SourceProperty = FooterConfig.AddressFieldAlias)]
		public string Address { get; set; }

		[PropertyMapping(SourceProperty = FooterConfig.PhoneFieldAlias)]
		public string Phone { get; set; }
		[PropertyMapping(SourceProperty = FooterConfig.EmailFieldAlias)]
		public string Email { get; set; }
		[PropertyMapping(SourceProperty = FooterConfig.FaxFieldAlias)]
		public string Fax { get; set; }

		[PropertyMapping(SourceProperty = FooterConfig.FacebookFieldAlias)]
		public string Facebook { get; set; }
		[PropertyMapping(SourceProperty = FooterConfig.TwitterFieldAlias)]
		public string Twitter { get; set; }
		[PropertyMapping(SourceProperty = FooterConfig.InstagramFieldAlias)]
		public string Instagram { get; set; }
		[PropertyMapping(SourceProperty = FooterConfig.LinkedInFieldAlias)]
		public string LinkedIn { get; set; }
		[PropertyMapping(SourceProperty = FooterConfig.YouTubeFieldAlias)]
		public string YouTube { get; set; }

		[PropertyMapping(SourceProperty = FooterConfig.CopyrightTextFieldAlias)]
		public string CopyrightText{ get; set; }
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class MultilineTextAttribute : Attribute, IMapFromAttribute
	{
		public void SetPropertyValue<T>(object fromObject, PropertyInfo property, T model, IUmbracoMapper mapper)
		{
			var text = fromObject as string;

			if (string.IsNullOrEmpty(text))
				return;

			var result = text
				.Replace("\r\n", "<br />")
				.Replace("\n", "<br />");

			property.SetValue(model, result);
		}
	}
}
