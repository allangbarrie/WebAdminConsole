using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using WebAdminConsole.Models;
using WebAdminConsole.ViewModels;

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
            var applicationDbContext = _context.Team
                .Include(t => t.Captain)
                .Include(t => t.TeamCategory);

            List<TeamViewModel> teamsViewModel = new List<TeamViewModel>();

            foreach (var team in applicationDbContext)
            {
                TeamViewModel teamViewModel = new TeamViewModel()
                {
                    Name = team.Name,
                    TeamId = team.TeamId,
                    CaptainId = team.CaptainId,
                    Captain = team.Captain,
                    TeamCategoryId = team.TeamCategoryId, 
                    TeamCategory = team.TeamCategory,
                    RunnerCount= _context.Runner
                        .Where(u => u.TeamId == team.TeamId)
                        .Count()
                };
                teamsViewModel.Add(teamViewModel);
            }

            var noRunners = teamsViewModel
                .Where(t => t.RunnerCount == 0)
                .Count();

            var elevenPlus = teamsViewModel
                .Where(t => t.RunnerCount >= 11)
                .Count();

            var lessThanEleven = teamsViewModel
                .Where(t => t.RunnerCount < 11)
                .Where(t => t.RunnerCount != 0)
                .Count();

            ViewData["NoRunners"] = string.Format("Nothing declared: {0}", noRunners);
            ViewData["ElevenPlus"] = string.Format("11 or more: {0}", elevenPlus);
            ViewData["LessThanEleven"] = string.Format("Less than 11: {0}", lessThanEleven);

            return View(teamsViewModel);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,Name,CaptainId,TeamCategoryId")] Team team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

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

        public async Task AddCaptain(string captainEmail)
        {
            var captain = new Captain
            {
                Name = captainEmail
            };
            _context.Add(captain);
            await _context.SaveChangesAsync();
        }

        public async Task AddTeam(BulkTeamCreateViewModel team)
        {
            var captain = await _context.Captain.FirstAsync(x => x.Name == team.CaptainEmail);

            var newTeam = new Team
            {
                Name = team.TeamName,
                CaptainId = captain.CaptainId,
                TeamCategoryId = 1
            };
            _context.Add(newTeam);
            await _context.SaveChangesAsync();
        }
    }
}
