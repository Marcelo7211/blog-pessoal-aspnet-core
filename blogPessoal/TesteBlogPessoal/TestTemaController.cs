using blogPessoal.Controllers;
using blogPessoal.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TesteBlogPessoal
{
    [TestClass]
    public class TestTemaController
    {
        blogPessoal.Controllers.TemaController _controller;
        ITemaRepository _service;
        public TestTemaController()
        {
            _service = new TemaRepositoryFake();
            _controller = new blogPessoal.Controllers.TemaController(_service);
        }
        [TestMethod]
        public void GetIsPresent()
        {
            // Act
            var okResult = _controller.GetTemas();
            // Assert
            Assert.IsNotNull(okResult);
        }
        [TestMethod]
        public void Get_TotalIgualACinco()
        {
            // Act
            var okResult = _controller.GetTemas().Count;
            // Assert

            Assert.AreEqual(5, okResult);
        }

        [TestMethod]
        public void Get_UltimoIgualAJavaScript()
        {
            // Act
            var okResult = _controller.GetTemas();
            // Assert

            Assert.AreEqual("JavaScript", okResult[4].Descricao);
        }

        [TestMethod]
        public void Get_UltimoIgualASqlServer()
        {
            // Act
            var okResult = _controller.GetTemas();
            // Assert

            Assert.AreEqual("SqlServer", okResult[4].Descricao);
        }

    }

}
