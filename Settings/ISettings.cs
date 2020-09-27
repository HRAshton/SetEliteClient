namespace SetElite.Settings
{
	public interface ISettings<in T> where T : ConfigModelBase
	{
		void Apply(T model, bool doWorkEvenIfDisabled = false);
	}
}