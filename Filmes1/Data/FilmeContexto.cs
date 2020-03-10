using Filmes1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Filmes1.Data
{
    public class FilmeContexto
    {
        public DbSet<CatalogoFilmes> Filmes { get; set; }        
    }
}