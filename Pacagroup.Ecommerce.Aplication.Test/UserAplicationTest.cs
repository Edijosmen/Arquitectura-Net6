using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Aplication.Interface;

namespace Pacagroup.Ecommerce.Aplication.Test
{
    [TestClass]
    public class UserAplicationTest
    {
        private static WebApplicationFactory<Program> _factory = null;
        private static IServiceScopeFactory _scopeFactory;
        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory =_factory.Services.GetRequiredService<IServiceScopeFactory>();
        }
        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornaErrorValidation()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserAplication>();

            //Arrange: donde se inicializa los objetos necesario para ejecutar el codigo
            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Errores de Validación";

            //Act: donde se ejecuta el metodo que se va a probar y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;
            //Assert: donde se comprueba que el resultado obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosCorrectos_RetornaMessageCorrect()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserAplication>();

            //Arrange: donde se inicializa los objetos necesario para ejecutar el codigo
            var userName = "edijosmen";
            var password = "123456";
            var expected = "Autenticación Exitosa!!";

            //Act: donde se ejecuta el metodo que se va a probar y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;
            //Assert: donde se comprueba que el resultado obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrecto_RetornaMessageUserNoExiste()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserAplication>();

            //Arrange: donde se inicializa los objetos necesario para ejecutar el codigo
            var userName = "edijosmen";
            var password = "1234569";
            var expected = "Usuario no existe";

            //Act: donde se ejecuta el metodo que se va a probar y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;
            //Assert: donde se comprueba que el resultado obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }
    }
}