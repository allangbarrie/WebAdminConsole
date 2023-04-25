using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminConsole.Models;

namespace WebAdminConsole.Controllers
{
    [Authorize]
    public class TeamsController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public TeamsController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Team.Include(t => t.Captain).Include(t => t.TeamCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Team == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .Include(t => t.Captain)
                .Include(t => t.TeamCategory)
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            ViewData["CaptainId"] = new SelectList(_context.Set<Captain>(), "CaptainId", "Name");
            ViewData["TeamCategoryId"] = new SelectList(_context.TeamCategory, "TeamCategoryId", "Name");
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamId,Name,CaptainId,TeamCategoryId")] Team team)
        {
            //if (ModelState.IsValid)
            //{
            _context.Add(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //ViewData["CaptainId"] = new SelectList(_context.Set<Captain>(), "CaptainId", "Name", team.CaptainId);
            //ViewData["TeamCategoryId"] = new SelectList(_context.TeamCategory, "TeamCategoryId", "Name", team.TeamCategoryId);
            //return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Team == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            ViewData["CaptainId"] = new SelectList(_context.Set<Captain>(), "CaptainId", "Name", team.CaptainId);
            ViewData["TeamCategoryId"] = new SelectList(_context.TeamCategory, "TeamCategoryId", "Name", team.TeamCategoryId);
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,Name,CaptainId,TeamCategoryId")] Team team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {

                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            ViewData["CaptainId"] = new SelectList(_context.Set<Captain>(), "CaptainId", "Name", team.CaptainId);
            ViewData["TeamCategoryId"] = new SelectList(_context.TeamCategory, "TeamCategoryId", "Name", team.TeamCategoryId);
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Team == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .Include(t => t.Captain)
                .Include(t => t.TeamCategory)
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Team == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Team'  is null.");
            }
            var team = await _context.Team.FindAsync(id);
            if (team != null)
            {
                _context.Team.Remove(team);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
          return (_context.Team?.Any(e => e.TeamId == id)).GetValueOrDefault();
        }
    }
}
