using EvPlugNet1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvPlugNet1.Controllers
{
    public class LocationsController : Controller
    {



        private readonly OCPPCoreContext _context;

        public LocationsController(OCPPCoreContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {

            // Nodes2charger


            
            return View(await _context.Nodes2chargers.ToListAsync());



            //var oCPPCoreContext = _context.Nodes.Join(_context.UserChargers, no => no.ChargePointId, uc => uc.ChargePointId, (no, uc) => no);

            //var test = await oCPPCoreContext.ToListAsync();


            //return View(test);
            
            
            
            //return View(await oCPPCoreContext.ToListAsync());

            //clhr.cleaningCycles = await (db.CleaningCycles
            //    .Join(db.Properties, cc => cc.propertyFK, pr => pr.id, (cc, pr) => cc)
            //    .Where(a => a.Property.siteFK == clhr.curSite.id)
            //    .OrderByDescending(item => item.arrivalDate).Take(100).ToListAsync());



        }
    }
}
