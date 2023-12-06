using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Hotel.Application.Dtos.Categoria;
using Hotel.Web.Models.Responses;

namespace Hotel.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService categoriaService;
        HttpClientHandler clientHandler = new HttpClientHandler();
        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }
        // GET: CategoriaController
        public ActionResult Index()
        {
            CategoriaListResponse categoriaList = new CategoriaListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5212/api/Categoria/GetCategoria").Result)
                {

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        categoriaList = JsonConvert.DeserializeObject<CategoriaListResponse>(apiResponse);
                    }
                }
            }
            return View(categoriaList.data);
        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {
            CategoriaDetailResponse categoriaDetailResponse = new CategoriaDetailResponse();


            using (var httpClient = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5212/api/Categoria/GetCategoriaByCategoriaId?id={id}";

                using (var serverResponse = httpClient.GetAsync(url).Result)
                {
                    if (serverResponse.IsSuccessStatusCode)
                    {
                        string apiResponse = serverResponse.Content.ReadAsStringAsync().Result;
                        categoriaDetailResponse = JsonConvert.DeserializeObject<CategoriaDetailResponse>(apiResponse);

                        if (!categoriaDetailResponse.success)
                        {
                            ViewBag.Message = categoriaDetailResponse.message;
                            return View();
                        }

                    }
                    else
                    {
                        categoriaDetailResponse.message = "Error al Conectarse a la API";
                        ViewBag.Message = categoriaDetailResponse.message;
                        return View();
                    }
                }
            }
            return View(categoriaDetailResponse.data);
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaDtoAdd categoriaDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {
                    var url = $"http://localhost:5212/api/Categoria/SaveCategoria";

                    categoriaDtoAdd.ChangeDate = DateTime.Now;
                    categoriaDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(categoriaDtoAdd), System.Text.Encoding.UTF8, "application/json");

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

        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriaDetailResponse categoriaDetailResponse = new CategoriaDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5212/api/Categoria/GetCategoriaByCategoriaId?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        categoriaDetailResponse = JsonConvert.DeserializeObject<CategoriaDetailResponse>(apiResponse);

                    }
                }
            }

            return View(categoriaDetailResponse.data);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaDtoUpdate categoriaDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5212/api/Categoria/UpdateCategoria";

                    categoriaDtoUpdate.ChangeDate = DateTime.Now;
                    categoriaDtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(categoriaDtoUpdate), System.Text.Encoding.UTF8, "application/json");

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

        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriaController/Delete/5
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
