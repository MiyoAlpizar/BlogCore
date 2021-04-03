using AutoMapper;
using BlogCore.DataAccess.Data.Repository;
using BlogCore.Models.DTOS;
using BlogCore.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IWorkContainer workContainer;
        private readonly IMapper mapper;

        public CategoriesController(IWorkContainer workContainer, IMapper mapper)
        {
            this.workContainer = workContainer;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await workContainer.Category.GetList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var res = workContainer.Category.Add(category);
                await workContainer.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await workContainer.Category.Get(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                await workContainer.Category.Update(category.Id, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await workContainer.Category.Get(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var res = await workContainer.Category.Remove(id);
            if (res)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Delete));
        }

        #region CALL APIS 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await workContainer.Category.GetList() });
        }
        #endregion
    }
}
