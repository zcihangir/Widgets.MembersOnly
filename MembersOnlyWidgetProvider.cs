using Grand.Business.Core.Interfaces.Cms;
using Grand.Business.Core.Interfaces.Common.Localization;

namespace Widgets.MembersOnly
{
    public class MembersOnlyWidgetProvider : IWidgetProvider
    {
        private readonly ITranslationService _translationService;
        private readonly MembersOnlyWidgetSettings _membersOnlyWidgetSettings;

        public MembersOnlyWidgetProvider(ITranslationService translationService, MembersOnlyWidgetSettings membersOnlyWidgetSettings)
        {
            _translationService = translationService;
            _membersOnlyWidgetSettings = membersOnlyWidgetSettings;
        }

        public string ConfigurationUrl => MembersOnlyWidgetDefaults.ConfigurationUrl;

        public string SystemName => MembersOnlyWidgetDefaults.ProviderSystemName;

        public string FriendlyName => _translationService.GetResource(MembersOnlyWidgetDefaults.FriendlyName);

        public int Priority => _membersOnlyWidgetSettings.DisplayOrder;

        public IList<string> LimitedToStores => _membersOnlyWidgetSettings.LimitedToStores;

        public IList<string> LimitedToGroups => _membersOnlyWidgetSettings.LimitedToGroups;
       
        public async Task<IList<string>> GetWidgetZones()
        {
          return await  Task.FromResult(new List<string>());
        }

        public Task<string> GetPublicViewComponentName(string widgetZone)
        {
            return Task.FromResult("WidgetMembersOnly");
        }

    }
}
