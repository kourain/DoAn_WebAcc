using Microsoft.AspNetCore.Mvc;
using DoAn_WebAcc.Models;

namespace DoAn_WebAcc.Components
{
    [ViewComponent(Name = "AccGI")]
    public class AccGIComponent : ViewComponent
    {
        private readonly DataContext _context;
        public AccGIComponent(DataContext context) 
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listacc = (from p in _context.AccGIs
                              where (p.Sold != null)
                              orderby p.UID ascending
                              select p).Take(4).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listacc));
        }
    }
}
