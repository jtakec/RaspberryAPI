using RaspberryLibrary.Entidades;
using System.Threading.Tasks;

namespace RaspberryLibrary.Comandos
{
    public interface ICommandHandler<T>
    {
        Task<Resultado> Handle(T command);
    }
}
