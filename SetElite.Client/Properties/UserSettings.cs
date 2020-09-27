using System.Configuration;
using System.IO;
using SetElite.Settings;

namespace SetElite.Client.Properties
{
    internal sealed partial class UserSettings : IUserSettings {
        private UserSettings() {

            SettingsProvider provider = new CustomSettingsProvider(Path.Combine(AppSettings.Default.UserConfigPath, "user.config"));

            // Try to re-use an existing provider, since we cannot have multiple providers
            // with same name.
            if (Providers[provider.Name] == null)
                Providers.Add(provider);
            else
                provider = Providers[provider.Name];

            // Change default provider.
            foreach (SettingsProperty property in Properties)
            {
                if (
                    property.PropertyType.GetCustomAttributes(
                        typeof(SettingsProviderAttribute),
                        false
                    ).Length == 0
                )
                {
                    property.Provider = provider;
                }
            }
        }
    }
}
