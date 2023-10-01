using Hotel.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    public class RecepcionController : Controller
    {
        private readonly IRecepcionRepository recepcionRepository;

        public RecepcionController(IRecepcionRepository recepcionRepository)
        {
            this.recepcionRepository = recepcionRepository;
        }
        // GET: RecepController
        public ActionResult Index()
        {
            var datos = this.recepcionRepository.GetRecepciones();
            return View(datos);
        }

        // GET: RecepController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RecepController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecepController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecepController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecepController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecepController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecepController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
