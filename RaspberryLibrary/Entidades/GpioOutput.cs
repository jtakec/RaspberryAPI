namespace RaspberryLibrary.Entidades
{
    public class GpioOutput
    {
        public GpioOutput() { }
        public GpioOutput(int pino, int status)
        {
            this.pino = pino;
            this.status = status;
        }

        public int pino { get; set; }
        public int status { get; set; }
    }
}
