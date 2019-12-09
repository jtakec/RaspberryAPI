using Entidade;
using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("use TCPServer Porta");
                return;
            }

            int porta = Convert.ToInt32(args[0]);

            //IProcessaDado<Aciona> processa = new ProcessaDadoRecebido<Aciona>();
            //ServerSocket<Aciona> socket = new ServerSocket<Aciona>(porta, processa);

            IProcessaDado<string> processa = new ProcessaDadoRecebido<string>();
            ServerSocket<string> socket = new ServerSocket<string>(porta, processa);

            await Task.Run(() =>
             {
                 socket.Ouvindo();
             });

            while (true)
            {
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}
