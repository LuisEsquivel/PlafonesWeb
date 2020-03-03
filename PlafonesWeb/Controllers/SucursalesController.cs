using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PlafonesWeb.Models;

namespace PlafonesWeb.Controllers
{
    public class SucursalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sucursales
        public async Task<ActionResult> Index()
        {
            return View(await db.SucursalesModels.ToListAsync());
        }

        // GET: Sucursales/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalesModel sucursalesModel = await db.SucursalesModels.FindAsync(id);
            if (sucursalesModel == null)
            {
                return RedirectToAction("Index", "Home");        
            }
            return View(sucursalesModel);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

