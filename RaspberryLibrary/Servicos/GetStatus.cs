using RaspberryLibrary.Entidades;
using System.Threading.Tasks;

namespace RaspberryLibrary.Servicos
{
    public class GetStatus : IProcessaComando
    {
        public async Task<Resultado> executa(string url, int pinNumber)
        {
            HttpCliente http = new HttpCliente(url);
           
            string endpoint = $"{url}/api/Gpio/{pinNumber}/Status";
            var resultado = await http.get<pinoGPIO>(endpoint);

            return await Task.FromResult<Resultado>(resultado);
        }
    }
}

