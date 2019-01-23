using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("privilegios")]
    public class Privilegio : Base
    {

        [Column("nome")]
        public string Nome { get; set; }

    }
}
