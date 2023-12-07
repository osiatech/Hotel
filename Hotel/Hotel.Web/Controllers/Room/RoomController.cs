using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Room;
using Hotel.Web.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;



namespace Hotel.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;

        HttpClientHandler clientHandler = new HttpClientHandler();

        public RoomController(IRoomService roomService)
        {   
            this.roomService = roomService;
        }

        // GET: RoomController
        public ActionResult Index()
        {
            var serviceResult = this.roomService.GetAll();

            if (!serviceResult.Success)
            {
                ViewBag.Messages = serviceResult.Message;
                return View();
            }
            return View(serviceResult.Data);
        }

        // GET: RoomController/Details/5
        public ActionResult Details(int id)
        {
            var serviceResult = this.roomService.GetById(id);

            if (!serviceResult.Success)
            {
                ViewBag.Message = serviceResult.Message;
                return View();
            }
            return View(serviceResult.Data);
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
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = this.roomService.Save(roomDtoAdd);

                if (!serviceResult.Success)
                {
                    ViewBag.Message = serviceResult.Message;
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = serviceResult.Message;
                return View();
            }
        }

        // GET: RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            var serviceResult = this.roomService.GetById(id);

            if (!serviceResult.Success)
            {
                ViewBag.Message = serviceResult.Message;
                return View();
            }
            var data = (RoomDtoGetAll)serviceResult.Data;
            RoomDtoUpdate roomDtoUpdate = new RoomDtoUpdate()
            {
                IdRoom = data.IdRoom,
                Details = data.Details,
                Status = data.Status,
                Deleted = data.Deleted,
                Number = data.Number,
                Price = data.Price,
                RegistryDate = data.ChangeDate,
                IdUserModify = data.ChangeUser
            };
            return View(roomDtoUpdate);
        }


        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomDtoUpdate roomDtoUpdate)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = this.roomService.Update(roomDtoUpdate);

                if (!serviceResult.Success)
                {
                    ViewBag.Message = serviceResult.Message;
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = serviceResult.Message;
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
