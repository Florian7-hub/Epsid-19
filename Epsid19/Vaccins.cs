using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Epsid19
{
    public class Vaccins
    {
        [Key]
        public int Id { get; set; }
        public string NomVaccin { get; set; }

    }
}
