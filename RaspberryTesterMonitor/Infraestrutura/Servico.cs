using Newtonsoft.Json;
using RaspberryLibrary.Entidades;
using System;
using System.Collections.Generic;
using System.IO;

namespace RaspberryTesterClient
{
    public static class Servico
    {
        public static int getPinNumber()
        {
            Console.Write("Entre com o número do pino:");
            var pinNumber = Console.ReadLine();
            return Convert.ToInt32(pinNumber);
        }

        public static int getOpcao(Dictionary<int, string> opcoes)
        {
            Console.WriteLine("Digite o número do comando:");

            foreach (var opcao in opcoes)
            {
                Console.WriteLine($"{opcao.Key}) {opcao.Value}");
            }

            var cmd = Console.ReadLine();
            return Convert.ToInt32(cmd);
        }

        public static Configuracao getConfiguracao(string filename)
        {
            string json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<Configuracao>(json);
        }
    }
}
