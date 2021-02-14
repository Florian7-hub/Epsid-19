using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Epsid19
{
    public class InjectionsPersonnes
    {
        public int InjectionsId { get; set; }
        public Injections Injections { get; set; }


        public int PersonnesId { get; set; }
        public Personnes Personnes { get; set; }

    }
}
