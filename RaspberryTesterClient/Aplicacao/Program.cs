using RaspberryLibrary.Servicos;
using System;
using System.Collections.Generic;

namespace RaspberryTesterClient
{
    class Program
    {
        private static string filename = "app.json";
        static void Main(string[] args)
        {
            Console.WriteLine("Raspberry PI 3 ou superior - Testador");

            Dictionary<int, IProcessaComando> comandos = new Dictionary<int, IProcessaComando>()
            {
                { 1, new GetInfo() },
                { 2, new GetStatus() },
                { 3, new SetaInputOff() },
                { 4, new SetaInputPullDown() },
                { 5, new SetaInputPullUp() },
                { 6, new SetaOutputAlto() },
                { 7, new SetaOutputBaixo() }
            };

            Dictionary<int, string> opcoes = new Dictionary<int,string>()
            {
                { 1, "Informação do raspberry" },
                { 2, "Status do pino" },
                { 3, "Seta input para Off"},
                { 4, "Seta input para PullDown"},
                { 5, "Seta input para PullUp"},
                { 6, "Seta output para alto"},
                { 7, "Seta output para baixo" },
                { 8, "Altera o número do pino"},
                { 9, "Finaliza programa" },
            };

            string url = Servico.getConfiguracao(filename).url;

            Console.WriteLine($"{url}");
            Console.WriteLine();

            ProcessaComando processaComando = new ProcessaComando(url, comandos);

            int pinNumber = -1;
            while (true)
            {
                if (pinNumber == -1)
                    pinNumber = Servico.getPinNumber();

                var cmd = Servico.getOpcao(opcoes);
                if (cmd == 8)
                {
                    pinNumber = -1;
                    continue;
                }

                if (cmd == 9)
                    break;

                processaComando.processa(cmd, pinNumber);

                Console.WriteLine();
            }
        }
    }
}
