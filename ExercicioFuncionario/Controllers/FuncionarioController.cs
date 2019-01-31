using ViewModel;
using Models;
using Newtonsoft.Json;
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

        [HttpGet]
        public ActionResult Index()
        {   
            return View();
        }

        [HttpGet]
        public JsonResult ObterDataTable(int idPrivilegio, int start, int length, Dictionary<string, string> search,
            Dictionary<string, Dictionary<string, string>> order, int draw)
        {
            var funcionarios = _repository.ObterParaDataTable(idPrivilegio, start, length, search, order);
            var quantidadeTotal = _repository.ContabilizarTotalDataTable();
            var quantidadeFiltrado = _repository.ContabilizarFiltradoDataTable(idPrivilegio, search);

            var retorno = new
            {
                draw = draw,
                data = funcionarios,
                recordsTotal = quantidadeTotal,
                recordsFiltered = quantidadeFiltrado
            };

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            FuncionarioViewModel funcionario = new FuncionarioViewModel();
            ViewBag.Funcionario = funcionario;
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(FuncionarioViewModel funcionario)
        {
            if (ModelState.IsValid)
            {
                Funcionario funcionarioDestino = new Funcionario();
                funcionarioDestino.Nome = funcionario.Nome; 
                funcionarioDestino.Salario = funcionario.Salario; 
                funcionarioDestino.PrivilegioId = funcionario.PrivilegioId; 
                funcionarioDestino.RegistroAtivo = true;
                _repository.Inserir(funcionarioDestino);
                return RedirectToAction("Index");
            }
            ViewBag.Funcionario = funcionario;
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _repository.Apagar(id);
            var retorno = new { status = "ok" };
            var json = JsonConvert.SerializeObject(retorno);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Funcionario funcionario)
        {
            Funcionario funcionarioPrincipal = _repository.ObterPeloId(funcionario.Id);
            funcionarioPrincipal.PrivilegioId = funcionario.PrivilegioId;
            funcionarioPrincipal.Nome = funcionario.Nome;
            funcionarioPrincipal.Login = funcionario.Login;
            funcionarioPrincipal.Senha = funcionario.Senha;
            funcionarioPrincipal.Sexo = funcionario.Sexo;
            funcionarioPrincipal.Salario  = funcionario.Salario;
            _repository.Alterar(funcionarioPrincipal);
            return Json(JsonConvert.SerializeObject(funcionarioPrincipal));
        }

        [HttpGet]
        public ActionResult ObterPeloId(int id)
        {
            var fruta = _repository.ObterPeloId(id);
            var json = JsonConvert.SerializeObject(fruta);
            return Json(json, JsonRequestBehavior.AllowGet);
        }


    }
}