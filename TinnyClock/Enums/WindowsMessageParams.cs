using System;

namespace TinnyClock.Enums
{
    [Flags]
    public enum WindowsMessageParams
    {
        PBT_APMQUERYSUSPEND = 0x0,
        PBT_APMBATTERYLOW = 0x9, // Notifies applications that the battery power is low.
        PBT_APMOEMEVENT = 0xb, // Notifies applications that the APM BIOS has signalled  an APM OEM event.
        PBT_APMQUERYSTANDBY = 0x0001, // 

        PBT_APMPOWERSTATUSCHANGE =
            0xa, // Notifies applications of a change in the power status of the computer, such as a switch from battery power to A/C. The system also broadcasts this event when remaining battery power slips below the threshold specified by the user or if the battery power changes by a specified percentage.
        PBT_APMQUERYSUSPENDFAILED = 0x218, // Notifies applications that permission to suspend the computer was denied.

        PBT_APMRESUMEAUTOMATIC =
            0x12, // Notifies applications that the system is resuming from sleep or hibernation. If the system detects any user activity after broadcasting PBT_APMRESUMEAUTOMATIC, it will broadcast a PBT_APMRESUMESUSPEND event to let applications know they can resume full interaction with the user.
        PBT_APMRESUMECRITICAL = 0x6, // Notifies applications that the system has resumed operation.

        PBT_APMRESUMESUSPEND =
            0x7, // Notifies applications that the system has resumed operation after being suspended.
        PBT_APMSUSPEND = 0x4, // Notifies applications that the computer is about to enter a suspended state. 
        PBT_POWERSETTINGCHANGE = 0x8013, // Notifies applications that a power setting change event occurred.

        WM_POWER =
            0x48, // Notifies applications that the system, typically a battery-powered personal computer, is about to enter a suspended mode.
        WM_POWERBROADCAST = 0x218, // Notifies applications that a power-management event has occurred.
        BROADCAST_QUERY_DENY = 0x424D5144, //

        /// <summary>
        ///     https://msdn.microsoft.com/en-us/library/windows/desktop/aa363480(v=vs.85).aspx
        /// </summary>
        DBT_CONFIGCHANGECANCELED =
            0x0019, // A request to change the current configuration (dock or undock) has been canceled.
        DBT_CONFIGCHANGED = 0x0018, //The current configuration has changed, due to a dock or undock.
        DBT_CUSTOMEVENT = 0x8006, // A custom event has occurred.
        DBT_DEVICEARRIVAL = 0x8000, // A device or piece of media has been inserted and is now available.

        DBT_DEVICEQUERYREMOVE =
            0x8001, // Permission is requested to remove a device or piece of media. Any application can deny this request and cancel the removal.
        DBT_DEVICEQUERYREMOVEFAILED = 0x8002, // A request to remove a device or piece of media has been canceled.
        DBT_DEVICEREMOVECOMPLETE = 0x8004, // A device or piece of media has been removed.
        DBT_DEVICEREMOVEPENDING = 0x8003, // A device or piece of media is about to be removed. Cannot be denied.
        DBT_DEVICETYPESPECIFIC = 0x8005, // A device-specific event has occurred.
        DBT_DEVNODES_CHANGED = 0x0007, // A device has been added to or removed from the system.
        DBT_QUERYCHANGECONFIG = 0x0017, // Permission is requested to change the current configuration (dock or undock).
        DBT_USERDEFINED = 0xFFFF, // The meaning of this message is user-defined.
        WM_DEVICECHANGE = 0x219 //usb
    }
}