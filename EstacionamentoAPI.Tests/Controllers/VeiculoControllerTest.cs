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
    public class VeiculoControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            VeiculoAPIController controller = new VeiculoAPIController();

            // Act
            var result = controller.GetAll().ConfigureAwait(false);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            VeiculoAPIController controller = new VeiculoAPIController();

            // Act
            var result = controller.Get(1).ConfigureAwait(false);

            // Assert
            Assert.IsNull(result, "Registro nao localizado.");
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            VeiculoAPIController controller = new VeiculoAPIController();

            VeiculoRequest request = new VeiculoRequest();
            request.ID = 0;
            request.Placa = "ENA5001";
            request.Tipo = "Carro";
            request.Cor = "Branco";
            request.Marca = "Hyundai";
            request.Modelo = "I30";

            // Act
            var response = controller.Save(request).ConfigureAwait(false);

            // Assert
            Assert.IsNull(response, "Registro nao salvo.");
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            VeiculoAPIController controller = new VeiculoAPIController();

            VeiculoRequest request = new VeiculoRequest();
            request.ID = 1;
            request.Placa = "ENA5002";
            request.Tipo = "Carro";
            request.Cor = "Branco";
            request.Marca = "Hyundai";
            request.Modelo = "I30";

            // Act
            var response = controller.Save(request).ConfigureAwait(false);

            // Assert
            Assert.IsNull(response, "Registro nao atualizado.");
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            VeiculoAPIController controller = new VeiculoAPIController();

            // Act
            var response = controller.Delete(1).ConfigureAwait(false);

            // Assert
            Assert.IsNull(response, "Registro nao excluido.");
        }
    }
}
