using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExercicioFuncionario.Controllers
{
    public class FuncionarioController : Controller
    {
        private FuncionarioRepository _repository { get; set; }

        public FuncionarioController()
        {
            _repository = new FuncionarioRepository();
        }

        public ActionResult Index()
        {
            var funcionarios = _repository.ObterTodos();
            ViewBag.Funcionarios = funcionarios;
            return View();
        }

        public ActionResult Cadastro()
        {
            List<Privilegio> privilegios = new PrivilegioRepository().ObterTodos();
            ViewBag.Privilegios = privilegios;
            return View();
        }

        public ActionResult Store (Funcionario funcionario)
        {
            _repository.Inserir(funcionario);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _repository.Apagar(id);
            
            return RedirectToAction("Index");
        }
        

    }
}