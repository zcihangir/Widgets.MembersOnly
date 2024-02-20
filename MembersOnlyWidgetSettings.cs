using Grand.Domain.Configuration;

namespace Widgets.MembersOnly
{
    public class MembersOnlyWidgetSettings : ISettings
    {
        public MembersOnlyWidgetSettings()
        {
            LimitedToStores = new List<string>();
            LimitedToGroups = new List<string>();
        }
        public int DisplayOrder { get; set; }

        public IList<string> LimitedToStores { get; set; }

        public IList<string> LimitedToGroups { get; set; }

        public bool MembersOnlyAccessEnabled { get; set; }

        public string StorePassword { get; set; }
    }
}
