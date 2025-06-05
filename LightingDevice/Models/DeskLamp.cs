namespace LightingDevice.Models;

    public class DeskLamp : LightFixture
    {
        private bool _isPluggedIn; // Флаг подключения к сети

        // Метод для подключения к сети
        public void PlugIn()
        {
            _isPluggedIn = true;
            NotifyStatus("Настольная лампа подключена к сети.");
        }

        public override void TurnOn()
        {
            if (!_isPluggedIn)
            {
                NotifyStatus("Подключите настольную лампу к сети!");
                return;
            }

            IsOn = true;
            NotifyStatus("Настольная лампа включена.");
        }

        public override void TurnOff()
        {
            IsOn = false;
            NotifyStatus("Настольная лампа выключена.");
        }
    }
