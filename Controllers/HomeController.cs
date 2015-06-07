using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaVistasDinamicas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult Jose()
        {
            return PartialView();
        }

        public ActionResult ShowEditForm()
        {
            return View(InMemoryStorage.templateCode);
        }

        public ActionResult ResetTemplate()
        {
            InMemoryStorage.SetDefaultTemplate();
            return RedirectToAction("Index");
        }

        [ValidateInput(false)]
        public ActionResult EditView(TemplateCodeModel templateCode)
        {
            InMemoryStorage.templateCode.Code = templateCode.Code;
            return RedirectToAction("Index");
        }
    }

    public static class InMemoryStorage
    {
        public const string defaultTemplate = "<h1>Hola Mostro</h1>";

        public static TemplateCodeModel templateCode;

        public static void SetDefaultTemplate()
        {
            templateCode.Code = defaultTemplate;
        }

        static InMemoryStorage()
        {
            templateCode = new TemplateCodeModel();
            SetDefaultTemplate();
        }
    }

    public class TemplateCodeModel
    {
        public string Code { get; set; }
    }
}
