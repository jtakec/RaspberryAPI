using RaspberryLibrary.Entidades;
using RaspberryLibrary.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RaspberryTesterClient
{
    class Program
    {
        private static string filename = "app.json";
        private static int numInput = 17;
        private static int numOutput = 4;
        static void Main(string[] args)
        {
            string url = Servico.getConfiguracao(filename).url;

            MapaInput mapaInput = new MapaInput();
            for (var i = 1; i <= numInput; i++)
            {
                var gpio = mapaInput.getGpio(i);
                new SetaInputPullUp().executa(url, gpio).GetAwaiter().GetResult();
            }

            MapaOutput mapaOutput = new MapaOutput();
            for (var i = 1; i <= numOutput; i++)
            {
                var gpio = mapaOutput.getGpio(i);
                new SetaOutputBaixo().executa(url, mapaOutput.getGpio(1)).GetAwaiter().GetResult();
            }

            while (true)
            {
                var resultado = new GetStatusAll().executa(url, 0).GetAwaiter().GetResult();
                var pinos = resultado.dado as List<pinoGPIOCompacto>;

                Console.Clear();

                Console.WriteLine("Raspberry PI 3 ou superior - Monitor");
                Console.WriteLine($"{url}");
                Console.WriteLine($"{DateTime.Now}");
                Console.WriteLine();

                Console.Write("Input :");
                for (var i = 1; i <= numInput; i++)
                {
                    int ipino = mapaInput.getGpio(i);
                    var pino = pinos.Where(c => c.bcmPinNumber == ipino.ToString()).FirstOrDefault();
                    Console.Write($"|{i.ToString().PadLeft(2, '0')}");
                }

                Console.WriteLine();
                Console.Write("Valor :");
                for (var i = 1; i <= numInput; i++)
                {
                    int ipino = mapaInput.getGpio(i);
                    var pino = pinos.Where(c => c.bcmPinNumber == ipino.ToString()).FirstOrDefault();
                    var valor = pino.value == "true" ? "T" : "F";
                    Console.Write($"| {valor}");
                }

                Console.WriteLine();
                Console.WriteLine();

                Console.Write("Output:");
                for (var i = 1; i <= numOutput; i++)
                {
                    int ipino = mapaOutput.getGpio(i);
                    var pino = pinos.Where(c => c.bcmPinNumber == ipino.ToString()).FirstOrDefault();
                    Console.Write($"|{i.ToString().PadLeft(2, '0')}");
                }

                Console.WriteLine();
                Console.Write("Valor :");
                for (var i = 1; i <= numOutput; i++)
                {
                    int ipino = mapaOutput.getGpio(i);
                    var pino = pinos.Where(c => c.bcmPinNumber == ipino.ToString()).FirstOrDefault();
                    var valor = pino.value == "true" ? "T" : "F";
                    Console.Write($"| {valor}");
                }
                Console.WriteLine();
                System.Threading.Thread.Sleep(3000);
            }
        }
    }
}
