﻿
using Hotel.Application.Contracts;
using Hotel.Application.Dtos.Recepcion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class RecepcionController : Controller
    {
        private readonly IRecepcionService recepcionService;

        public RecepcionController(IRecepcionService recepcionService)
        {
            this.recepcionService = recepcionService;
        }

        // GET: RecepcionController
        public ActionResult Index()
        {
            var serviceResult = this.recepcionService.GetAll();

            if(!serviceResult.Success)
            {
                ViewBag.Message = serviceResult.Message; //ViewBag es parte de ASP.NET MVC. Este es una variable del tipo dynamic lo cual hace que se se vaya construyendo apartir de las diferentes propiedades que le pasemos o asignemos
                return View();
            }
            return View(serviceResult.Data);
        }

        // GET: RecepcionController/Details/5
        public ActionResult Details(int id)
        {
            var serviceResult = this.recepcionService.GetById(id);

            if(!serviceResult.Success)
            {
                ViewBag.Message = serviceResult.Message;
                return View();
            }
            return View(serviceResult.Data);
        }

        // GET: RecepcionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecepcionController/Create
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

        // GET: RecepcionController/Edit/5
        public ActionResult Edit(int id)
        {
            var serviceResult = this.recepcionService.GetById(id);

            if(!serviceResult.Success)
            {
                ViewBag.Message = serviceResult.Message;
                return View();
            }
            var data = (RecepcionDtoGetAll)serviceResult.Data;
            RecepcionDtoUpdate recepcionDtoUpdate = new RecepcionDtoUpdate()
            {
                IdRecepcion = data.IdRecepcion,
                FechaEntrada = data.FechaEntrada,
                FechaSalida = data.FechaSalida,
                FechaSalidaConfirmacion = data.FechaSalidaConfirmacion,
                PrecioInicial = data.PrecioInicial,
                Adelanto = data.Adelanto,
                PrecioRestante = data.PrecioRestante,
                TotalPagado  = data.TotalPagado,
                CostoPenalidad = data.CostoPenalidad,
                Observacion = data.Observacion,
                FechaRegistro = data.FechaRegistro
            };
            return View(recepcionDtoUpdate);
        }

        // POST: RecepcionController/Edit/5
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

        // GET: RecepcionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecepcionController/Delete/5
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