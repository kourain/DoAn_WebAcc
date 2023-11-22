using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;

namespace DoAn_WebAcc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AccHIController : Controller
	{
		private readonly DataContext _Context;
		public AccHIController(DataContext context)
		{
			_Context = context;
		}
		public IActionResult Index()
		{
			var mnlist = _Context.AccHIs.OrderBy(m => m.UID).ToList();
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

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(AccHI mn)
		{
			if (_Context.AccHIs.Find(mn.UID) == null)
			{
				_Context.AccHIs.Add(mn);
				_Context.SaveChanges();
                ViewBag.AccHICreate = "";
                return RedirectToAction("Index");
            }
			else
			{
				ViewBag.AccHICreate = $"UID: {mn.UID} đã tồn tại";
			}
			return View();
		}

		public IActionResult Edit(int? id)
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
		[ValidateAntiForgeryToken]
		public IActionResult Edit(AccHI mn)
		{
			if (ModelState.IsValid)
			{
				_Context.AccHIs.Update(mn);
				_Context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
