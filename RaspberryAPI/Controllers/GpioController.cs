using Microsoft.AspNetCore.Mvc;
using RaspberryLibrary.Entidades;
using System.Collections.Generic;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;

namespace Raspberry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GpioController : ControllerBase
    {
        [HttpGet("info")]
        public ActionResult GetInfo()
        {
            return Ok(Pi.Info);
        }

        [HttpGet("{pinNumber}/status")]
        public ActionResult GetDetalhes(int pinNumber)
        {
            var pin = Pi.Gpio[pinNumber];
            pin.Read();

            return Ok(pin);
        }

        [HttpGet("status")]
        public ActionResult GetDetalhes()
        {
            List<IGpioPin> pins = new List<IGpioPin>();
            for (var i = 0; i <= 40; i++)
            {
                try
                {
                    var pin = Pi.Gpio[i];
                    pin.Read();
                    pins.Add(pin);
                }
                catch { }
            }
            return Ok(pins);
        }

        [HttpPost("Input")]
        public ActionResult SetInput([FromBody] GpioInput gpio)
        {
            var pin = Pi.Gpio[gpio.pino];
            pin.PinMode = GpioPinDriveMode.Input;

            if (gpio.modo == 0)
                pin.InputPullMode = GpioPinResistorPullMode.Off;
            else if (gpio.modo == 1)
                pin.InputPullMode = GpioPinResistorPullMode.PullDown;
            else if (gpio.modo == 2)
                pin.InputPullMode = GpioPinResistorPullMode.PullUp;

            pin.Read();
            
            return Ok(pin);
        }

        [HttpPost("Output")]
        public ActionResult SetOutput([FromBody] GpioOutput gpio)
        {
            var pin = Pi.Gpio[gpio.pino];
            pin.PinMode = GpioPinDriveMode.Output;

            if (gpio.status == 0)
                pin.Write(GpioPinValue.Low);
            else
                pin.Write(GpioPinValue.High);

            pin.Read();

            return Ok(pin);
       }

    }
}
