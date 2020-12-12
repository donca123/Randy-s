using Microsoft.VisualStudio.TestTools.UnitTesting;
using DominioGym;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }

        [TestMethod]
        public void TestCambiarNombreCliente()
        {
            //Arrange
            var cli = new Cliente();
            string nuevo = "Marco";

            //Act
            string result = cli.CambiarNombre(nuevo);
            //Assert

            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void TestCambiaApellidoPaterno()
        {
            //Arrange
            var cli = new Cliente();
            string nuevo = "Garcia";

            //Act
            string result = cli.CambiarApellidoPaterno(nuevo);
            //Assert

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestCambiarApellidoMaterno()
        {
            //Arrange
            var cli = new Cliente();
            string nuevo = "Pinto";

            //Act
            string result = cli.CambiarApellidoMaterno(nuevo);
            //Assert

            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void TestCambiarTelefono()
        {
            //Arrange
            var cli = new Cliente();
            int nuevo = 951593588;

            //Act
            int result = cli.CambiarTelefono(nuevo);
            //Assert

            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void TestCambiarDireccion()
        {
            //Arrange
            var cli = new Cliente();
            string nuevo = "Cono Sur 1ra Etapa";

            //Act
            string result = cli.CambiarDireccion(nuevo);
            //Assert

            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void testCambiarDni()
        {
            //Arrange
            var cli = new Cliente();
            int nuevo = 70615499;

            //Act
            int result = cli.cambiarDni(nuevo);
            //Assert

            Assert.IsNotNull(result);

        }
    }
}
