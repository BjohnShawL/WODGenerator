using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WODGenerator.Models;

namespace WODGenerator.Controllers
{
    public enum Species
    {
        Werewolf = 1,
        Vampire = 2,
        Mage = 3,
        Human = 0
    }

    public class CharactersController : Controller
    {
        private readonly OWOD_genContext _context;

        public CharactersController(OWOD_genContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            var oWOD_genContext = _context.Characters.Include(c => c.Abl).Include(c => c.Attrib).Include(c => c.Game).Include(c => c.Loc);
            return View(await oWOD_genContext.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characters = await _context.Characters
                .Include(c => c.Abl)
                .Include(c => c.Attrib)
                .Include(c => c.Game)
                .Include(c => c.Loc)
                .SingleOrDefaultAsync(m => m.CharId == id);
            if (characters == null)
            {
                return NotFound();
            }

            return View(characters);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            ViewData["AblId"] = new SelectList(_context.Abilities, "AblId", "AblId");
            ViewData["AttribId"] = new SelectList(_context.Attributes, "AttribId", "AttribId");
            ViewData["GameId"] = new SelectList(_context.GameCampaign, "GameId", "GameId");
            ViewData["LocId"] = new SelectList(_context.Locations, "LocId", "LocId");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharId,Name,Alignment,Age,Gender,Species,LocId,Inventory,PlotHook,GameId,AttribId,AblId")] Characters characters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(characters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AblId"] = new SelectList(_context.Abilities, "AblId", "AblId", characters.AblId);
            ViewData["AttribId"] = new SelectList(_context.Attributes, "AttribId", "AttribId", characters.AttribId);
            ViewData["GameId"] = new SelectList(_context.GameCampaign, "GameId", "GameId", characters.GameId);
            ViewData["LocId"] = new SelectList(_context.Locations, "LocId", "LocId", characters.LocId);
            return View(characters);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characters = await _context.Characters.SingleOrDefaultAsync(m => m.CharId == id);
            if (characters == null)
            {
                return NotFound();
            }
            ViewData["AblId"] = new SelectList(_context.Abilities, "AblId", "AblId", characters.AblId);
            ViewData["AttribId"] = new SelectList(_context.Attributes, "AttribId", "AttribId", characters.AttribId);
            ViewData["GameId"] = new SelectList(_context.GameCampaign, "GameId", "GameId", characters.GameId);
            ViewData["LocId"] = new SelectList(_context.Locations, "LocId", "LocId", characters.LocId);
            return View(characters);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharId,Name,Alignment,Age,Gender,Species,LocId,Inventory,PlotHook,GameId,AttribId,AblId")] Characters characters)
        {
            if (id != characters.CharId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharactersExists(characters.CharId))
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
            ViewData["AblId"] = new SelectList(_context.Abilities, "AblId", "AblId", characters.AblId);
            ViewData["AttribId"] = new SelectList(_context.Attributes, "AttribId", "AttribId", characters.AttribId);
            ViewData["GameId"] = new SelectList(_context.GameCampaign, "GameId", "GameId", characters.GameId);
            ViewData["LocId"] = new SelectList(_context.Locations, "LocId", "LocId", characters.LocId);
            return View(characters);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characters = await _context.Characters
                .Include(c => c.Abl)
                .Include(c => c.Attrib)
                .Include(c => c.Game)
                .Include(c => c.Loc)
                .SingleOrDefaultAsync(m => m.CharId == id);
            if (characters == null)
            {
                return NotFound();
            }

            return View(characters);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var characters = await _context.Characters.SingleOrDefaultAsync(m => m.CharId == id);
            _context.Characters.Remove(characters);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharactersExists(int id)
        {
            return _context.Characters.Any(e => e.CharId == id);
        }
    }
}
