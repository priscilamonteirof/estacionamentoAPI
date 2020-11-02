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
    public class EstabelecimentoControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            EstabelecimentoAPIController controller = new EstabelecimentoAPIController();

            // Act
            var result = controller.GetAll().ConfigureAwait(false);          

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            EstabelecimentoAPIController controller = new EstabelecimentoAPIController();

            // Act
            var result = controller.Get(1).ConfigureAwait(false);
            
            // Assert
            Assert.IsNull(result, "Registro nao localizado.");
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            EstabelecimentoAPIController controller = new EstabelecimentoAPIController();
 
            EstabelecimentoRequest request = new EstabelecimentoRequest();
            request.ID = 0;
            request.CNPJ = "123";
            request.Endereco = "Rua A";
            request.Nome = "Teste";
            request.Telefone = "13 33333333";
            request.QtdeCarro = 100;
            request.QtdeMoto = 20;

            // Act
            var response = controller.Save(request).ConfigureAwait(false);

            // Assert
            Assert.IsNull(response, "Registro nao salvo.");
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            EstabelecimentoAPIController controller = new EstabelecimentoAPIController();

            EstabelecimentoRequest request = new EstabelecimentoRequest();
            request.ID = 3;
            request.CNPJ = "123";
            request.Endereco = "Rua AB";
            request.Nome = "Teste";
            request.Telefone = "13 33333333";
            request.QtdeCarro = 200;
            request.QtdeMoto = 40;

            // Act
            var response = controller.Save(request).ConfigureAwait(false);
            
            // Assert
            Assert.IsNull(response, "Registro nao atualizado.");
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            EstabelecimentoAPIController controller = new EstabelecimentoAPIController();

            // Act
            var response = controller.Delete(2).ConfigureAwait(false);
            
            // Assert
            Assert.IsNull(response, "Registro nao excluido.");
        }
    }
}
