
using Hotel.Application.Contracts;
using Hotel.Web.Models.Responses.Recepcion;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.Web.Controllers.Recepcion
{
    public class RecepcionHttpClient : Controller
    {
        private readonly IRecepcionService recepcionService;
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public RecepcionHttpClient(IRecepcionService recepcionService)
        {
            this.recepcionService = recepcionService;
        }

        // GET: RecepcionWithHttpClientController
        public ActionResult Index()
        {
            RecepcionListResponse recepcionListResponse = new RecepcionListResponse();

            using(var httpClient = new HttpClient(this.httpClientHandler))
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
            RecepcionDetailsResponse recepcionDetailsResponse = new RecepcionDetailsResponse();

        
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5212/api/Recepcion/GetRecepcionByRecepcionId?IdRecepcion={id}";

                using (var serverResponse = httpClient.GetAsync(url).Result)
                {
                    if (serverResponse.IsSuccessStatusCode)
                    {
                        string apiResponse = serverResponse.Content.ReadAsStringAsync().Result;

                        recepcionDetailsResponse = JsonConvert.DeserializeObject<RecepcionDetailsResponse>(apiResponse);

                        if (!recepcionDetailsResponse.Success)
                            ViewBag.Message = recepcionDetailsResponse.Messages;
                    }
                }
            }
            return View(recepcionDetailsResponse.Data);
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
