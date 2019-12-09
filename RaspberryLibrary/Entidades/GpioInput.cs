namespace RaspberryLibrary.Entidades
{
    public class GpioInput
    {
        public GpioInput() { }
        public GpioInput(int pino, int modo)
        {
            this.pino = pino;
            this.modo = modo;
        }

        public int pino { get; set; }
        public int modo { get; set; }
    }
}
