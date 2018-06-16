using System;

namespace Blink
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var pin17 = new GpioPin(17, PinDirection.Out))
            {
                for (var i = 0; i < 25; i++)
                {
                    pin17.SetValue(PinValue.High).Wait();
                    System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(250));
                    pin17.SetValue(PinValue.Low).Wait();
                    System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(250));
                }
            }
        }
    }
}
