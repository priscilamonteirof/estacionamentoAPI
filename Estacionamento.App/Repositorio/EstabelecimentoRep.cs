using Estacionamento.Contracts.Contracts;
using Estacionamento.Contracts.Interfaces;
using Estacionamento.Domain.Entities;
using Estacionamento.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Estacionamento.App.Services
{
    public class EstabelecimentoRep : IEstabelecimento
    {
        private Contexto _ctx;

        public EstabelecimentoRep()
        {
            this._ctx = new Contexto();
        }
        
        public IEnumerable<EstabelecimentoResponse> GetAll() {
            return _ctx.Estabelecimentos
                    .Select(e => new EstabelecimentoResponse
                    {
                        ID = e.ID,
                        Nome = e.Nome,
                        CNPJ = e.CNPJ,
                        Endereco = e.Endereco,
                        Telefone = e.Telefone,
                        QtdeCarro =  e.QuantidadeVagaCarro,
                        QtdeMoto = e.QuantidadeVagaMoto
                    })
                    .ToList();
        }

        public EstabelecimentoResponse Get(int id) {
            try
            {
                return _ctx.Estabelecimentos
                    .Where(e => e.ID == id)
                    .Select(e => new EstabelecimentoResponse
                    {
                        ID = e.ID,
                        Nome = e.Nome,
                        CNPJ = e.CNPJ,
                        Endereco = e.Endereco,
                        Telefone = e.Telefone,
                        QtdeCarro = e.QuantidadeVagaCarro,
                        QtdeMoto = e.QuantidadeVagaMoto
                    })
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new EstabelecimentoResponse { Error = true, ErrorMessage = ex.Message };
            }
        }

        public SimpleResponse Save(EstabelecimentoRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.Error = true;
                response.ErrorMessage = "Request nulo.";
            }
            else 
            {
                if (request.ID == 0)
                {
                    var est = _ctx.Estabelecimentos.Where(e => e.CNPJ == request.CNPJ).FirstOrDefault();

                    if (est != null)
                    {
                        response.Error = true;
                        response.ErrorMessage = "Estabelecimento já cadastrado.";
                    }
                    else
                    {
                        _ctx.Estabelecimentos.Add(new Estabelecimento {
                            ID = 0,
                            Nome = request.Nome,
                            CNPJ = request.CNPJ,
                            Endereco = request.Endereco,
                            Telefone = request.Telefone,
                            QuantidadeVagaCarro = request.QtdeCarro,
                            QuantidadeVagaMoto = request.QtdeMoto
                        });

                        _ctx.SaveChanges();
                    }
                }
                else
                {
                    var est = _ctx.Estabelecimentos.Where(e => e.ID == request.ID).FirstOrDefault();

                    if (est == null)
                    {
                        response.Error = true;
                        response.ErrorMessage = "Estabelecimento não encontrado.";
                    }
                    else
                    {
                        est.CNPJ = request.CNPJ;
                        est.Endereco = request.Endereco;
                        est.Telefone = request.Telefone;
                        est.Nome = request.Nome;
                        est.QuantidadeVagaCarro = request.QtdeCarro;
                        est.QuantidadeVagaMoto = request.QtdeMoto;

                        _ctx.SaveChanges();
                    }
                }
            }

            return response;
        }

        public SimpleResponse Delete(int id)
        {
            SimpleResponse response = new SimpleResponse();
            response.Error = false;
            response.ErrorMessage = "";

            if (id == 0)
            {
                response.Error = true;
                response.ErrorMessage = "Estabelecimento nulo.";
            }
            else
            {
                var est = _ctx.Estabelecimentos.Where(e => e.ID == id).FirstOrDefault();

                if (est == null)
                {
                    response.Error = true;
                    response.ErrorMessage = "Estabelecimento não encontrado.";
                }
                else
                {
                    _ctx.Estabelecimentos.Remove(est);
                    _ctx.SaveChanges();
                }
            }

            return response;
        }

    }
}