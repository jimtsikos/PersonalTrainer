using System;
using System.Collections.Generic;

namespace Application.Extensions.Enumarations
{
    public interface IEnumService
    {
        IEnumerable<EnumIdValue> GetHoursList();
        IEnumerable<EnumIdValue> GetMinutesList();
        string GetDescription(Enum value);
        string GetMinutesDescription(int value);
        string GetHoursDescription(int value);
    }
}
