using Biblioteca.Application.Interfaces;
using Biblioteca.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.TesteUnitario.Application.Services
{
    public class UtilsServiceTest
    {
        private readonly IUtilsService _utilsService;
        public UtilsServiceTest() {
            var service = new ServiceCollection();
            service.AddTransient<IUtilsService, UtilsService>();

            var provider = service.BuildServiceProvider();
            _utilsService = provider.GetService<IUtilsService>();

        }
        public class Objeto
        {
            public Objeto(string keyString, long? keyLong) { 
                KeyString = keyString;
                KeyLong = keyLong;
            }
            public string KeyString { get; set; }
            public long? KeyLong{ get; set; }
        }
        [Fact]
        public void TodosPropriedadesPreenchidas()
        {
            Objeto objeto = new Objeto("teste", 1);
            Assert.True(_utilsService.TodosPropriedadesPreenchidas(objeto));

            objeto = new Objeto("", 1);
            Assert.False(_utilsService.TodosPropriedadesPreenchidas(objeto));

            objeto = new Objeto("teste", null);
            Assert.False(_utilsService.TodosPropriedadesPreenchidas(objeto));
        }
    }
}
