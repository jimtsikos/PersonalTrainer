using DomainModel.LessonImpl.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Application.Extensions.Enumarations
{
    public class EnumService : IEnumService
    {
        public EnumService()
        {

        }

        public IEnumerable<EnumIdValue> GetHoursList()
        {
            return from Hour d in Enum.GetValues(typeof(Hour))
                   select new EnumIdValue { Id = (int)d, Name = GetDescription(d) };
        }

        public IEnumerable<EnumIdValue> GetMinutesList()
        {
            return from Minutes d in Enum.GetValues(typeof(Minutes))
                   select new EnumIdValue { Id = (int)d, Name = GetDescription(d) };
        }

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
