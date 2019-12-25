using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Bageri_20.Models;
using C_Bageri_20.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace C_Bageri_20.Controllers
{
    // koppling till Model-klass Product
    public class ProductController : Controller
    {
        // access till klass Product via interfacet
        private readonly IProduct accessProdukt;

        // constructor, indata är av typ interface 
        // accessProdukt = lokal variabel
        // inAccessProdukt = inkommande data
        public ProductController(IProduct inAccessProdukt)
        {
            accessProdukt = inAccessProdukt;
        }

        // action-metod List returnerar till view List
        public ViewResult List()
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Bageri 2.0";

            // rubrik till webbsidan
            ViewBag.Rubrik = "Produktlista";
            //ViewBag.Message = "Welcome to Pie shop";

            // skapar en instans av klassen ProductListViewModel
            // urval: alla pajer
            ProductListViewModel ProduktLista = new ProductListViewModel();
            ProduktLista.Lista = accessProdukt.AllProducts;

            // skickar data till vyn List
            return View(ProduktLista);
        }

        // action-metod Detail returnerar till view Detail
        public IActionResult Detail(int id)
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Bageri 2.0";

            // rubrik till webbsidan
            ViewBag.Rubrik = "Produktdetalj";

            Product produkt = accessProdukt.GetProductById(id);
            if (produkt == null)
            {
                // 404 - not found
                return NotFound();
            }

            // skickar data till vyn Detail
            return View(produkt);
        }
    }
}