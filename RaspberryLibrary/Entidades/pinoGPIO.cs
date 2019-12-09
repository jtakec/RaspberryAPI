
namespace RaspberryLibrary.Entidades
{
    public class pinoGPIO
    {
       public string bcmPin { get; set; }
        public string bcmPinNumber { get; set; }
        public string physicalPinNumber { get; set; }
        public string wiringPiPinNumber { get; set; }
        public string header { get; set; }
        public string name { get; set; }
        public string capabilities { get; set; }
        public string value { get; set; }
        public string pinMode { get; set; }
        public string interruptCallback { get; set; }
        public string interruptEdgeDetection { get; set; }
        public string inputPullMode { get; set; }
        public string pwmRegister { get; set; }
        public string pwmMode { get; set; }
        public string pwmRange { get; set; }
        public string pwmClockDivisor { get; set; }
        public string isInSoftToneMode { get; set; }
        public string softToneFrequency { get; set; }
        public string isInSoftPwmMode { get; set; }
        public string softPwmValue { get; set; }
        public string softPwmRange { get; set; }
    }
}

