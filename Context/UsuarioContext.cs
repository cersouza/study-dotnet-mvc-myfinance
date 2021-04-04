using MyFinance.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Web.Context
{
    public class UsuarioContext: DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
