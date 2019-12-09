namespace Entidade
{
    public class Aciona
    {
        public Aciona() { }

        public Aciona(string cliente, string ponto, int aciona)
        {
            this.cliente = cliente;
            this.ponto = ponto;
            this.aciona = aciona;
        }

        public string cliente { get; set; }
        public string ponto { get; set; }
        public int aciona { get; set; }
    }
}
