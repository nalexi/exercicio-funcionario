using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExercicioFuncionario.Controllers
{
    public class PrivilegioController : Controller
    {
        private PrivilegioRepository _repository { get; set; }

        public PrivilegioController()
        {
            _repository = new PrivilegioRepository();
        }

        public ActionResult Index()
        {
            var privilegios = _repository.ObterTodos();
            ViewBag.Privilegios = privilegios;
            return View();
        }

        [HttpGet]
        public JsonResult ObterTodosParaJson()
        {
            object privilegios = new PrivilegioRepository().ObterTodosParaJson();
            return Json(new { results = privilegios }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Cadastro()
        {
            List<Privilegio> privilegios = new PrivilegioRepository().ObterTodos();
            ViewBag.Privilegios = privilegios;
            return View();
        }

        public ActionResult Store(Privilegio privilegio)
        {
            _repository.Inserir(privilegio);
            return RedirectToAction("Index");
            
        }

        public ActionResult Delete(int id)
        {
            _repository.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}