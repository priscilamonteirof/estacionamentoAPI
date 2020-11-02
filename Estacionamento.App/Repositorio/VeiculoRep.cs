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
    public class VeiculoRep : IVeiculo
    {
        private Contexto _ctx;

        public VeiculoRep()
        {
            this._ctx = new Contexto();
        }
        
        public IEnumerable<VeiculoResponse> GetAll() {
            return _ctx.Veiculos
                    .Select(e => new VeiculoResponse
                    {
                        ID = e.ID,
                        Marca = e.Modelo.Marca.Nome,
                        Modelo = e.Modelo.Nome,
                        Placa = e.Placa,
                        Cor = Enum.GetName(typeof(ECor), e.Cor),
                        Tipo = Enum.GetName(typeof(ETipoVeiculo), e.Tipo)                        
                    })
                    .ToList();
        }

        public VeiculoResponse Get(int id)
        {
            try
            {
                return _ctx.Veiculos
                    .Where(e => e.ID == id)
                    .Select(e => new VeiculoResponse
                    {
                        ID = e.ID,
                        Marca = e.Modelo.Marca.Nome,
                        Modelo = e.Modelo.Nome,
                        Placa = e.Placa,
                        Cor = Enum.GetName(typeof(ECor), e.Cor),
                        Tipo = Enum.GetName(typeof(ETipoVeiculo), e.Tipo)
                    })
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new VeiculoResponse { Error = true, ErrorMessage = ex.Message };
            }
        }

        public SimpleResponse Save(VeiculoRequest request)
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
                    var vei = _ctx.Veiculos.Where(e => e.Placa == request.Placa).FirstOrDefault();

                    if (vei != null)
                    {
                        response.Error = true;
                        response.ErrorMessage = "Veículo já cadastrado.";
                    }
                    else
                    {
                        _ctx.Veiculos.Add(new Veiculo {
                            ID = 0,
                            Cor = (ECor)Enum.Parse(typeof(ECor), request.Cor, true),
                            Placa = request.Placa,
                            Tipo = (ETipoVeiculo)Enum.Parse(typeof(ETipoVeiculo), request.Tipo, true),
                            ModeloID = _ctx.Modelos.Where(m => m.Nome == request.Modelo && m.Marca.Nome == request.Marca).FirstOrDefault().ID                            
                        });

                        _ctx.SaveChanges();
                    }
                }
                else
                {
                    var vei = _ctx.Veiculos.Where(e => e.ID == request.ID).FirstOrDefault();

                    if (vei == null)
                    {
                        response.Error = true;
                        response.ErrorMessage = "Veículo não encontrado.";
                    }
                    else
                    {
                        vei.Cor = (ECor)Enum.Parse(typeof(ECor), request.Cor, true);
                        vei.Placa = request.Placa;
                        vei.Tipo = (ETipoVeiculo)Enum.Parse(typeof(ETipoVeiculo), request.Tipo, true);
                        vei.ModeloID = _ctx.Modelos.Where(m => m.Nome == request.Modelo && m.Marca.Nome == request.Marca).FirstOrDefault().ID;

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
                response.ErrorMessage = "Veículo nulo.";
            }
            else
            {
                var vei = _ctx.Veiculos.Where(e => e.ID == id).FirstOrDefault();

                if (vei == null)
                {
                    response.Error = true;
                    response.ErrorMessage = "Veículo não encontrado.";
                }
                else
                {
                    _ctx.Veiculos.Remove(vei);
                    _ctx.SaveChanges();
                }
            }

            return response;
        }

    }
}