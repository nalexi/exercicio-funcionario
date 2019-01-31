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
    public class PrivilegioRepository
    {
        private readonly FuncionarioContext _context;

        public PrivilegioRepository()
        {
            _context = new FuncionarioContext();
        }

        public List<Privilegio> ObterTodos()
        {
            List<Privilegio> privilegios = _context.Privilegios.Where(x => x.RegistroAtivo).ToList();

            return privilegios;
        }

        public Object ObterTodosParaJson()
        {
            return _context.Privilegios.OrderBy(x => x.Nome).Select(x => new { id = x.Id, text = x.Nome });
        }

        public Privilegio ObterPeloId(int id)
        {
            var priv = _context.Privilegios.FirstOrDefault(x => x.Id == id && x.RegistroAtivo);
            return priv;
        }

        public Privilegio Inserir(Privilegio privilegio)
        {
            privilegio.RegistroAtivo = true;
            _context.Privilegios.Add(privilegio);
            _context.SaveChanges();
            return privilegio;
        }

        public bool Apagar(int id)
        {
            var priv = _context.Privilegios.FirstOrDefault(x => x.Id == id && x.RegistroAtivo);
            if (priv == null) return false;

            priv.RegistroAtivo = false;
            _context.Privilegios.AddOrUpdate(priv);
            _context.SaveChanges();
            return true;
        }

        
    }
}
