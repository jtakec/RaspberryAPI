using Entidade;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Client
{
    public class ClientSocket : IClientSocket
    {
        private int porta;
        private IPAddress address;
        private NetworkStream stream;

        public ClientSocket(string ip, int porta)
        {
            this.porta = porta;
            address = IPAddress.Parse(ip);

            var clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(address, porta));

            stream = new NetworkStream(clientSocket);

            Console.WriteLine($"Conectando para {address.ToString()}:{porta}");
        }

        public async Task<Resposta> envia<T>(T objeto)
        {
            //Console.WriteLine($"{objeto.GetType() == typeof(System.String)}");

            if (objeto.GetType() != typeof(System.String))
            {
                string str = JsonConvert.SerializeObject(objeto);
                var bytes = System.Text.UTF8Encoding.UTF8.GetBytes(str + "\n");
                await stream.WriteAsync(bytes, 0, bytes.Count());
            }
            else
            {
                var bytes = System.Text.UTF8Encoding.UTF8.GetBytes(objeto + "\n");
                await stream.WriteAsync(bytes, 0, bytes.Count());
            }

            var lido = new StreamReader(stream);

            return new Resposta(lido.ReadLine(), false);
        }
    }
}
