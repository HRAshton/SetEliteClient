namespace SetElite.Settings
{
	public abstract class SettingsBase<T> : ISettings<T> where T : ConfigModelBase
	{
		public static string Name = "[ Unset ]";
		
		public static string Description = "[ Unset ]";

		public void Apply(T model, bool doWorkEvenIfDisabled = false)
		{
			if (model.IsEnabled || doWorkEvenIfDisabled)
			{
				Apply(model, null);
			}
		}

		protected abstract void Apply(T model, object _);
	}
}