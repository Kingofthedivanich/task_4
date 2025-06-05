namespace LightingDevice.Models;

    public class Flashlight : LightFixture
    {
        private readonly Random _random = new Random();

        public override void TurnOn()
        {
            if (_random.Next(100) < 95) // 95% шанс включения
            {
                IsOn = true;
                NotifyStatus("Фонарь включен.");
            }
            else
            {
                BreakFixture();
            }
        }

        public override void TurnOff()
        {
            IsOn = false;
            NotifyStatus("Фонарь выключен.");
        }
    }