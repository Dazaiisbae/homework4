using System;
using System.Collections.Generic;
using System.Text;

namespace MiniSmartHomeLib1
{
    public abstract class SmartDevice
    {
        public string DeviceId { get; }
        public string Name { get; private set; }
        public PowerModule Power { get; }

        protected SmartDevice(string deviceId, string name)
        {
            if (string.IsNullOrWhiteSpace(deviceId))
                throw new ArgumentException("DeviceId cannot be null/blank.", nameof(deviceId));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null/blank.", nameof(name));

            DeviceId = deviceId;
            Name = name;

            // Composition: base class creates it (devices don't wire it).
            Power = new PowerModule();
        }

        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("New name cannot be blank.", nameof(newName));

            Name = newName;
        }

        public virtual void SetOnline(bool online)
        {
            Power.SetOnline(online);
        }

        public virtual void TurnOn()
        {
            Power.TurnOn();
        }

        public virtual void TurnOff()
        {
            Power.TurnOff();
        }

        public abstract string GetStatus();
    }
}
