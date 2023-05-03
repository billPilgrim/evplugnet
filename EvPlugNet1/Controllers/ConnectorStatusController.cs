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
    public class ConnectorStatusController : Controller
    {
        private readonly OCPPCoreContext _context;

        public ConnectorStatusController(OCPPCoreContext context)
        {
            _context = context;
        }

        // GET: ConnectorStatus
        public async Task<IActionResult> Index()
        {
              return _context.ConnectorStatuses != null ? 
                          View(await _context.ConnectorStatuses.ToListAsync()) :
                          Problem("Entity set 'OCPPCoreContext.ConnectorStatuses'  is null.");
        }

        // GET: ConnectorStatus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ConnectorStatuses == null)
            {
                return NotFound();
            }

            var connectorStatus = await _context.ConnectorStatuses
                .FirstOrDefaultAsync(m => m.ChargePointId == id);
            if (connectorStatus == null)
            {
                return NotFound();
            }

            return View(connectorStatus);
        }

        // GET: ConnectorStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConnectorStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChargePointId,ConnectorId,ConnectorName,LastStatus,LastStatusTime,LastMeter,LastMeterTime")] ConnectorStatus connectorStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(connectorStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(connectorStatus);
        }

        // GET: ConnectorStatus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ConnectorStatuses == null)
            {
                return NotFound();
            }

            var connectorStatus = await _context.ConnectorStatuses.FindAsync(id);
            if (connectorStatus == null)
            {
                return NotFound();
            }
            return View(connectorStatus);
        }

        // POST: ConnectorStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ChargePointId,ConnectorId,ConnectorName,LastStatus,LastStatusTime,LastMeter,LastMeterTime")] ConnectorStatus connectorStatus)
        {
            if (id != connectorStatus.ChargePointId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(connectorStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConnectorStatusExists(connectorStatus.ChargePointId))
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
            return View(connectorStatus);
        }

        // GET: ConnectorStatus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ConnectorStatuses == null)
            {
                return NotFound();
            }

            var connectorStatus = await _context.ConnectorStatuses
                .FirstOrDefaultAsync(m => m.ChargePointId == id);
            if (connectorStatus == null)
            {
                return NotFound();
            }

            return View(connectorStatus);
        }

        // POST: ConnectorStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ConnectorStatuses == null)
            {
                return Problem("Entity set 'OCPPCoreContext.ConnectorStatuses'  is null.");
            }
            var connectorStatus = await _context.ConnectorStatuses.FindAsync(id);
            if (connectorStatus != null)
            {
                _context.ConnectorStatuses.Remove(connectorStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConnectorStatusExists(string id)
        {
          return (_context.ConnectorStatuses?.Any(e => e.ChargePointId == id)).GetValueOrDefault();
        }
    }
}
