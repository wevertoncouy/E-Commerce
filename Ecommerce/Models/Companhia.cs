using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Companhia
    {
        [Key]
        [Display(Name = "Companhia")]
        public int CompanhiaId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatorio! ")]
        [MaxLength(50, ErrorMessage = "O campo Nome recebe no máximo 50 caracteres")]
        [Display(Name = "Nome")]
        [Index("Departamento_Nome_Index", IsUnique = true)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatorio! ")]
        [MaxLength(50, ErrorMessage = "O campo Nome recebe no máximo 50 caracteres")]
        [Display(Name = "Telefone")]
        //[Index("Departamento_Nome_Index", IsUnique = true)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatorio! ")]
        [MaxLength(120, ErrorMessage = "O campo Nome recebe no máximo 50 caracteres")]
        [Display(Name = "Endereço")]
        public string Endereço { get; set; }

 
        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        public virtual ICollection<Departamento> Departamentos{ get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}