using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Epsid19
{
    public class Injections
    {
        [Key]
        public int Id { get; set; }
        public string Marque { get; set; }
        public string NumLot { get; set; }
        public DateTime DateInjection { get; set; }
        public DateTime DateRappel { get; set; }
        public string TypeVaccin { get; set; }
        public IList<InjectionsPersonnes> InjectionsPersonnes { get; set; }

    }
}
