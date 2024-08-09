using Microsoft.AspNetCore.Mvc;

namespace MyTodoApp.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var currentView = ViewContext.RouteData.Values["action"].ToString();
            return View("Default", currentView);
        }
    }
}
