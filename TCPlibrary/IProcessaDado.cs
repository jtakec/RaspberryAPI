using Entidade;
using System.Threading.Tasks;

namespace Server
{
    public interface IProcessaDado<T>
    {
        Task<Resposta> executa(T objeto);
    }
}
