using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Extensions.Enumarations
{
    public class EnumService : IEnumService
    {
        public string GetDescription(Enum value)
        {
            return value.GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description;
        }
    }
}
