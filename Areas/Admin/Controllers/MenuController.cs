using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;

namespace DoAn_WebAcc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext _Context;
        public MenuController(DataContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {

            var mnlist = _Context.Menus.OrderBy(m => m.MenuId).ToList();
            return View(mnlist);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _Context.Menus.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleMenu = _Context.Menus.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _Context.Menus.Remove(deleMenu);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
    
        public IActionResult Create()
        {
            var mnlist = (from m in _Context.Menus.Where(m => m.ParentID == 0)
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuId.ToString()
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
        public IActionResult Create(Menu mn)
        {
            //lấy max footerid có sẵn trong bảng csdl
            int Menuid = 0;
            try
            {
                Menuid = (from p in _Context.Menus
                        orderby p.MenuId descending
                        select p.MenuId).Take(1).ToList()[0];
            }
            catch { Menuid = 0; };
            mn.MenuId = Menuid + 1;
            if (ModelState.IsValid)
            {
                _Context.Menus.Add(mn);
                    _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

		public IActionResult Edit(int? id)
		{
		    if(id == null || id == 0)
            {
                return NotFound();
            }
            var mn=_Context.Menus.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            var mnlist=(from m in _Context.Menus.Where(m => m.ParentID == 0)
                        select new SelectListItem()
                        {
                            Text=m.MenuName,
                            Value=m.MenuId.ToString()   
                        }
                        ).ToList() ;
            mnlist.Insert(0, new SelectListItem()
            {
                Text = "Default",
                Value = "0"
            }) ;
            ViewBag.mnlist = mnlist;
            return View(mn);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Menu mn)
		{
			if (ModelState.IsValid)
			{
				_Context.Menus.Update(mn);
				_Context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
