using RaspberryLibrary.Entidades;
using System.Threading.Tasks;

namespace RaspberryLibrary.Servicos
{
    public class SetaOutputBaixo : IProcessaComando
    {
        public async Task<Resultado> executa(string url, int pinNumber)
        {
            HttpCliente http = new HttpCliente(url);

            string endpoint = $"{url}/api/Gpio/output";
            var resultado = await http.post<pinoGPIOCompacto, GpioOutput>(endpoint, new GpioOutput(pinNumber, 0));  // set: modo = output, status = baixo/low

            return await Task.FromResult<Resultado>(resultado);
        }
    }
}
