using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Database
{
    public class FuncionarioInitializer : CreateDatabaseIfNotExists<FuncionarioContext>
    {
        protected override void Seed(FuncionarioContext context)
        {
            context.Privilegios.Add(new Privilegio() {Nome = "foro privilegiado", RegistroAtivo = true});

            base.Seed(context);
        }
    }
}
