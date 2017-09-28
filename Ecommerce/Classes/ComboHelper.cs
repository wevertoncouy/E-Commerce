using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Classes
{
    public class ComboHelper : IDisposable
    {
        private static EcommerceContext db = new EcommerceContext();
        public static List<Departamento> GetDeparatementos() {
        

        var Dep = db.Departamentoes.ToList();
        Dep.Add(new Departamento
            {
                DepartamentoId = 0,
                Nome = "[Selecione um Departamento]"

            });

            return Dep = Dep.OrderBy(d => d.Nome).ToList();

           }

    public void Dispose()
        {
            db.Dispose();
        }
    }
}