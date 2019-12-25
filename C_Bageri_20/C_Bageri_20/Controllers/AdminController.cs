using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C_Bageri_20.Models;
using C_Bageri_20.ViewModels;

namespace C_Bageri_20.Controllers
{
    // admin-sida
    public class AdminController : Controller
    {
        // access till klass Product via interfacet
        private readonly IProduct accessProdukt;

        // constructor, indata är av typ interface 
        // accessProdukt = lokal variabel
        // inAccessProdukt = inkommande data
        public AdminController(IProduct inAccessProdukt)
        {
            accessProdukt = inAccessProdukt;
        }

        // action-metod List returnerar till view List
        public ViewResult List()
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Bageri 2.0";

            // rubrik till webbsidan
            ViewBag.Rubrik = "Produktlista Uppdatering";

            // skapar en instans av klassen ProductListViewModel
            // urval: alla pajer
            ProductListViewModel ProduktLista = new ProductListViewModel();
            ProduktLista.Lista = accessProdukt.AllProducts;

            // skickar data till vyn List
            return View(ProduktLista);
        }

        // action-metod Edit returnerar till view Edit
        public IActionResult Edit(int id)
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Bageri 2.0";

            // rubrik till webbsidan
            ViewBag.Rubrik = "Uppdatera";

            Product produkt = accessProdukt.GetProductById(id);
            if (produkt == null)
            {
                // 404 - not found
                return NotFound();
            }

            // skickar data till vyn Edit
            return View(produkt);
        }
    }
}
