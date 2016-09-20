using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using lab.adminltetheme.ViewModels;

namespace lab.adminltetheme.Helpers
{
    public class UserAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    UserViewModel currentUser = AppHelper.CurrentUser;
                    if (currentUser == null)
                    {
                        currentUser = new UserViewModel();
                        AppHelper.CurrentUser = currentUser;
                    }
                    if (currentUser != null)
                    {
                        var routeData = ((MvcHandler)filterContext.HttpContext.Handler).RequestContext.RouteData;
                        object currentAreaName;
                        routeData.Values.TryGetValue("area", out currentAreaName);
                        object currentControllerName;
                        routeData.Values.TryGetValue("controller", out currentControllerName);
                        object currentActionName;
                        routeData.Values.TryGetValue("action", out currentActionName);

                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                        {
                            filterContext.HttpContext.Response.StatusCode = 403;
                            filterContext.Result = new JsonResult
                            {
                                Data = new
                                {
                                    // put whatever data you want which will be sent
                                    // to the client
                                    message = "You are not authenticated user."
                                },
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                        }
                        else
                        {
                            filterContext.Result = CreateResult(filterContext);
                        }
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("/Login");
                    }
                }
                base.OnAuthorization(filterContext);
            }
        }

        private string GetClaimInformation(string claimType)
        {
            ClaimsIdentity claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
            var claim = claimsIdentity.Claims.Where(c => c.Type.ToLower() == claimType.ToLower()).FirstOrDefault();
            return claim == null ? null : claim.Value;
        }

        protected ActionResult CreateResult(AuthorizationContext filterContext)
        {
            var viewName = "~/Views/Shared/AccessDenied.cshtml";
            return new PartialViewResult
            {
                ViewName = viewName
            };
        }
    }
}