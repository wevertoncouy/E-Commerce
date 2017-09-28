using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Cidade
    {
        [Key]
        [Display(Name = "Cidade Id")]
        public int CidadeId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatorio! ")]
        [Display(Name = "Cidade")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo é obrigatorio! ")]

      [Display(Name="Departamento")]
      [Range(1,double.MaxValue, ErrorMessage ="Selecione um Departamento")]
        public int DepartamentoId { get; set; }

        public virtual Departamento Departamentos { get; set; }

        public virtual ICollection<Companhia> Companhia { get; set; }




    }
}