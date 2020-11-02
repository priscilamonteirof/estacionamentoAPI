using Estacionamento.Contracts.Contracts;
using Estacionamento.Contracts.Interfaces;
using Estacionamento.Domain.Entities;
using Estacionamento.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estacionamento.App.Repositorio
{
    public class MovimentacaoRep: IMovimentacao
    {
        private Contexto _ctx;

        public MovimentacaoRep()
        {
            this._ctx = new Contexto();
        }

        public MovimentacaoResponse GetTicket(int id) 
        {
            try
            {
                return _ctx.Movimentacoes
                    .Where(e => e.ID == id)
                    .Select(e => new MovimentacaoResponse
                    {
                        ID = e.ID,
                        VeiculoID = e.VeiculoID,
                        Placa = e.Veiculo.Placa,
                        DataEntrada = e.DataEntrada,
                        HoraEntrada = e.HoraEntrada,
                        DataSaida = e.DataSaida,
                        HoraSaida = e.HoraSaida
                    })
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new MovimentacaoResponse { Error = true, ErrorMessage = ex.Message };
            }
        }

        public MovimentacaoResponse GetTicketByPlaca(string placa)
        {
            try
            {
                return _ctx.Movimentacoes
                    .Where(e => e.Veiculo.Placa == placa)
                    .Select(e => new MovimentacaoResponse
                    {
                        ID = e.ID,
                        VeiculoID = e.VeiculoID,
                        Placa = e.Veiculo.Placa,
                        DataEntrada = e.DataEntrada,
                        HoraEntrada = e.HoraEntrada,
                        DataSaida = e.DataSaida,
                        HoraSaida = e.HoraSaida
                    })
                    .OrderByDescending(e => e.ID)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new MovimentacaoResponse { Error = true, ErrorMessage = ex.Message };
            }
        }

        public SimpleResponse LancarEntrada(MovimentacaoRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.Error = true;
                response.ErrorMessage = "Request nulo.";
            }
            else
            {                
                var mov = _ctx.Movimentacoes.Where(e => e.Veiculo.Placa == request.Placa && e.DataSaida == null).FirstOrDefault();

                if (mov != null)
                {
                    response.Error = true;
                    response.ErrorMessage = "Veículo já cadastrado.";
                }
                else
                {
                    _ctx.Movimentacoes.Add(new Movimentacao
                    {
                        ID = 0,
                        EstabelecimentoID = request.EstabelecimentoID,
                        VeiculoID = _ctx.Veiculos.Where(v => v.Placa == request.Placa).FirstOrDefault().ID,
                        DataEntrada = DateTime.Now,
                        HoraEntrada = DateTime.Now.TimeOfDay
                    });

                    _ctx.SaveChanges();
                }                
            }

            return response;        
        }

        public SimpleResponse LancarBaixaSaida(int id)
        {
            SimpleResponse response = new SimpleResponse();

            if (id == 0)
            {
                response.Error = true;
                response.ErrorMessage = "Request nulo.";
            }
            else
            {
                var mov = _ctx.Movimentacoes.Where(e => e.ID == id).FirstOrDefault();

                if (mov == null)
                {
                    response.Error = true;
                    response.ErrorMessage = "Veículo não localizado.";
                }
                else
                {
                    mov.DataSaida = DateTime.Now;
                    mov.HoraSaida = DateTime.Now.TimeOfDay;

                    _ctx.SaveChanges();
                }
            }

            return response;
        }

        public SimpleResponse LancarBaixaSaidaByPlaca(string placa)
        {
            SimpleResponse response = new SimpleResponse();

            if (placa.Trim() == "")
            {
                response.Error = true;
                response.ErrorMessage = "Request nulo.";
            }
            else
            {
                var mov = _ctx.Movimentacoes.Where(e => e.Veiculo.Placa == placa && e.DataSaida == null).FirstOrDefault();

                if (mov == null)
                {
                    response.Error = true;
                    response.ErrorMessage = "Veículo não localizado.";
                }
                else
                {
                    mov.DataSaida = DateTime.Now;
                    mov.HoraSaida = DateTime.Now.TimeOfDay;

                    _ctx.SaveChanges();
                }
            }

            return response;
        }
    }
}