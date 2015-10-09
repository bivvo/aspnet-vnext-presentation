using Microsoft.AspNet.Mvc;
using MvcSample.Web.Models;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.Hosting;

namespace ssdugpresentation.Controllers
{
    [Route("Simple")]
    public class SomeSuperLongNameThatYouDoNotWishToHaveAsAnActualRouteController : Controller
    {
        private IConfiguration _config;

        public SomeSuperLongNameThatYouDoNotWishToHaveAsAnActualRouteController(IConfiguration config)
        {
            _config = config;
        }


        [Route("Index")]
        public IActionResult SomeCrazyActionNameIWouldNotActualUseAndResolveBackToIndex()
        {
            return View(User());
        }

        [Route("Config")]
        public IActionResult ReadConfig()
        {

           return Json(new {
                env = new { samplevar =_config.Get("samplevar") },
                config = new {configvar = _config.Get("configvar")}
            });
        }

        public User User()
        {
            User user = new User()
            {
                Name = "SSDUG GROUP",
                Address = "My address",
                Age = 77
            };

            return user;
        }
    }
}