namespace RaspberryLibrary.Entidades
{
    public class Informacao
    {
        public operatingSystem operatingSystem { get; set; }
        public string raspberryPiVersion { get; set; }
        public string boardRevision { get; set; }
        public string processorCount { get; set; }
        public string modelName { get; set; }
        public string hardware { get; set; }
        public string revision { get; set; }
        public string serial { get; set; }
    }

    public class operatingSystem
    {
        public string sysName { get; set; }
        public string nodeName { get; set; }
        public string release { get; set; }
        public string machine { get; set; }
    }
}
