﻿using System;
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
    public class ResultsController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public ResultsController(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Result.Include(r => r.BibNumber).Include(r => r.Stage);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Result == null)
            {
                return NotFound();
            }

            var result = await _context.Result
                .Include(r => r.BibNumber)
                .Include(r => r.Stage)
                .FirstOrDefaultAsync(m => m.ResultId == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        public IActionResult Create()
        {
            ViewData["BibNumberId"] = new SelectList(_context.BibNumber, "BibNumberId", "Name");
            ViewData["StageId"] = new SelectList(_context.Stage, "StageId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResultId,StageId,Time,BibNumberId")] Result result)
        {
            if (ModelState.IsValid)
            {
                _context.Add(result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BibNumberId"] = new SelectList(_context.BibNumber, "BibNumberId", "Name", result.BibNumberId);
            ViewData["StageId"] = new SelectList(_context.Stage, "StageId", "Name", result.StageId);
            return View(result);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Result == null)
            {
                return NotFound();
            }

            var result = await _context.Result.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            ViewData["BibNumberId"] = new SelectList(_context.BibNumber, "BibNumberId", "Name", result.BibNumberId);
            ViewData["StageId"] = new SelectList(_context.Stage, "StageId", "Name", result.StageId);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResultId,StageId,Time,BibNumberId")] Result result)
        {
            if (id != result.ResultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(result);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultExists(result.ResultId))
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
            ViewData["BibNumberId"] = new SelectList(_context.BibNumber, "BibNumberId", "Name", result.BibNumberId);
            ViewData["StageId"] = new SelectList(_context.Stage, "StageId", "Name", result.StageId);
            return View(result);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Result == null)
            {
                return NotFound();
            }

            var result = await _context.Result
                .Include(r => r.BibNumber)
                .Include(r => r.Stage)
                .FirstOrDefaultAsync(m => m.ResultId == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Result == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Result'  is null.");
            }
            var result = await _context.Result.FindAsync(id);
            if (result != null)
            {
                _context.Result.Remove(result);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultExists(int id)
        {
          return (_context.Result?.Any(e => e.ResultId == id)).GetValueOrDefault();
        }
    }
}
