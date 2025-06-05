namespace LightingDevice.Models;

    public class FloorLamp : LightFixture
    {
        private bool _isPluggedIn; // Флаг подключения к сети

        // Метод для подключения к сети
        public void PlugIn()
        {
            _isPluggedIn = true;
            NotifyStatus("Торшер подключен к сети.");
        }

        public override void TurnOn()
        {
            if (!_isPluggedIn)
            {
                NotifyStatus("Подключите торшер к сети!");
                return;
            }

            IsOn = true;
            NotifyStatus("Торшер включен.");
        }

        public override void TurnOff()
        {
            IsOn = false;
            NotifyStatus("Торшер выключен.");
        }
    }
