using System;
using System.Collections.Generic;

namespace Models
{
    public class Marca
    {
        public Marca()
        {
            patrimonios = new List<Patrimonio>();
        }
        public Int64 MarcaId { get; set; }
        public string Nome { get; set; }

        public virtual List<Patrimonio> patrimonios { get; set; }
    }
}