using RaspberryLibrary.Entidades;
using System.Threading.Tasks;

namespace RaspberryLibrary.Servicos
{
    public interface IProcessaComando
    {
        Task<Resultado> executa(string url, int pinNumber);
    }
}
