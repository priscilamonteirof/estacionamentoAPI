using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstacionamentoAPI;
using EstacionamentoAPI.Controllers;
using Estacionamento.Contracts.Contracts;
using Estacionamento.Contracts.Interfaces;
using Estacionamento.Contracts.Service;

namespace EstacionamentoAPI.Tests.Controllers
{
    [TestClass]
    public class MovimentacaoControllerTest
    {
        [TestMethod]
        public void GetTicket() 
        {
            // Arrange
            MovimentacaoAPIController controller = new MovimentacaoAPIController();

            // Act
            var result = controller.GetTicket(3).ConfigureAwait(false);          

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTicketByPlaca()
        {
            // Arrange
            MovimentacaoAPIController controller = new MovimentacaoAPIController();

            // Act
            var result = controller.GetTicketByPlaca("ENA5001").ConfigureAwait(false);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LancarEntrada()
        {
            // Arrange
            MovimentacaoAPIController controller = new MovimentacaoAPIController();

            MovimentacaoRequest request = new MovimentacaoRequest();
            request.EstabelecimentoID = 1;
            request.Placa = "ENA5001";            

            // Act
            var response = controller.LancarEntrada(request).ConfigureAwait(false);

            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void LancarBaixaSaida()
        {
            // Arrange
            MovimentacaoAPIController controller = new MovimentacaoAPIController();

            // Act
            var response = controller.LancarBaixaSaida(9).ConfigureAwait(false);

            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void LancarBaixaSaidaByPlaca()
        {
            // Arrange
            MovimentacaoAPIController controller = new MovimentacaoAPIController();

            // Act
            var response = controller.LancarBaixaSaidaByPlaca("ENA5001").ConfigureAwait(false);

            // Assert
            Assert.IsNotNull(response);
        }
    }
}
