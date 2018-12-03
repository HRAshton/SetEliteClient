using System;
using MyToolkit.Command;
using MyToolkit.Model;
using Newtonsoft.Json;

namespace SetElite.Client.ParameterEntities.Virtual
{
    public abstract class VirtualParameterModel : ObservableObject
    {
        [JsonProperty(PropertyName = "IsEnabled")]
        private bool _isEnabled;
        
        /// <summary>
        /// Команда сброса параметра.
        /// </summary>
        public virtual RelayCommand ResetCommand => new RelayCommand(Reset);

        /// <summary>
        /// Включена ли синхронизация параметра.
        /// </summary>
        public virtual bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }

        /// <summary>
        /// Применить параметр.
        /// </summary>
        public abstract void Apply();

        /// <summary>
        /// Сбросить значение параметра.
        /// </summary>
        public abstract void Reset();
    }
}
