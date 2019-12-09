using RaspberryLibrary.Entidades;
using System.Threading.Tasks;

namespace RaspberryLibrary.Servicos
{
    public class GetInfo : IProcessaComando
    {
        public async Task<Resultado> executa(string url, int pinNumber)
        {
            HttpCliente http = new HttpCliente(url);

            string endpoint = $"{url}/api/Gpio/info";
            var resultado = await http.get<Informacao>(endpoint);

            return await Task.FromResult<Resultado>(resultado);
        }
    }
}

