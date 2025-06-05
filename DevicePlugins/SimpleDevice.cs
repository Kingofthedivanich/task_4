using PluginContracts;

namespace DevicePlugins
{
    public class SimpleDevice : IDevicePlugin
    {
        public string Name { get; }

        public SimpleDevice(string name)
        {
            Name = name;
        }

        public string SayHello(string user)
        {
            return $"Hello, {user}!";
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
