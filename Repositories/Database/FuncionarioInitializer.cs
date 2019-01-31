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
            Privilegio privilegio = new Privilegio()
            {
                Id = 1,//deve especificar o Id
                Nome = "foro privilegiado",
                RegistroAtivo = true
            };

            context.Privilegios.Add(privilegio);

            Funcionario funcionario = new Funcionario()
            {
                Nome = "nos",
                PrivilegioId = 1,
                Login = "123",
                Senha = "123",
                Sexo = "m",
                Salario = 1000,
                RegistroAtivo = true,

            };

            context.Funcionarios.Add(funcionario);
            context.Funcionarios.Add(new Funcionario() { Nome = "voces", PrivilegioId = 1, Login = "abc", Senha = "abc", Sexo = "f", Salario = 0, RegistroAtivo = true });
            context.Funcionarios.Add(new Funcionario() { Nome = "todos", PrivilegioId = 1, Login = "sadsad", Senha = "saddas", Sexo = "f", Salario = 500, RegistroAtivo = true });



            base.Seed(context);
        }
    }
}
