using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C_Bageri_20.Models;
using C_Bageri_20.ViewModels;

namespace C_Bageri_20.Controllers
{
    // hemsida/huvudsida
    // visar produkt-info
    public class HomeController : Controller
    {
        // access till klass Product via interfacet
        private readonly IProduct accessProdukt;

        // constructor, indata är av typ interface 
        // accessProdukt = lokal variabel
        // inAccessProdukt = inkommande data
        public HomeController(IProduct inAccessProdukt)
        {
            accessProdukt = inAccessProdukt;
        }

        // action-metod Index returnerar till view Index
        public IActionResult Index()
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Bageri 2.0";

            // rubrik till webbsidan
            ViewBag.Rubrik = "Välkommen till ditt bageri på nätet!";


            // skapar en instans av klassen HostViewModel
            // urval: alla pajer
            HomeViewModel ProduktLista = new HomeViewModel();
            ProduktLista.Lista = accessProdukt.AllProducts;

            // skickar data till vyn Index
            return View(ProduktLista);
        }
    }
}
