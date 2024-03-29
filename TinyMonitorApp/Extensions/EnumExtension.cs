﻿using System;
using NLog.LayoutRenderers.Wrappers;

namespace TinyMonitorApp.Extensions
{
    public static class EnumExtension
    {
        public static T ToEnum<T>(this string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return Enum.TryParse<T>(value, true, out var result) ? result : defaultValue;
        }
    }
}