using System.ComponentModel;

namespace SetElite.Client.ServiceClasses
{
    /// <summary>
    /// Горячие клавиши переключения раскладки.
    /// </summary>
    public enum KeyboardLayouts
    {
        /// <summary>
        /// Alt + Shift.
        /// </summary>
        [Description("Alt + Shift")]
        AltShift,

        /// <summary>
        /// Ctrl + Shift.
        /// </summary>
        [Description("Ctrl + Shift")]
        CtrlShift
    }
}