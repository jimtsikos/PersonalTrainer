using System.ComponentModel;

namespace DomainModel.LessonImpl.Enum
{
    public enum Minutes
    {
        [Description("00")]
        OClock,
        [Description("15")]
        Quarter,
        [Description("30")]
        Half,
        [Description("45")]
        ThreeQuarters
    }
}
