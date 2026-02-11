namespace MiniSmartHomeLib1
{
    public class PowerModule
    {
        public bool IsOnline { get; private set; }
        public bool IsPoweredOn { get; private set; }

        public void SetOnline(bool online)
        {
            IsOnline = online;

            // Optional safety behavior: if a device goes offline, it can't stay "on".
            if (!IsOnline && IsPoweredOn)
            {
                IsPoweredOn = false;
            }
        }

        public void TurnOn()
        {
            if (!IsOnline)
                throw new InvalidOperationException("Cannot turn on while offline.");

            IsPoweredOn = true;
        }

        public void TurnOff()
        {
            IsPoweredOn = false;
        }
    }
}
