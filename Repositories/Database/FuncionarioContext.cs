using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Database
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext() : base("SqlServerConnection1")
        {
            System.Data.Entity.Database.SetInitializer<FuncionarioContext>(new FuncionarioInitializer());
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Privilegio> Privilegios { get; set; }

    }
}
