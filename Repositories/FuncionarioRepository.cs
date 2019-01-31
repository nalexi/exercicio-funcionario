using Models;
using Repositories.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FuncionarioRepository
    {
        private readonly FuncionarioContext _context;

        public FuncionarioRepository()
        {
            _context = new FuncionarioContext();
        }

        public List<Funcionario> ObterTodos()
        {
            List<Funcionario> funcionarios = _context.Funcionarios.Where(x => x.RegistroAtivo == true).ToList();
            return funcionarios;
        }

        public Funcionario ObterPeloId(int id)
        {
            var func = _context.Funcionarios.FirstOrDefault(x => x.Id == id && x.RegistroAtivo);
            return func;
        }

        public Funcionario Inserir(Funcionario funcionario)
        {
            funcionario.RegistroAtivo = true;
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return funcionario;
        }

        public List<Funcionario> ObterParaDataTable(int idPrivilegio, int start, int length, Dictionary<string, string> search,
            Dictionary<string, Dictionary<string, string>> order)
        {
            var query = _context.Funcionarios.Where(x => x.RegistroAtivo).AsQueryable();

            if(idPrivilegio != Privilegio.FiltroApresentarTodos)
            {
                query = query.Where(x => x.PrivilegioId == idPrivilegio);
            }

            query = OrdenacaoDatatable(order, query);
            query = BuscaDataTable(search, query);

            return query.Skip(start).Take(length).ToList();
        }

        public object ContabilizarFiltradoDataTable(int idPrivilegio, Dictionary<string, string> search)
        {
            var query = _context.Funcionarios.Where(x => x.RegistroAtivo && x.PrivilegioId == idPrivilegio).AsQueryable();

            if (idPrivilegio != Privilegio.FiltroApresentarTodos)
            {
                query = query.Where(x => x.PrivilegioId == idPrivilegio);
            }

            query = BuscaDataTable(search, query);
            return query.Count();
        }

        public object ContabilizarTotalDataTable()
        {
            return _context.Funcionarios.Count(x => x.RegistroAtivo);
        }

        private IQueryable<Funcionario> BuscaDataTable(Dictionary<string, string> search, IQueryable<Funcionario> query)
        {
            var busca = search["value"];
            if (busca != "")
            {
                query = query.Where(x => x.Privilegio.Nome.Contains(busca) || (x.Nome.Contains(busca)));
            }
            return query;
        }

        private IQueryable<Funcionario> OrdenacaoDatatable(Dictionary<string, Dictionary<string, string>> order, IQueryable<Funcionario> query)
        {
            if (order["0"]["dir"] == "asc")
            {
                switch (order["0"]["column"])
                {
                    case "0":
                        query = query.OrderBy(x => x.Id);
                        break;
                    case "1":
                        query = query.OrderBy(x => x.Privilegio.Nome).ThenBy(x => x.Nome);
                        break;
                    case "2":
                        query = query.OrderBy(x => x.Nome);
                        break;
                    default:
                        query = query.OrderBy(x => x.Nome);
                        break;
                }
            }
            else
            {
                switch (order["0"]["column"])
                {
                    case "0":
                        query = query.OrderByDescending(x => x.Id);
                        break;
                    case "1":
                        query = query.OrderByDescending(x => x.Privilegio.Nome).ThenBy(x => x.Nome);
                        break;
                    case "2":
                        query = query.OrderByDescending(x => x.Nome);
                        break;
                    default:
                        query = query.OrderByDescending(x => x.Nome);
                        break;
                }
            }
            return query;
        }

        public bool Apagar(int id)
        {
            var func = _context.Funcionarios.FirstOrDefault(x => x.Id == id && x.RegistroAtivo == true);
            if (func == null) return false;

            func.RegistroAtivo = false;
            _context.Funcionarios.AddOrUpdate(func);
            _context.SaveChanges();
            return true;
        }

        public void Alterar(Funcionario funcionario)
        {
            _context.Funcionarios.AddOrUpdate(funcionario);
            _context.SaveChanges();
        }

    }
}
