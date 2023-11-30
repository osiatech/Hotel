
using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Cliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            var serviceResult = this.clienteService.GetAll();

            if(!serviceResult.Success)
            {
                ViewBag.Messages = serviceResult.Message;
                return View();
            }
            return View(serviceResult.Data);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            var serviceResult = this.clienteService.GetById(id);

            if(!serviceResult.Success)
            {
                ViewBag.Message = serviceResult.Message;
                return View();
            }
            return View(serviceResult.Data);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteDtoSave clienteDtoSave)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = this.clienteService.Save(clienteDtoSave);

                if(!serviceResult.Success)
                {
                    ViewBag.Message =serviceResult.Message;
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

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            var serviceResult = this.clienteService.GetById(id);

            if(!serviceResult.Success)
            {
                ViewBag.Message = serviceResult.Message;
                return View();
            }
            var data = (ClienteDtoGetAll)serviceResult.Data;
            ClienteDtoUpdate clienteDtoUpdate = new ClienteDtoUpdate()
            {
                IdCliente = data.IdCliente,
                NombreCompleto = data.NombreCompleto,
                Correo = data.Correo,
                TipoDocumento = data.TipoDocumento,
                Documento = data.Documento,
                FechaRegistro = data.FechaRegistro
            };
            return View(clienteDtoUpdate);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteDtoUpdate clienteDtoUpdate)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = this.clienteService.Update(clienteDtoUpdate);

                if(!serviceResult.Success)
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
