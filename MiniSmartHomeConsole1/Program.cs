using System;
using MiniSmartHomeLib1;

namespace MiniSmartHomeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var group = new DeviceGroup();

            // One intentional error: try to turn on while offline
            var light = new SmartLight("light-001", "Hallway Light");

            try
            {
                light.TurnOn(); // offline -> should throw
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Caught expected error: {ex.Message}");
            }

            // Normal flow
            light.Rename("Front Hall Light");
            light.SetOnline(true);
            light.TurnOn();
            light.SetBrightness(75);

            group.AddDevice(light);

            Console.WriteLine("\nStatus after setup:");
            group.PrintStatuses();

            // Turn off all via group
            group.TurnOffAll();

            Console.WriteLine("\nStatus after TurnOffAll:");
            group.PrintStatuses();
        }
    }
}