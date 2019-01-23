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
    }
}