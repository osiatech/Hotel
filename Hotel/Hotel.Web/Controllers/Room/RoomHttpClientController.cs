using Hotel.Application.Contracts;
using Hotel.Application.Dtos.Room;
using Hotel.Web.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.Web.Controllers
{
    public class RoomHttpClientController : Controller
    {
        private readonly IRoomService roomService;

        HttpClientHandler clientHandler = new HttpClientHandler();

        public RoomHttpClientController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        // GET: RoomController
        public ActionResult Index()
        {
            RoomListResponse roomList = new RoomListResponse();


            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5212/api/Room/GetRooms").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        roomList = JsonConvert.DeserializeObject<RoomListResponse>(apiResponse);

                        if (!roomList.success)
                        {
                            ViewBag.Message = roomList.message;
                            return View();
                        }


                    }
                    else
                    {
                        roomList.message = "Error conectandose al api.";
                        roomList.success = false;
                        ViewBag.Message = roomList.message;
                        return View();
                    }
                }
            }
            return View(roomList.data);
        }

        // GET: RoomController/Details/5
        public ActionResult Details(int id)
        {
            RoomDetailResponse roomDetailResponse = new RoomDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5212/api/Room/GetRoom?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        roomDetailResponse = JsonConvert.DeserializeObject<RoomDetailResponse>(apiResponse);

                    }
                }
            }

            return View(roomDetailResponse.data);
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomDtoAdd roomDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {
                    var url = $"http://localhost:5212/api/Room/SaveRoom";

                    roomDtoAdd.ChangeDate = DateTime.Now;
                    roomDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(roomDtoAdd), System.Text.Encoding.UTF8, "application/json");

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

        // GET: RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            RoomDetailResponse roomDetailResponse = new RoomDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5212/api/Room/GetRoom?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        roomDetailResponse = JsonConvert.DeserializeObject<RoomDetailResponse>(apiResponse);

                    }
                }
            }

            return View(roomDetailResponse.data);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomDtoUpdate roomDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5212/api/Room/UpdateRoom";

                    roomDtoUpdate.ChangeDate = DateTime.Now;
                    roomDtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(roomDtoUpdate), System.Text.Encoding.UTF8, "application/json");

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


        // GET: RoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomController/Delete/5
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
