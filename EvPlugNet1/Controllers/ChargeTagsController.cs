using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvPlugNet1.Models;

namespace EvPlugNet1.Controllers
{
    public class ChargeTagsController : Controller
    {
        private readonly OCPPCoreContext _context;

        public ChargeTagsController(OCPPCoreContext context)
        {
            _context = context;
        }

        // GET: ChargeTags
        public async Task<IActionResult> Index()
        {
              return _context.ChargeTags != null ? 
                          View(await _context.ChargeTags.ToListAsync()) :
                          Problem("Entity set 'OCPPCoreContext.ChargeTags'  is null.");
        }

        // GET: ChargeTags/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ChargeTags == null)
            {
                return NotFound();
            }

            var chargeTag = await _context.ChargeTags
                .FirstOrDefaultAsync(m => m.TagId == id);
            if (chargeTag == null)
            {
                return NotFound();
            }

            return View(chargeTag);
        }

        // GET: ChargeTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChargeTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TagId,TagName,ParentTagId,ExpiryDate,Blocked")] ChargeTag chargeTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chargeTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chargeTag);
        }

        // GET: ChargeTags/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ChargeTags == null)
            {
                return NotFound();
            }

            var chargeTag = await _context.ChargeTags.FindAsync(id);
            if (chargeTag == null)
            {
                return NotFound();
            }
            return View(chargeTag);
        }

        // POST: ChargeTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TagId,TagName,ParentTagId,ExpiryDate,Blocked")] ChargeTag chargeTag)
        {
            if (id != chargeTag.TagId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chargeTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChargeTagExists(chargeTag.TagId))
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
            return View(chargeTag);
        }

        // GET: ChargeTags/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ChargeTags == null)
            {
                return NotFound();
            }

            var chargeTag = await _context.ChargeTags
                .FirstOrDefaultAsync(m => m.TagId == id);
            if (chargeTag == null)
            {
                return NotFound();
            }

            return View(chargeTag);
        }

        // POST: ChargeTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ChargeTags == null)
            {
                return Problem("Entity set 'OCPPCoreContext.ChargeTags'  is null.");
            }
            var chargeTag = await _context.ChargeTags.FindAsync(id);
            if (chargeTag != null)
            {
                _context.ChargeTags.Remove(chargeTag);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChargeTagExists(string id)
        {
          return (_context.ChargeTags?.Any(e => e.TagId == id)).GetValueOrDefault();
        }
    }
}
