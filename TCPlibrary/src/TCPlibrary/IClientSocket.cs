using Entidade;
using System.Threading.Tasks;

namespace Client
{
    public interface IClientSocket
    {
        Task<Resposta> envia<T>(T objeto);
    }
}
