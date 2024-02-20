using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Widgets.MembersOnly.Models;

namespace Widgets.MembersOnly.Controllers
{
    public class MembersOnlyController : Controller
    {
        private readonly MembersOnlyWidgetSettings _membersOnlyWidgetSettings;

        public MembersOnlyController(MembersOnlyWidgetSettings membersOnlyWidgetSettings)
        {
            _membersOnlyWidgetSettings = membersOnlyWidgetSettings;
        }

        [HttpPost]
        public IActionResult Check(CheckCodeModel model)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);

            // TODO
            if (model.Password == _membersOnlyWidgetSettings.StorePassword)
                Response.Cookies.Append(".Member", Guid.NewGuid().ToString(), options);
            else
                return BadRequest();

            return Ok();
        }
    }
}
