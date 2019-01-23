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
            return _context.Funcionarios.ToList();
        }

        public Funcionario ObterPeloId(int id)
        {
            var func = _context.Funcionarios.FirstOrDefault(x => x.Id == id && x.RegistroAtivo);
            return func;
        }

        public Funcionario Inserir(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.Funcionarios(funcionario.RegistroAtivo = true);
            _context.SaveChanges();
            return funcionario;
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
    }
}
