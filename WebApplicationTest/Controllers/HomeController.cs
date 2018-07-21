using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Threading;

namespace WebApplicationTest.Controllers
{

    public class customAuthorizeAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            var headers = filterContext.RequestContext.HttpContext.Request.Headers;
            foreach( var header in headers)
            {
                System.Diagnostics.Trace.WriteLine(header.ToString() + " - " + headers[header.ToString()]);
            }

            new HomeController().EnableAccess();
            
        }
    }

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return Content("<a href='/home/authenticatedaccess'>Authenticated Access</a><br/><p /><a href='/home/EnableAccess'>Enable Access</a>");
        }

        [customAuthorize]
        public ActionResult authenticatedaccess()
        {

            

           // Thread.CurrentPrincipal = claimPrincipal;
           

            return Content("Successfully Authenticated");
        }

        public void EnableAccess()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Vaibhav"),
                new Claim(ClaimTypes.Email,"vibs2006@gmail.com")
            };


            var identity = new ClaimsIdentity(claims, "ApplicationCookie");
            var claimPrincipal = new ClaimsPrincipal(identity);

            Thread.CurrentPrincipal = claimPrincipal;

        }
    }
}