using Microsoft.AspNetCore.Mvc;
using DoAn_WebAcc.Models;

namespace DoAn_WebAcc.Components
{
    [ViewComponent(Name = "AccHI")]
    public class AccHIComponent : ViewComponent
    {
        private readonly DataContext _context;
        public AccHIComponent(DataContext context) 
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listacc = (from p in _context.AccHIs
                           where (p.Sold != null || p.Sold == 0)
                           orderby p.UID descending
                           select p).Take(4).ToList();

            return await Task.FromResult((IViewComponentResult)View("Home", listacc));
        }

    }
}
