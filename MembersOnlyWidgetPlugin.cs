using Grand.Business.Core.Extensions;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Infrastructure.Plugins;

namespace Widgets.MembersOnly
{

    public class MembersOnlyWidgetPlugin : BasePlugin, IPlugin
    {
        private readonly ITranslationService _translationService;
        private readonly ILanguageService _languageService;

        public MembersOnlyWidgetPlugin(
            ITranslationService translationService,
            ILanguageService languageService)
        {
            _translationService = translationService;
            _languageService = languageService;
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override async Task Install()
        {
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.MembersOnly.Fields.DisplayOrder", "Display order");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.MembersOnly.Fields.LimitedToGroups", "Limited to groups");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.MembersOnly.Fields.LimitedToStores", "Limited to stores");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.MembersOnly.Fields.StorePassword", "Password");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.MembersOnly.Fields.MembersOnlyAccessEnabled", "Access Enabled");
            await base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override async Task Uninstall()
        {
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.MembersOnly.Fields.DisplayOrder");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.MembersOnly.Fields.LimitedToGroups");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.MembersOnly.Fields.LimitedToStores");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.MembersOnly.Fields.StorePassword");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.MembersOnly.Fields.MembersOnlyAccessEnabled");
            await base.Uninstall();
        }

        public override string ConfigurationUrl()
        {
            return MembersOnlyWidgetDefaults.ConfigurationUrl;
        }
    }
}
