using Grand.Infrastructure.ModelBinding;
using Grand.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace Widgets.MembersOnly.Models
{
    public class ConfigurationModel : BaseModel
    {
        
        [GrandResourceDisplayName("Widgets.MembersOnly.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [UIHint("CustomerGroups")]
        [GrandResourceDisplayName("Widgets.MembersOnly.Fields.LimitedToGroups")]
        public string[] CustomerGroups { get; set; }

        //Store acl
        [GrandResourceDisplayName("Widgets.MembersOnly.Fields.LimitedToStores")]
        [UIHint("Stores")]
        public string[] Stores { get; set; }

        [GrandResourceDisplayName("Widgets.MembersOnly.Fields.MembersOnlyAccessEnabled")]
        public bool MembersOnlyAccessEnabled { get; set; }

        [GrandResourceDisplayName("Widgets.MembersOnly.Fields.StorePassword")]
        public string StorePassword { get; set; }
    }
}