using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RaspberryLibrary.Entidades;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryLibrary.Servicos
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "dd/MM/yyyy HH:mm:ss";
        }
    }

    public class HttpCliente
    {
        private HttpClient http;
        private string url;

        public HttpCliente(string url)
        {
            this.url = url;

            http = new HttpClient();
            http.BaseAddress = new Uri(this.url);
        }

        private string getMessage(string msg)
        {
            return $"Erro: url: {this.url} msg: {msg}";
        }

        public async Task<Resultado> get<T>(string url)
        {
            try
            {
                var resp = await http.GetAsync(url);
                if (resp.IsSuccessStatusCode)
                {
                    var json = await resp.Content.ReadAsStringAsync();
                    return new Resultado(JsonConvert.DeserializeObject<T>(json), false);
                }
                else
                {
                    var json = await resp.Content.ReadAsStringAsync();
                    return new Resultado(json, true);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(getMessage("HttpCliente.get()"));
                return new Resultado(getMessage("HttpCliente.get()"), true);
            }
        }

        public async Task<Resultado> post<R,T>(string url, T t) 
        {
            string str = JsonConvert.SerializeObject(t, Formatting.Indented, new CustomDateTimeConverter());
            StringContent conteudo = new StringContent(str, Encoding.UTF8, "application/json");

            try
            {
                var resp = await http.PostAsync(url, conteudo);
                if (resp.IsSuccessStatusCode)
                {
                    var json = await resp.Content.ReadAsStringAsync();
                    return new Resultado(JsonConvert.DeserializeObject<R>(json), false);
                }
                else
                {
                    var json = await resp.Content.ReadAsStringAsync();
                    return new Resultado(json, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(getMessage("HttpCliente.post()"));
                return new Resultado(getMessage("HttpCliente.post()"), true);
            }
        }
    }
}
