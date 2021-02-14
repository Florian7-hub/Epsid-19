using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epsid19
{
    public class Personnes
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public DateTime DateNaissance { get; set; }
        public string TypePersonne { get; set; }
        public IList<InjectionsPersonnes> InjectionsPersonnes { get; set; }
    }
}
