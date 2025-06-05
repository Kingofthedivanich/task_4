namespace LightingDevice.Models;

    public abstract class LightFixture
    {
        // Событие для уведомления об изменении состояния
        public event Action<string> StatusUpdated;

        // Свойство: Включено или нет
        public bool IsOn { get; protected set; }

        // Конструктор
        protected LightFixture()
        {
            IsOn = false;
        }

        // Абстрактные методы для включения и выключения
        public abstract void TurnOn();
        public abstract void TurnOff();

        // Метод для вызова события поломки
        protected void BreakFixture()
        {
            IsOn = false;
            NotifyStatus("Прибор сломан!");
        }

        // Метод для отправки уведомлений
        protected void NotifyStatus(string message)
        {
            StatusUpdated?.Invoke(message);
        }
    }
