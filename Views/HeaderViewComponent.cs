using Microsoft.AspNetCore.Mvc;

namespace MyTodoApp.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var currentView = ViewContext.RouteData.Values["action"].ToString();
            return View("Default", currentView);
        }
    }
}
