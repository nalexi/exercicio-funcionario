using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("funcionarios")]
    public class Funcionario : Base
    {
        [Column("id_privilegio"), ForeignKey("Privilegio")]
        public int PrivilegioId { get; set; }

        public virtual Privilegio Privilegio { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("sexo")]
        public string Sexo { get; set; }

        [Column("salario")]
        public decimal Salario { get; set; }
    }
}
