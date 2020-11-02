using Estacionamento.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Contracts.Interfaces
{
    public interface IEstabelecimento
    {
        IEnumerable<EstabelecimentoResponse> GetAll();
        EstabelecimentoResponse Get(int id);
        SimpleResponse Save(EstabelecimentoRequest request);
        SimpleResponse Delete(int id);
    }
}
