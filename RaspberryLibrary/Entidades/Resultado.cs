namespace RaspberryLibrary.Entidades
{
    public class Resultado
    {
        public Resultado()
        {
        }

        public Resultado(object dado, bool temErro)
        {
            this.dado = dado;
            this.temErro = temErro;
        }

        public object dado { get; set; }
        public bool temErro { get; set; }
    }
}
