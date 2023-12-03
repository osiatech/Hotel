
using Hotel.Application.Contracts;
using Hotel.Application.Dtos.Cliente;
using Hotel.Web.Models.Responses.Base;
using Hotel.Web.Models.Responses.Cliente;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.Web.Controllers.Cliente
{
    public class ClienteHttpClientController : Controller
    {
        private readonly IClienteService clienteService;
        HttpClientHandler httpClientHandler = new HttpClientHandler();


        public ClienteHttpClientController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }


        // GET: ClienteHttpClientController
        public ActionResult Index()
        {
            ClienteListResponse clienteListResponse = new ClienteListResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler)) //HttpClient nos permite hacer llamadas a servicios Http, por ejemplo al servicio RESTful. Aca utilizamos using debido a que cuando hagamos una peticion (request) el objeto de HttpClient (httpClient) no se quede en memoria, sino que cuando hagamos la operacion (request) se destruya el objeto. ¿PERO POR QUE? -Situacion: imaginemos que tenemos una app, y nuestra app esta siendo utilizada por 10,000 users, lo que ocurriria seria que cada vez que uno de esos user haga un request no hayan 10,000 objetos en memoria, sino que una vez el usuario haga su request y reciba un response por parte del server, el objeto se destruya. So, en C# se utiliza el keyword 'using' para lograr lo ya mencionado.
            {
                var url = "http://localhost:5212/api/Cliente/GetAllClientes";

                using (var serverResponse = httpClient.GetAsync(url).Result) // '/Cliente/GetAllClientes' THIS IS THE ENDPOINT.
                {
                    if(serverResponse.IsSuccessStatusCode)
                    {
                        string apiResponse = serverResponse.Content.ReadAsStringAsync().Result; 
                        clienteListResponse = JsonConvert.DeserializeObject<ClienteListResponse>(apiResponse); //DeserializeObject: Esto lo que hace es que convierte el Json que llega aca a la clase que recibe DeserializeObject

                        if (!clienteListResponse.Success)
                            ViewBag.Message = clienteListResponse.Message; //ViewBag es una propieda dinamica, a esta se le agrega las propiedades que necesitamos 
                    }
                }
            }
            return View(clienteListResponse.Data);
        }


        // GET: ClienteHttpClientController/Details/5
        public ActionResult Details(int id)
        {
            ClienteDetailsResponse clienteDetailsResponse = new ClienteDetailsResponse();


            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5212/api/Cliente/GetClienteByClienteId?id={id}";

                using (var serverResponse = httpClient.GetAsync(url).Result)
                {
                    if (serverResponse.IsSuccessStatusCode)
                    {
                        string apiResponse = serverResponse.Content.ReadAsStringAsync().Result;
                        clienteDetailsResponse = JsonConvert.DeserializeObject<ClienteDetailsResponse>(apiResponse);

                        if (!clienteDetailsResponse.Success)
                            ViewBag.Message = clienteDetailsResponse.Message;
                          
                    }
                }
            }
            return View(clienteDetailsResponse.Data);
        }


        // GET: ClienteHttpClientController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: ClienteHttpClientController/Create
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


        // GET: ClienteHttpClientController/Edit/5
        public ActionResult Edit(int id)
        {
            ClienteDetailsResponse clienteDetailsResponse = new ClienteDetailsResponse();


            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5212/api/Cliente/GetClienteByClienteId?id={id}";

                using (var serverResponse = httpClient.GetAsync(url).Result)
                {
                    if (serverResponse.IsSuccessStatusCode)
                    {
                        string apiResponse = serverResponse.Content.ReadAsStringAsync().Result;

                        clienteDetailsResponse = JsonConvert.DeserializeObject<ClienteDetailsResponse>(apiResponse);

                        if (!clienteDetailsResponse.Success)
                            ViewBag.Message = clienteDetailsResponse.Message;
                    }
                }
            }
            return View(clienteDetailsResponse.Data);
        }


        // POST: ClienteHttpClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteDtoUpdate clienteDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using(var httpClient = new HttpClient (this.httpClientHandler))
                {
                    var url = $"http://localhost:5212/api/Cliente/UpdateCliente";

                    clienteDtoUpdate.ChangeDate = DateTime.Now;

                    clienteDtoUpdate.ChangeUser = 22;

                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(clienteDtoUpdate), System.Text.Encoding.UTF8,"application/json");

                    using(var serviceResponse = httpClient.PostAsync(url,stringContent).Result)
                    {
                        if(serviceResponse.IsSuccessStatusCode)
                        {
                            string apiResponse = serviceResponse.Content.ReadAsStringAsync().Result;
                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                            if (!baseResponse.Success)
                                ViewBag.Message = baseResponse.Message;
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
                        
            catch
            {
                ViewBag.Message = baseResponse.Message;
                return View();
            }
        }


        // GET: ClienteHttpClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteHttpClientController/Delete/5
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
