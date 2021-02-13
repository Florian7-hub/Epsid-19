using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epsid_19
{
    public partial class Context : DbContext
        {
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Injection> Injections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //En vrai on ne mettrati surtout pas la chaine de connexion en dur dans le code !!
        //On la bougerait dans un fichier de config
        options.UseSqlite("Data Source=vaccins.db");
    }
}

    
}
