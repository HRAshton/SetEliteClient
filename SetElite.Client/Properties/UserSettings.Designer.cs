﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SetElite.Settings.Keyboard;
using SetElite.Settings.Wallpaper;

namespace SetElite.Client.Properties {
    
    
    [CompilerGenerated()]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class UserSettings : ApplicationSettingsBase {
        
        private static UserSettings defaultInstance = ((UserSettings)(Synchronized(new UserSettings())));
        
        public static UserSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [UserScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("False")]
        public bool Wallpaper_Enabled {
            get {
                return ((bool)(this["Wallpaper_Enabled"]));
            }
            set {
                this["Wallpaper_Enabled"] = value;
            }
        }
        
        [UserScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("Stretched")]
        public WallpaperStyle Wallpaper_WallpaperStyle {
            get {
                return ((WallpaperStyle)(this["Wallpaper_WallpaperStyle"]));
            }
            set {
                this["Wallpaper_WallpaperStyle"] = value;
            }
        }
        
        [UserScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("False")]
        public bool Keyboard_IsEnabled {
            get {
                return ((bool)(this["Keyboard_IsEnabled"]));
            }
            set {
                this["Keyboard_IsEnabled"] = value;
            }
        }
        
        [UserScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("CtrlShift")]
        public KeyboardLayout Keyboard_Mode {
            get {
                return ((KeyboardLayout)(this["Keyboard_Mode"]));
            }
            set {
                this["Keyboard_Mode"] = value;
            }
        }
        
        [UserScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("True")]
        public bool Hotkeys_IsEnabled {
            get {
                return ((bool)(this["Hotkeys_IsEnabled"]));
            }
            set {
                this["Hotkeys_IsEnabled"] = value;
            }
        }
    }
}
