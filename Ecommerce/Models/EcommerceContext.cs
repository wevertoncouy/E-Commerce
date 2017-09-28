using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(): base("strConexao")
        {

        }

        
        //Dasativa as Cascatas
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }




        public System.Data.Entity.DbSet<Ecommerce.Models.Departamento> Departamentoes { get; set; }

        public System.Data.Entity.DbSet<Ecommerce.Models.Cidade> Cidades { get; set; }

        public System.Data.Entity.DbSet<Ecommerce.Models.Companhia> Companhias { get; set; }
    }
}