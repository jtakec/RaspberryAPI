using Newtonsoft.Json;
using RaspberryLibrary.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaspberryTesterClient
{
    public class ProcessaComando
    {
        private Dictionary<int, IProcessaComando> comandos;
        private string url;
        public ProcessaComando(string url, Dictionary<int, IProcessaComando> comandos)
        {
            this.url = url;
            this.comandos = comandos;
        }

        public async void processa(int cmd, int pinNumber)
        {
            var resultado = await comandos[cmd].executa(url, pinNumber);

            Console.WriteLine("Resultado:");
            Console.WriteLine(JsonConvert.SerializeObject(resultado.dado, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            }));

            await Task.CompletedTask;
        }
    }
}
