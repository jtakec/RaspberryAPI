using RaspberryLibrary.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaspberryLibrary.Servicos
{
    public class GetStatusAll : IProcessaComando
    {
        public async Task<Resultado> executa(string url, int pinNumber)
        {
            HttpCliente http = new HttpCliente(url);
           
            string endpoint = $"{url}/api/Gpio/Status";
            var resultado = await http.get<List<pinoGPIOCompacto>>(endpoint);

            return await Task.FromResult<Resultado>(resultado);
        }
    }
}

