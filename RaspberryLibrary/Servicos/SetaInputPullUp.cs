using RaspberryLibrary.Entidades;
using System.Threading.Tasks;

namespace RaspberryLibrary.Servicos
{
    public class SetaInputPullUp : IProcessaComando
    {
        public async Task<Resultado> executa(string url, int pinNumber)
        {
            HttpCliente http = new HttpCliente(url);

            string endpoint = $"{url}/api/Gpio/input";
            var resultado = await http.post<pinoGPIOCompacto, GpioInput>(endpoint, new GpioInput(pinNumber, 2));  // set: modo = input, inputMode = pullDown

            return await Task.FromResult<Resultado>(resultado);
        }
    }
}

