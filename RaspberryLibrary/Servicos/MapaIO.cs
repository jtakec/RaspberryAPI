using System.Collections.Generic;
using System.Linq;

namespace RaspberryLibrary.Servicos
{
    public class MapaIO
    {
        public MapaIO(int pino, int gpio)
        {
            this.pino = pino;
            this.gpio = gpio;
        }
        public int pino { get; set; }
        public int gpio { get; set; }
    }

    public interface IMapaIO
    {
         int getGpio(int pino);
         int getPino(int gpio);
    }

    public class MapaInput :IMapaIO
    {
        private List<MapaIO> mapas;

        public MapaInput()
        {
            mapas = new List<MapaIO>();

            mapas.Add(new MapaIO(01, 12));
            mapas.Add(new MapaIO(02, 05));
            mapas.Add(new MapaIO(03, 07));
            mapas.Add(new MapaIO(04, 11));
            mapas.Add(new MapaIO(05, 08));
            mapas.Add(new MapaIO(06, 09));
            mapas.Add(new MapaIO(07, 25));
            mapas.Add(new MapaIO(08, 10));
            mapas.Add(new MapaIO(09, 24));
            mapas.Add(new MapaIO(10, 22));
            mapas.Add(new MapaIO(11, 23));
            mapas.Add(new MapaIO(12, 27));
            mapas.Add(new MapaIO(13, 18));
            mapas.Add(new MapaIO(14, 17));
            mapas.Add(new MapaIO(15, 04));
            mapas.Add(new MapaIO(16, 03));
            mapas.Add(new MapaIO(17, 02));
        }

        public int getGpio(int pino)
        {
            var mapa = mapas.Where(c => c.pino == pino).FirstOrDefault();
            if (mapa == null)
                return 0;
            else
                return mapa.gpio;
        }

        public int getPino(int gpio)
        {
            var mapa = mapas.Where(c => c.gpio == gpio).FirstOrDefault();
            if (mapa == null)
                return 0;
            else
                return mapa.pino;
        }
    }

    public class MapaOutput : IMapaIO
    {
        private List<MapaIO> mapas;
        public MapaOutput()
        {
            mapas = new List<MapaIO>();

            mapas.Add(new MapaIO(1, 06));
            mapas.Add(new MapaIO(2, 13));
            mapas.Add(new MapaIO(3, 19));
            mapas.Add(new MapaIO(4, 26));
        }

        public int getGpio(int pino)
        {
            var mapa = mapas.Where(c => c.pino == pino).FirstOrDefault();
            if (mapa == null)
                return 0;
            else
                return mapa.gpio;
        }

        public int getPino(int gpio)
        {
            var mapa = mapas.Where(c => c.gpio == gpio).FirstOrDefault();
            if (mapa == null)
                return 0;
            else
                return mapa.pino;
        }
    }
}
