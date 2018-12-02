using System;
using Dal.ParameterEntities.Virtual;

namespace Dal.ParameterEntities
{
    public sealed class KeyboardLayoutHotkeyParameterEntity : ParameterEntity
    {
        public KeyboardLayoutHotkeyParameterEntity()
        {
            IsEnabled = false;
            Value = KeyboardLayouts.AltShift;
        }

        public KeyboardLayouts Value { get; set; }
    }

    public enum KeyboardLayouts
    {
        AltShift = 0,
        CtrlShift = 1
    }
}
