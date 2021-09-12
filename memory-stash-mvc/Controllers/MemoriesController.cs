using memory_stash.Models;
using memory_stash_mvc.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memory_stash_mvc.Controllers
{
    public class MemoriesController : Controller
    {
        private readonly AppDbContext _context;

        public MemoriesController(AppDbContext context)
        {
            _context = context;
        }


        // GET: MemoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MemoriesController/Create
        public ActionResult Create(int groupId)
        {
            Memory memory = new()
            {
                GroupId = groupId
            };
            return View(memory);
        }

        // POST: MemoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Memory memory)
        {
            if (ModelState.IsValid)
            {
                _context.Memories.Add(memory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Groups/Details/"+memory.GroupId);
            }
            return View(memory);
        }

        // GET: MemoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
