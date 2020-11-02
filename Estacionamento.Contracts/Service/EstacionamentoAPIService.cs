using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using Estacionamento.Contracts.Contracts;

namespace Estacionamento.Contracts.Service
{
    public class EstacionamentoAPIService
    {
        #region Estabelecimentos
        public static async Task<IEnumerable<EstabelecimentoResponse>> GetAll()
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.GetAsync(string.Format("http://{0}/estacionamentoservice/api/estabelecimentos", host));
                var json = await response.Content.ReadAsAsync<IEnumerable<EstabelecimentoResponse>>().ConfigureAwait(false);
                return json;
            }
        }

        public static async Task<EstabelecimentoResponse> Get(int id)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.GetAsync(string.Format("http://{0}/estacionamentoservice/api/estabelecimentos/{1}", host, id));
                var json = await response.Content.ReadAsAsync<EstabelecimentoResponse>().ConfigureAwait(false);
                return json;
            }
        }

        public static async Task<SimpleResponse> Save(EstabelecimentoRequest request)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.PostAsJsonAsync(string.Format("http://{0}/estacionamentoservice/api/estabelecimentos/save", host), request);
                var json = await response.Content.ReadAsAsync<SimpleResponse>().ConfigureAwait(false);
                return json;
            }
        }

        public static async Task<SimpleResponse> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.GetAsync(string.Format("http://{0}/estacionamentoservice/api/estabelecimentos/delete/{1}", host, id));
                var json = await response.Content.ReadAsAsync<SimpleResponse>().ConfigureAwait(false);
                return json;
            }
        }
        #endregion
        
        #region Veiculos
        public static async Task<IEnumerable<VeiculoResponse>> GetAllVeiculo()
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.GetAsync(string.Format("http://{0}/estacionamentoservice/api/veiculos", host));
                var json = await response.Content.ReadAsAsync<IEnumerable<VeiculoResponse>>().ConfigureAwait(false);
                return json;
            }
        }

        public static async Task<VeiculoResponse> GetVeiculo(int id)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.GetAsync(string.Format("http://{0}/estacionamentoservice/api/veiculos/{1}", host, id));
                var json = await response.Content.ReadAsAsync<VeiculoResponse>().ConfigureAwait(false);
                return json;
            }
        }

        public static async Task<SimpleResponse> SaveVeiculo(EstabelecimentoRequest request)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.PostAsJsonAsync(string.Format("http://{0}/estacionamentoservice/api/veiculos/save", host), request);
                var json = await response.Content.ReadAsAsync<SimpleResponse>().ConfigureAwait(false);
                return json;
            }
        }

        public static async Task<SimpleResponse> DeleteVeiculo(int id)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.GetAsync(string.Format("http://{0}/estacionamentoservice/api/veiculos/delete/{1}", host, id));
                var json = await response.Content.ReadAsAsync<SimpleResponse>().ConfigureAwait(false);
                return json;
            }
        }
        #endregion

        #region Autenticacao
        public static async Task<LoginResponse> Login(LoginRequest request)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.PostAsJsonAsync(string.Format("http://{0}/estacionamentoservice/api/login", host), request);
                var json = await response.Content.ReadAsAsync<LoginResponse>().ConfigureAwait(false);
                return json;
            }
        }
        #endregion

        #region Relatorios
        public static async Task<IEnumerable<SumarioResponse>> GetSumario(SumarioRequest request)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.PostAsJsonAsync(string.Format("http://{0}/estacionamentoservice/api/relatorios/sumario", host), request);
                var json = await response.Content.ReadAsAsync<IEnumerable<SumarioResponse>>().ConfigureAwait(false);
                return json;
            }
        }

        public static async Task<IEnumerable<SumarioPorHoraResponse>> GetSumarioPorHora(SumarioRequest request)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.PostAsJsonAsync(string.Format("http://{0}/estacionamentoservice/api/relatorios/sumario-por-hora", host), request);
                var json = await response.Content.ReadAsAsync<IEnumerable<SumarioPorHoraResponse>>().ConfigureAwait(false);
                return json;
            }
        }
        #endregion

        #region Movimentacao
        public static async Task<MovimentacaoResponse> GetTicket(int id)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.GetAsync(string.Format("http://{0}/estacionamentoservice/api/movimentacao/ticket/{1}", host, id));
                var json = await response.Content.ReadAsAsync<MovimentacaoResponse>().ConfigureAwait(false);
                return json;
            }
        }

        public static async Task<MovimentacaoResponse> GetTicketByPlaca(string placa)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.GetAsync(string.Format("http://{0}/estacionamentoservice/api/movimentacao/placa/{1}", host, placa));
                var json = await response.Content.ReadAsAsync<MovimentacaoResponse>().ConfigureAwait(false);
                return json;
            }
        }

        public static async Task<SimpleResponse> LancarEntrada(MovimentacaoRequest request)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.PostAsJsonAsync(string.Format("http://{0}/estacionamentoservice/api/movimentacao/lancar-entrada", host), request);
                var json = await response.Content.ReadAsAsync<SimpleResponse>().ConfigureAwait(false);

                return json;
            }
        }

        public static async Task<SimpleResponse> LancarBaixaSaida(int id)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.GetAsync(string.Format("http://{0}/estacionamentoservice/api/movimentacao/baixar/{1}", host, id));
                var json = await response.Content.ReadAsAsync<SimpleResponse>().ConfigureAwait(false);

                return json;
            }
        }

        public static async Task<SimpleResponse> LancarBaixaSaidaByPlaca(string placa)
        {
            using (var client = new HttpClient())
            {
                var host = ConfigurationManager.AppSettings["ServicesHost"];
                var response = await client.GetAsync(string.Format("http://{0}/estacionamentoservice/api/movimentacao/baixar/{1}", host, placa));
                var json = await response.Content.ReadAsAsync<SimpleResponse>().ConfigureAwait(false);

                return json;
            }
        }
        #endregion
    }
}