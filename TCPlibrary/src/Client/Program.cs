using Client;
using Entidade;
using System;
using System.Threading.Tasks;

namespace TcpEcho
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("use TCPClient IP Porta");
                return;
            }

            string ip = args[0];
            int porta = Convert.ToInt32(args[1]);

            ClientSocket client = new ClientSocket(ip, porta);
            var resposta = client.envia<string>("1010101001").GetAwaiter().GetResult();
            Console.WriteLine(resposta.dado);

            ClientSocket client2 = new ClientSocket(ip, porta);
            var resposta2 = client2.envia<string>("020304050").GetAwaiter().GetResult();
            Console.WriteLine(resposta2.dado);

            ClientSocket client3 = new ClientSocket(ip, porta);
            var resposta3 = client3.envia<Aciona>(new Aciona("rk", "01", 1)).GetAwaiter().GetResult();
            Console.WriteLine(resposta3.dado);

            Console.WriteLine("Aguardando...");

            Console.ReadKey();
        }
    }
}
