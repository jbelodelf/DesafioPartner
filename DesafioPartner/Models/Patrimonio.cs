using System;

namespace Models
{
    public class Patrimonio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Int64 MarcaId { get; set; }
        public string Descricao { get; set; }
        public Int64 NumTombo { get; set; }
    }
}
