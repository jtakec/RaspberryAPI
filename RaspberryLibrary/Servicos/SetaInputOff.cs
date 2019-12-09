using RaspberryLibrary.Entidades;
using System.Threading.Tasks;

namespace RaspberryLibrary.Servicos
{
    public class SetaInputOff : IProcessaComando
    {
        public async Task<Resultado> executa(string url, int pinNumber)
        {
            HttpCliente http = new HttpCliente(url);

            string endpoint = $"{url}/api/Gpio/input";
            var resultado = await http.post<pinoGPIOCompacto, GpioInput>(endpoint, new GpioInput(pinNumber, 0));  // set: modo = input, inputMode = off

            return await Task.FromResult<Resultado>(resultado);
        }
    }
}

