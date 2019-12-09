using RaspberryLibrary.Entidades;
using System.Threading.Tasks;

namespace RaspberryLibrary.Servicos
{
    public class SetaOutputAlto : IProcessaComando
    {
        public async Task<Resultado> executa(string url, int pinNumber)
        {
            HttpCliente http = new HttpCliente(url);

            string endpoint = $"{url}/api/Gpio/output";
            var resultado = await http.post<pinoGPIOCompacto, GpioOutput>(endpoint, new GpioOutput(pinNumber, 1));  // set: modo = output, status = alto/high

            return await Task.FromResult<Resultado>(resultado);
        }
    }
}
