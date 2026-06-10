using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClipShare.Utility
{
    public static class SD
    {
        public const string AdminRole = "admin";
        public const string ModeratorRole = "moderator";
        public const string UserRole = "user";
        public static readonly List<string> Roles = new List<string> { AdminRole, UserRole, ModeratorRole };
        // public const int MB = 1000000;
        // public static readonly List<string> LocalIpAddresses = new List<string> { "127.0.0.1", "::1" };

        public static string IsActive(this IHtmlHelper html, string controller, string action, string cssClass = "active")
        {
            var routeData = html.ViewContext.RouteData;
            var routeAction = routeData.Values["action"]?.ToString();
            var routeController = routeData.Values["controller"]?.ToString();

            var retrunActive = controller == routeController && action == routeAction;

            return retrunActive ? cssClass : string.Empty;
        }
    }
}
