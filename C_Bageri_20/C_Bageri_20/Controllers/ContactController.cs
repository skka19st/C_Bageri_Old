using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Bageri_20.Models;
using C_Bageri_20.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace C_Bageri_20.Controllers
{
    // koppling till Model-klass Contact
    public class ContactController : Controller
    {
        // access till klass Contact via interfacet
        private readonly IContact accessKontakt;

        // constructor, indata är av typ interface 
        // accessKontakt = lokal variabel
        // inAccessKontakt = inkommande data
        public ContactController(IContact inAccessKontakt)
        {
            accessKontakt = inAccessKontakt;
        }

        // action-metod Detail returnerar till view Detail
        public IActionResult Detail()
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Bageri 2.0";

            // rubrik till webbsidan
            ViewBag.Rubrik = "Kontakta oss";

            Contact kontakt = accessKontakt.GetContact();
            if (kontakt == null)
            {
                // 404 - not found
                return NotFound();
            }

            // skickar data till vyn Detail
            return View(kontakt);
        }
    }
}
