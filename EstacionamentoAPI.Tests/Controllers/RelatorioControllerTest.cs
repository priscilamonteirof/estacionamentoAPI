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

namespace EstacionamentoAPI.Tests.Controllers
{
    [TestClass]
    public class RelatorioControllerTest
    {
        [TestMethod]
        public void Sumario()
        {
            // Arrange
            RelatorioAPIController controller = new RelatorioAPIController();

            SumarioRequest request = new SumarioRequest();
            request.DataInicial = Convert.ToDateTime("01/10/2020");
            request.DataFinal = Convert.ToDateTime("30/11/2020");
            request.EstabelecimentoID = 1;

            // Act
            var result = controller.GetSumario(request).ConfigureAwait(false);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SumarioPorHora()
        {
            // Arrange
            RelatorioAPIController controller = new RelatorioAPIController();

            SumarioRequest request = new SumarioRequest();
            request.DataInicial = Convert.ToDateTime("01/10/2020");
            request.DataFinal = Convert.ToDateTime("30/11/2020");
            request.EstabelecimentoID = 1;

            // Act
            var result = controller.GetSumarioPorHora(request).ConfigureAwait(false);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
