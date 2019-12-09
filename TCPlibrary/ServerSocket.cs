using Entidade;
using Newtonsoft.Json;
using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ServerSocket<T> where T : class
    {
        private int porta = 3000;
        private IProcessaDado<T> processa;

        public ServerSocket(int porta, IProcessaDado<T> processa)
        {
            this.porta = porta;
            this.processa = processa;
        }

        public async void Ouvindo()
        {
            Console.WriteLine($"Aguardando na porta:{porta}");

            var listenSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(new IPEndPoint(IPAddress.Any, porta));
            listenSocket.Listen(120);

            while (true)
            {
                try
                {
                    var socket = await listenSocket.AcceptAsync();
                    await ProcessLinesAsync(socket);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(ex));
                }
            }
        }

        private async Task ProcessLinesAsync(Socket socket)
        {
            Console.WriteLine($"[{socket.RemoteEndPoint}]: conectado");

            var stream = new NetworkStream(socket);
            var reader = PipeReader.Create(stream);

            ReadResult result = await reader.ReadAsync();
            ReadOnlySequence<byte> buffer = result.Buffer;

            while (TryReadLine(ref buffer, out ReadOnlySequence<byte> line))
            {
                string str = ProcessLine(line);
                Console.WriteLine($"recebido: {str}");

                Resposta resposta = new Resposta();
                if (typeof(T) != typeof(System.String))
                {
                    T obj = JsonConvert.DeserializeObject<T>(str);
                    resposta = await processa.executa(obj);
                }
                else
                {
                    resposta = await processa.executa(str as T);
                }

                var bytes = System.Text.UTF8Encoding.UTF8.GetBytes($"{JsonConvert.SerializeObject(resposta)}" + "\n");
                await stream.WriteAsync(bytes, 0, bytes.Length);
            }

            reader.AdvanceTo(buffer.Start, buffer.End);
            await reader.CompleteAsync();

            Console.WriteLine($"[{socket.RemoteEndPoint}]: disconectado");
        }

        private bool TryReadLine(ref ReadOnlySequence<byte> buffer, out ReadOnlySequence<byte> line)
        {
            SequencePosition? position = buffer.PositionOf((byte)'\n');

            if (position == null)
            {
                line = default;
                return false;
            }

            // Skip the line + the \n.
            line = buffer.Slice(0, position.Value);
            buffer = buffer.Slice(buffer.GetPosition(1, position.Value));

            return true;
        }

        private string ProcessLine(ReadOnlySequence<byte> buffer)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var segment in buffer)
            {
//#if NETCOREAPP2_1
                //Console.Write(Encoding.UTF8.GetString(segment.Span));
//                sb.Append(Encoding.UTF8.GetString(segment.Span));
//#else
                //Console.Write(Encoding.UTF8.GetString(segment));
               sb.Append(Encoding.UTF8.GetString(segment.ToArray()));
//#endif
            }

            return sb.ToString();
        }
    }
}
