using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Shit_Tool.Properties
{
	
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		
		
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
