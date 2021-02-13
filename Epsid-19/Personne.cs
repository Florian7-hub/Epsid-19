using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Epsid_19
{
    public class Personne
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nom { get; set; }

        [MaxLength(50)]
        public string Prenom { get; set; }

        [MaxLength(2)]
        public string Sexe { get; set; }
        public DateTime DateNaissance { get; set; }
        public int TypePersonne { get; set; }

        //une personne peut avoir 0 ou plusieurs injections
        public List<Injection> Injections { get; } = new List<Injection>();
    }
}
