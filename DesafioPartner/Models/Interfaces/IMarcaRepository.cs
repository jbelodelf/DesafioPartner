using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IMarcaRepository
    {
        List<Marca> GetMarcas();
        Marca GetMarca(Int64 Id);
        Marca GetMarca(string Nome);
        Marca GetPatrimonioByMarca(Int64 Id, string Nome);
        void PostMarca(Marca marca);
        void PutMarca(Marca marca);
        void DeleteMarca(Int64 Id);
    }
}
