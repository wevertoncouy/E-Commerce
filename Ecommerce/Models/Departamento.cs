using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Departamento
    {


        [Key]
        [Display(Name ="Departamento")]

        public int DepartamentoId{ get; set; }

        [Required(ErrorMessage ="O campo é obrigatorio! ")]
        [MaxLength(50,ErrorMessage ="O campo Nome recebe no máximo 50 caracteres")]
        [Display(Name ="Nome")]
        [Index("Departamento_Nome_Index",IsUnique = true)]
        public string Nome{ get; set; }

        public List<Cidade> Cidades { get; set; }

        public List<Companhia> Companhia { get; set; }
    }
}