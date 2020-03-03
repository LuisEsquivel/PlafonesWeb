using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlafonesWeb.Controllers
{
    public class HomeController : Controller
    {

        private Generals generals;

        public HomeController()
        {
            generals = new Generals();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Email(FormCollection formCollection)
        {
            try
            {

                if (generals.SendEmailSMTP(formCollection))
                {
                    TempData["message"] = "Correo Enviado";
                    ViewBag.message = TempData["message"];
                }
                else
                {
                    TempData["message"] = "Problema al enviar correo";
                    ViewBag.message = TempData["message"];
                }

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Index");
        }


        public ActionResult NoticeOfPrivace()
        {
            try
            {
                return View("NoticeOfPrivace");
            }catch(Exception EX)
            {
                return View("Index");
            }
            
        }


        //validar URL y retornar al home
        public ActionResult NotFound()
        {
            ActionResult result;

            object model = Request.Url.PathAndQuery;

            if (!Request.IsAjaxRequest())
                result = RedirectToAction("Index", "Home");
            else
                result = View(model);


            return result;
        }

    }
}
