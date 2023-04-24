using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminConsole.Models;

namespace WebService.Controllers
{
    [Authorize]
    public class StagesController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public StagesController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: Stages
        public async Task<IActionResult> Index()
        {
              return _context.Stage != null ? 
                          View(await _context.Stage.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Stage'  is null.");
        }

        // GET: Stages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stage == null)
            {
                return NotFound();
            }

            var stage = await _context.Stage
                .FirstOrDefaultAsync(m => m.StageId == id);
            if (stage == null)
            {
                return NotFound();
            }

            return View(stage);
        }

        // GET: Stages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StageId,Number,Name,Cutoff")] Stage stage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stage);
        }

        // GET: Stages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stage == null)
            {
                return NotFound();
            }

            var stage = await _context.Stage.FindAsync(id);
            if (stage == null)
            {
                return NotFound();
            }
            return View(stage);
        }

        // POST: Stages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StageId,Number,Name,Cutoff")] Stage stage)
        {
            if (id != stage.StageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StageExists(stage.StageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stage);
        }

        // GET: Stages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stage == null)
            {
                return NotFound();
            }

            var stage = await _context.Stage
                .FirstOrDefaultAsync(m => m.StageId == id);
            if (stage == null)
            {
                return NotFound();
            }

            return View(stage);
        }

        // POST: Stages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stage == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Stage'  is null.");
            }
            var stage = await _context.Stage.FindAsync(id);
            if (stage != null)
            {
                _context.Stage.Remove(stage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StageExists(int id)
        {
          return (_context.Stage?.Any(e => e.StageId == id)).GetValueOrDefault();
        }
    }
}
