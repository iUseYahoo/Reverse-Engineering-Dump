using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Stand_Launchpad.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.5.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool AutoInject
		{
			get
			{
				return (bool)this["AutoInject"];
			}
			set
			{
				this["AutoInject"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string CustomDll
		{
			get
			{
				return (string)this["CustomDll"];
			}
			set
			{
				this["CustomDll"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool Advanced
		{
			get
			{
				return (bool)this["Advanced"];
			}
			set
			{
				this["Advanced"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("1")]
		public string InjectDll
		{
			get
			{
				return (string)this["InjectDll"];
			}
			set
			{
				this["InjectDll"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int AutoInjectDelaySeconds
		{
			get
			{
				return (int)this["AutoInjectDelaySeconds"];
			}
			set
			{
				this["AutoInjectDelaySeconds"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool MustUpgrade
		{
			get
			{
				return (bool)this["MustUpgrade"];
			}
			set
			{
				this["MustUpgrade"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("1")]
		public int GameLauncher
		{
			get
			{
				return (int)this["GameLauncher"];
			}
			set
			{
				this["GameLauncher"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("-1")]
		public int Version
		{
			get
			{
				return (int)this["Version"];
			}
			set
			{
				this["Version"] = value;
			}
		}

		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
