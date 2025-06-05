namespace LightingDevice.Models;

    public class Chandelier : LightFixture
    {
        private int _mode; // 0 - выключено, 1 - режим 1, 2 - режим 2, 3 - оба режима

        public override void TurnOn()
        {
            if (_mode == 3)
            {
                NotifyStatus("Люстра уже работает в обоих режимах.");
                return;
            }

            _mode = (_mode + 1) % 4; // Циклический переход между режимами
            IsOn = _mode != 0;

            if (_mode == 0)
                NotifyStatus("Люстра выключена.");
            else
                NotifyStatus($"Люстра включена в режиме {_mode}.");
        }

        public override void TurnOff()
        {
            if (_mode == 0)
            {
                NotifyStatus("Люстра уже выключена.");
                return;
            }

            _mode = (_mode - 1 + 4) % 4; // Обратный цикл
            IsOn = _mode != 0;  

            if (_mode == 0)
                NotifyStatus("Люстра выключена.");
            else
                NotifyStatus($"Люстра переключена в режим {_mode}.");
        }
    }
