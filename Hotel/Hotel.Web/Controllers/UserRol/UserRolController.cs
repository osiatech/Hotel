using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.UserRol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers.UserRol
{
    public class UserRolController : Controller
    {
        private readonly IUserRolService userRolService;

        HttpClientHandler clientHandler = new HttpClientHandler();

        public UserRolController(IUserRolService userRolService)
        {
            this.userRolService = userRolService;
        }

        // GET: RoomController
        public ActionResult Index()
        {
            var serviceResult = this.userRolService.GetAll();

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
            var serviceResult = this.userRolService.GetById(id);

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
        public ActionResult Create(UserRolDtoAdd userRolDtoAdd)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = this.userRolService.Save(userRolDtoAdd);

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
            var serviceResult = this.userRolService.GetById(id);

            if (!serviceResult.Success)
            {
                ViewBag.Message = serviceResult.Message;
                return View();
            }
            var data = (UserRolDtoGetAll)serviceResult.Data;
            UserRolDtoUpdate roomDtoUpdate = new UserRolDtoUpdate()
            {
                IdUserRol = data.IdUserRol,
                RegistryDate = data.RegistryDate,
                Description = data.Description,
                Deleted = data.Deleted,
                Status = data.Status,
                ChangeDate = data.ChangeDate,
                IdUserModify = data.ChangeUser
            };
            return View(roomDtoUpdate);
        }


        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserRolDtoUpdate userRolDtoUpdate)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = this.userRolService.Update(userRolDtoUpdate);

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
