using Microsoft.AspNetCore.Mvc;
using DoAn_WebAcc.Models;

namespace DoAn_WebAcc.Components
{
    [ViewComponent(Name = "MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private readonly DataContext _context;
        public MenuViewComponent(DataContext context) 
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from m in _context.Menus where (m.IsActive == true) select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));
            //return await Task.FromResult((IViewComponentResult)View("Default"));
        }
    }
}
