using System;

namespace TinyMonitorApp.Enums
{
    /// <summary>
    ///     From http://wiki.winehq.org/List_Of_Windows_Messages
    /// </summary>
    [Flags]
    public enum WindowsMessages : uint
    {
        WM_DEVICECHANGE = 0x0219,
        WM_APP = 0x0319
    }
}