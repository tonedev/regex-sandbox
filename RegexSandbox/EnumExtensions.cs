﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RegexSandbox
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DescriptionAttribute>()
                ?.Description ?? enumValue.ToString();
        }
    }
}
