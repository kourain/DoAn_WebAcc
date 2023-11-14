using Microsoft.AspNetCore.Mvc;
using DoAn_WebAcc.Models;

namespace DoAn_WebAcc.Components
{
    [ViewComponent(Name = "FooterView")]
    public class FooterViewComponent : ViewComponent
    {
        private readonly DataContext _context;
        public FooterViewComponent(DataContext context) 
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofFooter = (from m in _context.Footers where (m.IsActive == true) select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofFooter));
            //return await Task.FromResult((IViewComponentResult)View("Default"));
        }
    }
}
