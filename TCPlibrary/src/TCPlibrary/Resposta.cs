namespace Entidade
{
    public class Resposta
    {
        public Resposta() {
            dado = null;
            temErro = false;
        }

        public Resposta(object dado, bool temErro)
        {
            this.dado = dado;
            this.temErro = temErro;
        }

        public object dado { get; set; }
        public bool temErro { get; set; }
    }
}