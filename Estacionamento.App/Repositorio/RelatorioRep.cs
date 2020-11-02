using Estacionamento.Contracts.Contracts;
using Estacionamento.Contracts.Interfaces;
using Estacionamento.CrossCutting.Enum;
using Estacionamento.Domain.Entities;
using Estacionamento.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Estacionamento.App.Services
{
    public class RelatorioRep : IRelatorio
    {
        private Contexto _ctx;

        public RelatorioRep()
        {
            this._ctx = new Contexto();
        }
        
        public IEnumerable<SumarioResponse> GetSumario(SumarioRequest request) 
        {
            IEnumerable<SumarioResponse> response = _ctx.Movimentacoes
                .Where(m => m.DataEntrada >= request.DataInicial && m.DataEntrada <= request.DataFinal 
                    && m.EstabelecimentoID == request.EstabelecimentoID)
                .GroupBy(g => new { g.EstabelecimentoID, g.DataEntrada, g.Veiculo.Tipo })
                .Select(s => new SumarioResponse {
                    EstabelecimentoID = s.Key.EstabelecimentoID,
                    Data = s.Key.DataEntrada,
                    Tipo = (int)s.Key.Tipo,
                    Qtde = s.Count()                
                })
                .ToList();

            return response;
        }

        public IEnumerable<SumarioPorHoraResponse> GetSumarioPorHora(SumarioRequest request)
        {
            List<SumarioPorHoraResponse> response = new List<SumarioPorHoraResponse>();
            for (int i = 0; i < 24; i++)
            {
                TimeSpan hrinicio = TimeSpan.Parse(i + ":00");
                TimeSpan hrfinal = TimeSpan.Parse(i + ":59");

                response.AddRange(
                    _ctx.Movimentacoes
                           .Where(m => m.DataEntrada >= request.DataInicial && m.DataEntrada <= request.DataFinal
                               && m.EstabelecimentoID == request.EstabelecimentoID
                               && m.HoraEntrada >= hrinicio && m.HoraEntrada <= hrfinal)
                           .GroupBy(g => new { g.EstabelecimentoID, g.DataEntrada, hrinicio, g.Veiculo.Tipo })
                           .Select(s => new SumarioPorHoraResponse
                           {
                               EstabelecimentoID = s.Key.EstabelecimentoID,
                               Data = s.Key.DataEntrada,
                               Horario = s.Key.hrinicio,
                               Tipo = (int)s.Key.Tipo,
                               Qtde = s.Count()
                           })
                           .ToList()
                    );
            }

            return response;
        }

    }
}