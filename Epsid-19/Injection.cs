using System;
using System.Collections.Generic;
using System.Text;

namespace Epsid_19
{
    public class Injection
    {
        public int Id { get; set; }

        public string Marque { get; set; }

        public int NumLotVaccin { get; set; }

        public DateTime DateInjection { get; set; }

        public DateTime DateRappel { get; set; }

        public int IdTypeVaccin { get; set; }

        public int PersonneId { get; set; }
        public Personne Personne { get; set; }

    }
}
