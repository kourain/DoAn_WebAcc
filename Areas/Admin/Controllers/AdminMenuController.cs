using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;
using DoAn_WebAcc.Areas.Admin.Models;

namespace DoAn_WebAcc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMenuController : Controller
    {
        private readonly DataContext _Context;
        public AdminMenuController(DataContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {

            var mnlist = _Context.AdminMenus.OrderBy(m => m.AdminMenuId).ToList();
            return View(mnlist);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _Context.AdminMenus.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleAdminMenu = _Context.AdminMenus.Find(id);
            if (deleAdminMenu == null)
            {
                return NotFound();
            }
            _Context.AdminMenus.Remove(deleAdminMenu);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            var mnlist = (from m in _Context.AdminMenus.Where(m => m.ParentLevel == 0)
                          select new SelectListItem()
                          {
                              Text = m.ItemName,
                              Value = m.AdminMenuId.ToString()
                          }
                          ).ToList();
            mnlist.Insert(0, new SelectListItem()
            {
                Text = "Default",
                Value = "0"
            });
            ViewBag.mnlist = mnlist;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdminMenu mn)
        {
            //lấy max footerid có sẵn trong bảng csdl
            long AdminMenuid = 0;
            try
            {
                AdminMenuid = (from p in _Context.AdminMenus
                          orderby p.AdminMenuId descending
                          select p.AdminMenuId).Take(1).ToList()[0];
            }
            catch { AdminMenuid = 0; };
            mn.AdminMenuId = AdminMenuid + 1;
            if (ModelState.IsValid)
            {
                _Context.AdminMenus.Add(mn);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _Context.AdminMenus.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            var mnlist = (from m in _Context.AdminMenus.Where(m => m.ParentLevel == 0)
                          select new SelectListItem()
                          {
                              Text = m.ItemName,
                              Value = m.AdminMenuId.ToString()
                          }
                        ).ToList();
            mnlist.Insert(0, new SelectListItem()
            {
                Text = "Default",
                Value = "0"
            });
            ViewBag.mnlist = mnlist;
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AdminMenu mn)
        {
            if (ModelState.IsValid)
            {
                _Context.AdminMenus.Update(mn);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
