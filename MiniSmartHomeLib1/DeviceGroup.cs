using System;
using System.Collections.Generic;
using System.Text;

namespace MiniSmartHomeLib1
{
    public class DeviceGroup
    {
        private readonly List<SmartDevice> _devices = new();

        public void AddDevice(SmartDevice device)
        {
            if (device is null)
                throw new ArgumentException("Device cannot be null.", nameof(device));

            foreach (var d in _devices)
            {
                if (d.DeviceId == device.DeviceId)
                    throw new ArgumentException($"Duplicate device id: {device.DeviceId}", nameof(device));
            }

            _devices.Add(device);
        }

        public void TurnOffAll()
        {
            foreach (var d in _devices)
            {
                d.TurnOff();
            }
        }

        public void PrintStatuses()
        {
            foreach (var d in _devices)
            {
                Console.WriteLine(d.GetStatus());
            }
        }
    }
}
