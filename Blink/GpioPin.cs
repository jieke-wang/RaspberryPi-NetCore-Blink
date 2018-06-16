using System;
using System.IO;
using System.Threading.Tasks;

namespace Blink
{
    public enum PinDirection
    {
        In,
        Out
    }

    public enum PinValue
    {
        Low = 0,
        High = 1
    }

    public class GpioPin : IDisposable
    {
        public static string GpioRoot {get;set;}
        public int Number { get; }
        public PinDirection Direction { get; }

        public GpioPin(int number, PinDirection direction)
        {
            Number = number;
            Direction = direction;

            try
            {
                //attempt cleanup so we can ensure the pin is good to go
                UnExport();
            }catch
            { 
                //don't worry about it, looks like it's good to go
            }
            Export();
            SetDirection();
        }

        private void UnExport()
        {
            File.WriteAllText("/sys/class/gpio/unexport", Number.ToString());
        }

        private void Export()
        {
            File.WriteAllText("/sys/class/gpio/export", Number.ToString());
        }

        private void SetDirection()
        {
            File.WriteAllText($"/sys/class/gpio/gpio{Number}/direction", Direction.ToString().ToLower());
        }

        public async Task SetValue(PinValue value)
        {
            Console.WriteLine($"Setting Pin {Number} to {value}");
            await File.WriteAllTextAsync($"/sys/class/gpio/gpio{Number}/value", ((int)value).ToString());
        }

        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
        }

        ~GpioPin()
        {
            Dispose(false);
        }

        private void Dispose(bool fromManaged)
        {
            if(_disposed)
            { return; }

            UnExport();
            _disposed = true;
            Console.WriteLine("Pin disposed");
        }
    }

}