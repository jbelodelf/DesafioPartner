using System;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface IPatrimonioRepository
    {
        List<Patrimonio> GetPatrimonios();
        Patrimonio GetPatrimonio(Int64 Id);
        Patrimonio GetPatrimonio(string Nome);
        void PostPatrimonio(Patrimonio marca);
        void PutPatrimonio(Patrimonio marca);
        void DeletePatrimonio(Int64 Id);
    }
}
