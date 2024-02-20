using Grand.Business.Core.Interfaces.Common.Configuration;
using Grand.Business.Core.Utilities.Common.Security;
using Grand.Web.Common.Controllers;
using Grand.Web.Common.Filters;
using Grand.Web.Common.Security.Authorization;
using Microsoft.AspNetCore.Mvc;
using Widgets.MembersOnly.Models;

namespace Widgets.MembersOnly.Areas.Admin.Controllers
{
    [AuthorizeAdmin]
    [Area("Admin")]
    [PermissionAuthorize(PermissionSystemName.Widgets)]
    public class WidgetsMembersOnlyController : BasePluginController
    {
        private readonly MembersOnlyWidgetSettings _membersOnlyWidgetSettings;
        private readonly ISettingService _settingService;

        public WidgetsMembersOnlyController(
            ISettingService settingService,
            MembersOnlyWidgetSettings membersOnlyWidgetSettings)
        {
            _settingService = settingService;
            _membersOnlyWidgetSettings = membersOnlyWidgetSettings;
        }
        public IActionResult Configure()
        {
            var model = new ConfigurationModel();
            
            model.DisplayOrder = _membersOnlyWidgetSettings.DisplayOrder;
            model.CustomerGroups = _membersOnlyWidgetSettings.LimitedToGroups?.ToArray();
            model.Stores = _membersOnlyWidgetSettings.LimitedToStores?.ToArray();
            model.MembersOnlyAccessEnabled = _membersOnlyWidgetSettings.MembersOnlyAccessEnabled;
            model.StorePassword = _membersOnlyWidgetSettings.StorePassword;
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            _membersOnlyWidgetSettings.DisplayOrder = model.DisplayOrder;
            _membersOnlyWidgetSettings.LimitedToGroups = model.CustomerGroups == null ? new List<string>() : model.CustomerGroups.ToList();
            _membersOnlyWidgetSettings.LimitedToStores = model.Stores == null ? new List<string>() : model.Stores.ToList();
            _membersOnlyWidgetSettings.MembersOnlyAccessEnabled = model.MembersOnlyAccessEnabled;
            _membersOnlyWidgetSettings.StorePassword = model.StorePassword;
            _settingService.SaveSetting(_membersOnlyWidgetSettings);
            
            return Json("Ok");
        }
    }
}
