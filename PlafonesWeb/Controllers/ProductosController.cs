
using PlafonesWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PlafonesWeb.Controllers
{
    public class ProductosController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
 

            // GET: Productos
            public async Task<ActionResult> Index(string Clase, string SubClase)
           {

            if (Clase == null)
            {
                return View(await db.ProductosModels.ToListAsync());
            }

            List<ProductosModels> products;

            if (SubClase == null)
            {
                products = await db.ProductosModels.Where(x => x.CVE_CLASE_VAR.Equals(Clase)).ToListAsync();
            }
            else
            {
                products = await db.ProductosModels.Where(x => x.CVE_CLASE_VAR.Equals(Clase) && x.CVE_SUBCLASE_VAR.Equals(SubClase)).ToListAsync();
            }



            if (products == null)
            {
                return RedirectToAction ("Index" , "Home");
            }

            return View(products);

        }

        public async Task<ActionResult> GetProductsMenu(String Clase)
        {
            ProductosModels Productos = await db.ProductosModels.FirstOrDefaultAsync(p => (p.CVE_CLASE_VAR.Equals(Clase)));
            if (Productos == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(Productos);
        }

        // GET: Productos/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosModels productosModel = await db.ProductosModels.FindAsync(id);
            if (productosModel == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(productosModel);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult DataSheet(FormCollection formCollection)
        {
            try
            {
                var fichaTecnicaName = formCollection["FichaTecnicaName"];

                if (fichaTecnicaName.Contains("?"))
                {
                    fichaTecnicaName = fichaTecnicaName.ToString().Replace('?', '″');
                }

                var fichaTecnicaPath = $"{ConfigurationManager.AppSettings["PathDataSheets"].ToString()}{fichaTecnicaName}";

                if (System.IO.File.Exists(fichaTecnicaPath))
                {
                    fichaTecnicaPath =  $"{ConfigurationManager.AppSettings["PathDataSheets"].ToString()}{"FichaNoDisponible.pdf"}";
                }

                TempData["fichaTecnicaPath"] = fichaTecnicaPath;

                ViewBag.fichaTecnicaPath = TempData["fichaTecnicaPath"];
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("DataSheet");

        }

    
        public async Task<ActionResult> GetProducts(FormCollection formCollection)
        {




            if (formCollection.Count > 0)
            {
                string searchFilter = formCollection[0];
                var Productos = await db.ProductosModels.Where(p => (p.CVE_PROD_VAR.Contains(searchFilter)
                            || p.NOM_PROD_VAR.Contains(searchFilter)
                            || p.DESC_PROD_VAR.Contains(searchFilter)))
                    .ToListAsync();


                if (Productos.Count == 0) 
                {
                    Productos = await db.ProductosModels.ToListAsync();
                    TempData["message"] = "PRODUCTO NO ENCONTRADO";
                    ViewBag.message = TempData["message"];
                }

                return View("Index", Productos);
            }
            else
            {
                return View("Index", db.ProductosModels.ToList());
            }
        }


    }

}
