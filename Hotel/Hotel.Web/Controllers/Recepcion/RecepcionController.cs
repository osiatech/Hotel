using Hotel.Application.Contracts;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Recepcion;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers.Recepcion
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
            var serviceResult = recepcionService.GetAll();

            if (!serviceResult.Success)
            {
                ViewBag.Messages = serviceResult.Message;
                return View();
            }
            return View(serviceResult.Data);
        }

        // GET: RecepcionController/Details/5
        public ActionResult Details(int id)
        {
            var serviceResult = recepcionService.GetById(id);

            if (!serviceResult.Success)
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
        public ActionResult Create(RecepcionDtoSave recepcionDtoSave)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = recepcionService.Save(recepcionDtoSave);

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

        // GET: RecepcionController/Edit/5
        public ActionResult Edit(int id)
        {
            var serviceResult = recepcionService.GetById(id);

            if (!serviceResult.Success)
            {
                ViewBag.Message = serviceResult.Message;
                return View();
            }
            var data = (RecepcionDtoGetAll)serviceResult.Data;
            RecepcionDtoUpdate clienteDtoUpdate = new RecepcionDtoUpdate()
            {
                IdRecepcion = data.IdRecepcion,
                FechaEntrada = data.FechaEntrada,
                FechaSalida = data.FechaSalida,
                FechaSalidaConfirmacion = data.FechaSalidaConfirmacion,
                PrecioInicial = data.PrecioInicial,
                Adelanto = data.Adelanto,
                PrecioRestante = data.PrecioRestante,
                TotalPagado = data.TotalPagado,
                CostoPenalidad = data.CostoPenalidad,
                Observacion = data.Observacion,
                FechaRegistro = data.FechaRegistro,
                FechaCreacion = data.FechaCreacion
            };
            return View(clienteDtoUpdate);
        }

        // POST: RecepcionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RecepcionDtoUpdate recepcionDtoUpdate)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult = recepcionService.Update(recepcionDtoUpdate);

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
    }
}
