using System;
using MyToolkit.Model;
using Newtonsoft.Json;

namespace SetElite.Client.ParameterEntities.Virtual
{
    public abstract class VirtualParameterModel : ObservableObject
    {
        [JsonProperty(PropertyName = "IsEnabled")]
        private bool _isEnabled;

        public virtual bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }

        public abstract void Apply();

        public abstract void Reset();
    }
}
