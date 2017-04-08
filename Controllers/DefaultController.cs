using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Patacchiola.Patrik._5h.XMLWebAddRecord.Models;
using System.Web.Hosting;
using System.Xml.Linq;

namespace Patacchiola.Patrik._5h.XMLWebAddRecord.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

            string nomeFile = HostingEnvironment.MapPath(@"~/App_Data/Dati.xml");
            XElement data = XElement.Load(nomeFile);

            var persone = (from p in data.Element("persone").Elements("persona")
                           select new Persona(p));

            return View(persone);
        }
        public ActionResult AggiungiPersona()
        {
            return View();
        }

        public ActionResult Salva()
        {
            string nome = Request.Form["txtNome"];
            string cognome = Request.Form["txtCognome"];
            string stato = Request.Form["cmbStato"];

            if (nome == "" || cognome == "")
            {
                return RedirectToAction("AggiungiPersona", "Default");
            }

            XDocument doc = XDocument.Load(HostingEnvironment.MapPath(@"~/App_Data/Dati.xml"));

            XElement persona = new XElement("persona", "");

            XAttribute XNome = new XAttribute("Nome", nome);
            XAttribute XCognome = new XAttribute("Cognome", cognome);
            XAttribute XStato = new XAttribute("Stato", stato);

            persona.Add(XNome, XCognome, XStato);

            doc.Element("root").Element("persone").Add(persona);

            doc.Save(HostingEnvironment.MapPath(@"~/App_Data/Dati.xml"));

            return RedirectToAction("Index", "Default");
        }
    }
}