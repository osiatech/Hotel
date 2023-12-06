using Hotel.Web.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Hotel.Application.Contracts;
using Hotel.Application.Dtos.Piso;
using Hotel.Application.Dtos.Categoria;

namespace Hotel.Web.Controllers
{
    public class PisoController : Controller
    {
        private readonly IPisoService pisoService;
        HttpClientHandler clientHandler = new HttpClientHandler();
        public PisoController(IPisoService pisoService)
        {
            this.pisoService = pisoService;
        }
        // GET: PisoController
        public ActionResult Index()
        {
            PisoListResponse pisoList = new PisoListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5212/api/Piso").Result)
                {

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        pisoList = JsonConvert.DeserializeObject<PisoListResponse>(apiResponse);
                    }
                }
            }
            return View(pisoList.data);
        }

        // GET: PisoController/Details/5
        public ActionResult Details(int id)
        {
            PisoDetailResponse pisoDetailResponse = new PisoDetailResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5212/api/Piso/GetPisoByPisoId?id={id}";
                using (var response = client.GetAsync(url).Result)
                {

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        pisoDetailResponse = JsonConvert.DeserializeObject<PisoDetailResponse>(apiResponse);
                    }
                }
            }
            return View(pisoDetailResponse.data);
        }

        // GET: PisoController/Create
        public ActionResult Create()
        {
           return View();
        }

        // POST: PisoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PisoDtoAdd pisoDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {
                    var url = $"http://localhost:5212/api/Piso/SavePiso";

                    pisoDtoAdd.ChangeDate = DateTime.Now;
                    pisoDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(pisoDtoAdd), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }

                        }
                        else
                        {
                            baseResponse.message = "Error conectandose al api.";
                            baseResponse.success = false;
                            ViewBag.Message = baseResponse.message;
                            return View();
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }

        // GET: PisoController/Edit/5
        public ActionResult Edit(int id)
        {
            PisoDetailResponse pisoDetailResponse = new PisoDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5212/api/Piso/GetPisoByPisoId?pisoId={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        pisoDetailResponse = JsonConvert.DeserializeObject<PisoDetailResponse>(apiResponse);

                    }
                }
            }

            return View(pisoDetailResponse.data);
        }

        // POST: PisoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PisoDtoUpdate pisoDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5212/api/Categoria/UpdateCategoria";

                    pisoDtoUpdate.ChangeDate = DateTime.Now;
                    pisoDtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(pisoDtoUpdate), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)

                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }

                        }
                        else
                        {
                            ViewBag.Message = baseResponse.message;
                            return View();
                        }
                    }
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }

        // GET: PisoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PisoController/Delete/5
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
