namespace RaspberryLibrary.Comandos
{
    public class GpioStatusQuery
    {
        public GpioStatusQuery()
        {
        }

        public GpioStatusQuery(string serial, int pino)
        {
            Serial = serial;
            Pino = pino;
        }

        public string Serial { get; set; }
        public int Pino { get; set; }
    }
}
