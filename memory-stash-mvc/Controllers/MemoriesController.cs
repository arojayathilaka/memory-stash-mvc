using memory_stash_mvc.Models;
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
        private readonly GroupsController _groupsController;


        public MemoriesController(AppDbContext context, GroupsController groupsController)
        {
            _context = context;
            _groupsController = groupsController;
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
                return Redirect("/Groups/Details/" + memory.GroupId);
            }
            return View(memory);
        }

        // GET: MemoriesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var memory = await _context.Memories.FindAsync(id);
            return View(memory);
        }


        // POST: MemoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Memory memory)
        {
            if(id != memory.Id || !_groupsController.GroupExists(memory.GroupId))
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Entry(memory).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return Redirect("/Groups/Details/"+memory.GroupId);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemoryExists(memory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(memory);

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

        private bool MemoryExists(int id)
        {
            return _context.Memories.Any(m => m.Id == id);
        }
    }
}
