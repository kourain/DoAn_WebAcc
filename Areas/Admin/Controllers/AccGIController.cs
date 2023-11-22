using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;

namespace DoAn_WebAcc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccGIController : Controller
    {
        private readonly DataContext _Context;
        public AccGIController(DataContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            var mnlist = _Context.AccGIs.OrderBy(m => m.UID).ToList();
            return View(mnlist);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _Context.AccGIs.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleAccGI = _Context.AccGIs.Find(id);
            if (deleAccGI == null)
            {
                return NotFound();
            }
            _Context.AccGIs.Remove(deleAccGI);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AccGI mn)
        {
            if (_Context.AccGIs.Find(mn.UID) == null)
            {
                _Context.AccGIs.Add(mn);
                _Context.SaveChanges();
                ViewBag.AccGICreate = "";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.AccGICreate = $"UID: {mn.UID} đã tồn tại";
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _Context.AccGIs.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AccGI mn)
        {
            if (ModelState.IsValid)
            {
                _Context.AccGIs.Update(mn);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
