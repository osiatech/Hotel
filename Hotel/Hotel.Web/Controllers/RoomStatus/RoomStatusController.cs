using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.RoomStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class RoomStatusController : Controller
    {
        private readonly IRoomStatusService roomStatusService;

        HttpClientHandler clientHandler = new HttpClientHandler();

        public RoomStatusController(IRoomStatusService roomStatusService)
        {
            this.roomStatusService = roomStatusService;
        }

        // GET: RoomStatusController
        public ActionResult Index()
        {
            var serviceResult = this.roomStatusService.GetAll();

            if (!serviceResult.Success)
            {
                ViewBag.Messages = serviceResult.Message;
                return View();
            }
            return View(serviceResult.Data);
        }

        // GET: RoomStatusController/Details/5
        public ActionResult Details(int id)
        {
            var serviceResult = this.roomStatusService.GetById(id);

            if (!serviceResult.Success)
            {
                ViewBag.Message = serviceResult.Message;
                return View();
            }
            return View(serviceResult.Data);
        }

        // GET: RoomStatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomStatusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomStatusDtoAdd roomStatusDtoAdd)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = this.roomStatusService.Save(roomStatusDtoAdd);

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

        // GET: RoomStatusController/Edit/5
        public ActionResult Edit(int id)
        {
            var serviceResult = this.roomStatusService.GetById(id);

            if (!serviceResult.Success)
            {
                ViewBag.Message = serviceResult.Message;
                return View();
            }
            var data = (RoomStatusDtoGetAll)serviceResult.Data;
            RoomStatusDtoUpdate roomDtoUpdate = new RoomStatusDtoUpdate()
            {
                RoomStatusId = data.IdRoomStatus,
                Description = data.Description,
                Status = data.Status,
                ChangeDate = data.ChangeDate,
                IdUserModify = data.ChangeUser,
                Deleted = data.Deleted
            };
            return View(roomDtoUpdate);
        }

        // POST: RoomStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomStatusDtoUpdate roomStatusDtoUpdate)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = this.roomStatusService.Update(roomStatusDtoUpdate);

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

        // GET: RoomStatusController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomStatusController/Delete/5
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
