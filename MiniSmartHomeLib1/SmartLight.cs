using System;
using System.Collections.Generic;
using System.Text;

namespace MiniSmartHomeLib1
{
    public class SmartLight : SmartDevice
    {
        public int Brightness { get; private set; }  // not publicly settable

        public SmartLight(string deviceId, string name)
            : base(deviceId, name)
        {
            Brightness = 0;
        }

        public void SetBrightness(int value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Brightness must be between 0 and 100.", nameof(value));

            if (!Power.IsPoweredOn)
                throw new InvalidOperationException("Cannot set brightness while the light is off.");

            Brightness = value;
        }

        public override string GetStatus()
        {
            return $"[SmartLight] Id={DeviceId}, Name={Name}, Online={Power.IsOnline}, PoweredOn={Power.IsPoweredOn}, Brightness={Brightness}";
        }
    }
