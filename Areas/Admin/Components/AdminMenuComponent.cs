﻿using Microsoft.AspNetCore.Mvc;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Areas.Admin.Utilities;

namespace DoAn_WebAcc.Areas.Admin.Components
{
    [ViewComponent(Name = "AdminMenu")]
    public class AdminMenuComponent : ViewComponent
    {
        private readonly DataContext _context;
        public AdminMenuComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mnlist = (from mn in _context.AdminMenus
                          where (mn.IsActive ==true)
                          select mn).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default",mnlist));
        }
    }
}
