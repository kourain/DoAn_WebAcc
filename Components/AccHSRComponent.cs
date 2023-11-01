using Microsoft.AspNetCore.Mvc;
using DoAn_WebAcc.Models;

namespace DoAn_WebAcc.Components
{
    [ViewComponent(Name = "AccHSR")]
    public class AccHSRComponent : ViewComponent
    {
        private readonly DataContext _context;
        public AccHSRComponent(DataContext context) 
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listacc = (from p in _context.AccHSRs
                           where (p.Sold == false)
                           orderby p.UID descending
                           select p).Take(4).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listacc));
        }
    }
}
