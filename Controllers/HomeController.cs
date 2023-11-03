using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CRUDelicioso.Models;

namespace CRUDelicioso.Controllers
{
    public class HomeController : Controller
    {
        private static List<Plato> ListaPlatos = new List<Plato>();

        public IActionResult Index()
        {
            var platosOrdenados = ListaPlatos.OrderByDescending(p => p.CreatedAt).ToList();
            return View(platosOrdenados);
        }

        private static int platoIdCounter = 1;


            [HttpPost]
        [Route("nuevo/plato")]
        public IActionResult AgregarPlato(Plato NuevoPlato)
        {
            if (ModelState.IsValid)
            {
                NuevoPlato.Id = platoIdCounter++; 
                NuevoPlato.CreatedAt = DateTime.Now;
                NuevoPlato.UpdatedAt = DateTime.Now;

                ListaPlatos.Add(NuevoPlato);
                return RedirectToAction("Index");
            }
            return View("FormularioPlato");
        }

                public IActionResult EditarPlato(int id)
        {
            var plato = ListaPlatos.FirstOrDefault(p => p.Id == id);
            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }

        public IActionResult FormularioPlato()
        {
            return View();
        }

        public IActionResult DetallesPlato(int id)
        {
            var plato = ListaPlatos.FirstOrDefault(p => p.Id == id);
            if (plato == null)
            {
                return NotFound();
            }
            return View(plato);
        }

            [HttpPost]
        public IActionResult EditarPlato(Plato plato)
        {
            if (ModelState.IsValid)
            {
              
                var platoExistente = ListaPlatos.FirstOrDefault(p => p.Id == plato.Id);
                if (platoExistente == null)
                {
                    return NotFound(); 
                }

              
                platoExistente.Name = plato.Name; 
                platoExistente.Chef = plato.Chef;
                platoExistente.Tastiness = plato.Tastiness;
                platoExistente.Calories = plato.Calories;
                platoExistente.Description = plato.Description;
                platoExistente.UpdatedAt = DateTime.Now;

                return RedirectToAction("Index");
            }

            return View("EditarPlato", plato);
        }

        public IActionResult EliminarPlato(int id)
        {
            var plato = ListaPlatos.FirstOrDefault(p => p.Id == id);
            if (plato == null)
            {
                return NotFound();
            }
            ListaPlatos.Remove(plato);
            return RedirectToAction("Index");
        }
    }
}
