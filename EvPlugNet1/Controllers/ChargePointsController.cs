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
    public class ChargePointsController : Controller
    {
        private readonly OCPPCoreContext _context;

        public ChargePointsController(OCPPCoreContext context)
        {
            _context = context;
        }

        // GET: ChargePoints
        public async Task<IActionResult> Index()
        {
              return _context.ChargePoints != null ? 
                          View(await _context.ChargePoints.ToListAsync()) :
                          Problem("Entity set 'OCPPCoreContext.ChargePoints'  is null.");
        }

        // GET: ChargePoints/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ChargePoints == null)
            {
                return NotFound();
            }

            var chargePoint = await _context.ChargePoints
                .FirstOrDefaultAsync(m => m.ChargePointId == id);
            if (chargePoint == null)
            {
                return NotFound();
            }

            return View(chargePoint);
        }

        // GET: ChargePoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChargePoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChargePointId,Name,Comment,Username,Password,ClientCertThumb")] ChargePoint chargePoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chargePoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chargePoint);
        }

        // GET: ChargePoints/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ChargePoints == null)
            {
                return NotFound();
            }

            var chargePoint = await _context.ChargePoints.FindAsync(id);
            if (chargePoint == null)
            {
                return NotFound();
            }
            return View(chargePoint);
        }

        // POST: ChargePoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ChargePointId,Name,Comment,Username,Password,ClientCertThumb")] ChargePoint chargePoint)
        {
            if (id != chargePoint.ChargePointId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chargePoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChargePointExists(chargePoint.ChargePointId))
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
            return View(chargePoint);
        }

        // GET: ChargePoints/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ChargePoints == null)
            {
                return NotFound();
            }

            var chargePoint = await _context.ChargePoints
                .FirstOrDefaultAsync(m => m.ChargePointId == id);
            if (chargePoint == null)
            {
                return NotFound();
            }

            return View(chargePoint);
        }

        // POST: ChargePoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ChargePoints == null)
            {
                return Problem("Entity set 'OCPPCoreContext.ChargePoints'  is null.");
            }
            var chargePoint = await _context.ChargePoints.FindAsync(id);
            if (chargePoint != null)
            {
                _context.ChargePoints.Remove(chargePoint);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChargePointExists(string id)
        {
          return (_context.ChargePoints?.Any(e => e.ChargePointId == id)).GetValueOrDefault();
        }
    }
}
