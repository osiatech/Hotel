
using Hotel.Application.Contracts;
using Hotel.Web.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.Web.Controllers.Recepcion
{
    public class RecepcionHttpClient : Controller
    {
        private readonly IRecepcionService recepcionService;
        HttpClientHandler httpClintHandler = new HttpClientHandler();

        public RecepcionHttpClient(IRecepcionService recepcionService)
        {
            this.recepcionService = recepcionService;
        }

        // GET: RecepcionWithHttpClientController
        public ActionResult Index()
        {
            RecepcionListResponse recepcionListResponse = new RecepcionListResponse();

            using(var httpClient = new HttpClient(this.httpClintHandler))
            {
                using(var serverResponse = httpClient.GetAsync("http://localhost:5212/api/Recepcion/GetAllRecepciones").Result)
                {
                    if(serverResponse.IsSuccessStatusCode)
                    {
                        string apiResponse = serverResponse.Content.ReadAsStringAsync().Result;
                        recepcionListResponse = JsonConvert.DeserializeObject<RecepcionListResponse>(apiResponse);
                    }
                }
            }
            return View(recepcionListResponse.Data);
        }

        // GET: RecepcionWithHttpClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RecepcionWithHttpClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecepcionWithHttpClientController/Create
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

        // GET: RecepcionWithHttpClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecepcionWithHttpClientController/Edit/5
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

        // GET: RecepcionWithHttpClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecepcionWithHttpClientController/Delete/5
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
