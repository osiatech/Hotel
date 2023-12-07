using Hotel.Application.Contracts;
using Hotel.Application.Dtos.RoomStatus;
using Hotel.Web.Models.Responses;
using Hotel.Web.Models.RoomStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.Web.Controllers.RoomStatus
{
    public class RoomStatusHttpClientController : Controller
    {
        // GET: RoomStatusHttpClientController
        private readonly IRoomStatusService roomStatusService;
        HttpClientHandler httpClientHandler = new HttpClientHandler();


        public RoomStatusHttpClientController(IRoomStatusService roomStatusService)
        {
            this.roomStatusService = roomStatusService;
        }


        // GET: RecepcionWithHttpClientController
        public ActionResult Index()
        {
            RoomStatusListResponse roomStatusListResponse = new RoomStatusListResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var serverResponse = httpClient.GetAsync("http://localhost:5212/api/RoomStatus/GetRoomStatuses").Result)
                {
                    if (serverResponse.IsSuccessStatusCode)
                    {
                        string apiResponse = serverResponse.Content.ReadAsStringAsync().Result;
                        roomStatusListResponse = JsonConvert.DeserializeObject<RoomStatusListResponse>(apiResponse);

                        if (!roomStatusListResponse.success)
                        {
                            ViewBag.Message = roomStatusListResponse.message;
                            return View();
                        }

                    }
                    else
                    {
                        roomStatusListResponse.message = "Error al Conectarse a la API.";
                        ViewBag.Message = roomStatusListResponse.message;
                        return View();
                    }
                }
            }
            return View(roomStatusListResponse.data);
        }


        // GET: RecepcionWithHttpClientController/Details/5
        public ActionResult Details(int id)
        {
            RoomStatusDetailResponse roomStatusDetailResponse = new RoomStatusDetailResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5212/api/RoomStatus/GetRoomStatus?id={id}";

                using (var serverResponse = httpClient.GetAsync(url).Result)
                {
                    if (serverResponse.IsSuccessStatusCode)
                    {
                        string apiResponse = serverResponse.Content.ReadAsStringAsync().Result;

                        roomStatusDetailResponse = JsonConvert.DeserializeObject<RoomStatusDetailResponse>(apiResponse);

                        if (!roomStatusDetailResponse.success)
                        {
                            ViewBag.Message = roomStatusDetailResponse.message;
                            return View();
                        }

                    }
                    else
                    {
                        roomStatusDetailResponse.message = "Error al Conectarse a la API";
                        ViewBag.Message = roomStatusDetailResponse.message;
                        return View();
                    }
                }
            }
            return View(roomStatusDetailResponse.data);
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
            RoomStatusDetailResponse roomStatusDetailResponse = new RoomStatusDetailResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5212/api/RoomStatus/GetRoomStatus?id={id}";

                using (var serverResponse = httpClient.GetAsync(url).Result)
                {
                    if (serverResponse.IsSuccessStatusCode)
                    {
                        string apiResponse = serverResponse.Content.ReadAsStringAsync().Result;
                        roomStatusDetailResponse = JsonConvert.DeserializeObject<RoomStatusDetailResponse>(apiResponse);

                        if (!roomStatusDetailResponse.success)
                        {
                            ViewBag.Message = roomStatusDetailResponse.message;
                            return View();
                        }

                    }
                    else
                    {
                        roomStatusDetailResponse.message = "Error al Conectarse a la API";
                        ViewBag.Message = roomStatusDetailResponse.message;
                        return View();
                    }
                }
            }
            return View(roomStatusDetailResponse.data);
        }


        // POST: RecepcionWithHttpClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomStatusDtoUpdate roomStatusDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = $"http://localhost:5212/api/RoomStatus/UpdateRoomStatus";

                    roomStatusDtoUpdate.ChangeDate = DateTime.Now;
                    roomStatusDtoUpdate.ChangeUser = 3;

                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(roomStatusDtoUpdate), System.Text.Encoding.UTF8, "application/json");

                    using (var serviceResponse = httpClient.PostAsync(url, stringContent).Result)
                    {
                        if (serviceResponse.IsSuccessStatusCode)
                        {
                            string apiResponse = serviceResponse.Content.ReadAsStringAsync().Result;
                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }

                        }
                        else
                        {
                            baseResponse.message = "Error al Conectarse a la API";
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
    }
}
