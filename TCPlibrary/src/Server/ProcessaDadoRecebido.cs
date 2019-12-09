using Entidade;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Server
{
    public class ProcessaDadoRecebido<T> : IProcessaDado<T>
    {
        public Task<Resposta> executa(T objeto)
        {
            if (typeof(T) != typeof(System.String))
            {
                string obj = JsonConvert.SerializeObject(objeto);
                Console.WriteLine($"processaDadoRecebido: {obj}");
            }
            else
            {
                Console.WriteLine($"processaDadoRecebido: {objeto}");
            }

            return Task.FromResult<Resposta>(new Resposta(objeto, false));
        }
    }
}
