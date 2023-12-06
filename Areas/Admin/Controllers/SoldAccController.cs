using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;

namespace DoAn_WebAcc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SoldAccController : Controller
	{
		private readonly DataContext _Context;
		public SoldAccController(DataContext context)
		{
			_Context = context;
		}
		public IActionResult SoldAccGI()
		{
			var mnlist = _Context.AccGIs.Where(m=>m.Sold != null && m.Sold!=0).OrderBy(m => m.SoldDate).ToList();
			return View(mnlist);
        }
        public IActionResult SoldAccHI()
        {
            var mnlist = _Context.AccHIs.Where(m => m.Sold != null && m.Sold != 0).OrderBy(m => m.SoldDate).ToList();
            return View(mnlist);
        }
        public IActionResult SoldAccHSR()
        {
            var mnlist = _Context.AccHSRs.Where(m => m.Sold != null && m.Sold != 0).OrderBy(m => m.SoldDate).ToList();
            return View(mnlist);
        }
        public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var mn = _Context.AccHIs.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			return View(mn);
		}
		[HttpPost]
		public IActionResult Delete(int id)
		{
			var deleAccHI = _Context.AccHIs.Find(id);
			if (deleAccHI == null)
			{
				return NotFound();
			}
			_Context.AccHIs.Remove(deleAccHI);
			_Context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
