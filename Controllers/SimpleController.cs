using Microsoft.AspNet.Mvc;
using MvcSample.Web.Models;
using Microsoft.AspNet.Routing;

namespace ssdugpresentation.Controllers
{
    [Route("Simple")]
    public class SomeSuperLongNameThatYouDoNotWishToHaveAsAnActualRouteController : Controller
    {
        [Route("Index")]
        public IActionResult SomeCrazyActionNameIWouldNotActualUseAndResolveBackToIndex()
        {
            return View(User());
        }

        public User User()
        {
            User user = new User()
            {
                Name = "My name",
                Address = "My address",
                Age = 77
            };

            return user;
        }
    }
}