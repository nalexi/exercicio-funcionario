using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class FuncionarioViewModel
    {
        [Required(ErrorMessage ="Nome deve ser preenchido")]
        [MinLength(4, ErrorMessage ="deve conter mais que 4 digitos")]
        [MaxLength(4, ErrorMessage ="deve conter menos que 100 digitos")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Salario deve ser preechido")]
        public decimal Salario { get; set; }
        
        [Required]
        public int PrivilegioId { get; set; }

    }
}
