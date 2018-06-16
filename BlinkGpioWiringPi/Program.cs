using System;

namespace BlinkGpioWiringPi
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = WiringPi.Init.WiringPiSetupGpio();

            if(result == -1)
            {
                System.Console.WriteLine($"WiringPi init has failed: {result}");
                return;
            }

             WiringPi.GPIO.pinMode(17,(int)WiringPi.GPIO.GPIOpinmode.Output);

            for(var i = 0; i < 25; i++)
            {
                WiringPi.GPIO.digitalWrite(17,(int)WiringPi.GPIO.GPIOpinvalue.High);
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(250));

                WiringPi.GPIO.digitalWrite(17,(int)WiringPi.GPIO.GPIOpinvalue.Low);
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(250));
            }
        }
    }
}
