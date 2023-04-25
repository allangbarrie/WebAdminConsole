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
    public class LeaderBoardsController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public LeaderBoardsController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: LeaderBoards
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LeaderBoard.Include(l => l.TeamCategory).Include(l => l.Team);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LeaderBoards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeaderBoard == null)
            {
                return NotFound();
            }

            var leaderBoard = await _context.LeaderBoard
                .Include(l => l.TeamCategory)
                .Include(l => l.Team)
                .FirstOrDefaultAsync(m => m.LeaderBoardId == id);
            if (leaderBoard == null)
            {
                return NotFound();
            }

            return View(leaderBoard);
        }

        // GET: LeaderBoards/Create
        public IActionResult Create()
        {
            ViewData["TeamCategoryId"] = new SelectList(_context.Set<TeamCategory>(), "TeamCategoryId", "Name");
            ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "TeamId", "Name");
            return View();
        }

        // POST: LeaderBoards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaderBoardId,Position,TeamId,Time,Difference,TeamCategoryId,CategoryPosition,CategoryDifference")] LeaderBoard leaderBoard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaderBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamCategoryId"] = new SelectList(_context.Set<TeamCategory>(), "TeamCategoryId", "Name", leaderBoard.TeamCategoryId);
            ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "TeamId", "Name", leaderBoard.TeamId);
            return View(leaderBoard);
        }

        // GET: LeaderBoards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeaderBoard == null)
            {
                return NotFound();
            }

            var leaderBoard = await _context.LeaderBoard.FindAsync(id);
            if (leaderBoard == null)
            {
                return NotFound();
            }
            ViewData["TeamCategoryId"] = new SelectList(_context.Set<TeamCategory>(), "TeamCategoryId", "Name", leaderBoard.TeamCategoryId);
            ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "TeamId", "Name", leaderBoard.TeamId);
            return View(leaderBoard);
        }

        // POST: LeaderBoards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaderBoardId,Position,TeamId,Time,Difference,TeamCategoryId,CategoryPosition,CategoryDifference")] LeaderBoard leaderBoard)
        {
            if (id != leaderBoard.LeaderBoardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaderBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaderBoardExists(leaderBoard.LeaderBoardId))
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
            ViewData["TeamCategoryId"] = new SelectList(_context.Set<TeamCategory>(), "TeamCategoryId", "Name", leaderBoard.TeamCategoryId);
            ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "TeamId", "Name", leaderBoard.TeamId);
            return View(leaderBoard);
        }

        // GET: LeaderBoards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeaderBoard == null)
            {
                return NotFound();
            }

            var leaderBoard = await _context.LeaderBoard
                .Include(l => l.TeamCategory)
                .Include(l => l.Team)
                .FirstOrDefaultAsync(m => m.LeaderBoardId == id);
            if (leaderBoard == null)
            {
                return NotFound();
            }

            return View(leaderBoard);
        }

        // POST: LeaderBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeaderBoard == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeaderBoard'  is null.");
            }
            var leaderBoard = await _context.LeaderBoard.FindAsync(id);
            if (leaderBoard != null)
            {
                _context.LeaderBoard.Remove(leaderBoard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaderBoardExists(int id)
        {
          return (_context.LeaderBoard?.Any(e => e.LeaderBoardId == id)).GetValueOrDefault();
        }
    }
}
