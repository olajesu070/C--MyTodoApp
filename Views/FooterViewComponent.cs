using Microsoft.AspNetCore.Mvc;

namespace MyTodoApp.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
