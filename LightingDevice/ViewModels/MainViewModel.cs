using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using LightingDevice; // Для RelayCommand

namespace LightingDevice.ViewModels
{
    public class MethodParameter : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public Type ParameterType { get; set; }
        private string _value;
        public string Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class MethodInfoViewModel
    {
        public MethodInfo MethodInfo { get; set; }
        public string Name => MethodInfo.Name;
        public ObservableCollection<MethodParameter> Parameters { get; set; } = new();
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private string _assemblyPath;
        public string AssemblyPath
        {
            get => _assemblyPath;
            set
            {
                if (_assemblyPath != value)
                {
                    _assemblyPath = value;
                    OnPropertyChanged(nameof(AssemblyPath));
                }
            }
        }

        public ObservableCollection<Type> PluginTypes { get; set; } = new();

        private Type _selectedPluginType;
        public Type SelectedPluginType
        {
            get => _selectedPluginType;
            set
            {
                if (_selectedPluginType != value)
                {
                    _selectedPluginType = value;
                    OnPropertyChanged(nameof(SelectedPluginType));
                    Methods.Clear();
                    if (_selectedPluginType != null)
                    {
                        var methods = _selectedPluginType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                        foreach (var m in methods)
                        {
                            var vm = new MethodInfoViewModel
                            {
                                MethodInfo = m,
                                Parameters = new ObservableCollection<MethodParameter>(
                                    m.GetParameters().Select(p => new MethodParameter { Name = p.Name, ParameterType = p.ParameterType })
                                )
                            };
                            Methods.Add(vm);
                        }
                    }
                }
            }
        }

        public ObservableCollection<MethodInfoViewModel> Methods { get; set; } = new();

        private MethodInfoViewModel _selectedMethod;
        public MethodInfoViewModel SelectedMethod
        {
            get => _selectedMethod;
            set
            {
                if (_selectedMethod != value)
                {
                    _selectedMethod = value;
                    OnPropertyChanged(nameof(SelectedMethod));
                }
            }
        }

        private string _result;
        public string Result
        {
            get => _result;
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public ICommand LoadAssemblyCommand { get; }
        public ICommand ExecuteMethodCommand { get; }

        public MainViewModel()
        {
            LoadAssemblyCommand = new RelayCommand(_ => LoadAssembly());
            ExecuteMethodCommand = new RelayCommand(_ => ExecuteMethod());
        }

        private void LoadAssembly()
        {
            if (string.IsNullOrWhiteSpace(AssemblyPath) || !File.Exists(AssemblyPath)) return;
            try
            {
                var assembly = Assembly.LoadFrom(AssemblyPath);

                var allTypes = assembly.GetTypes();

                // Ищем все классы, реализующие интерфейс с полным именем "PluginContracts.IDevicePlugin"
                var types = allTypes
                    .Where(t => t.IsClass && !t.IsAbstract &&
                                t.GetInterfaces().Any(i => i.FullName == "PluginContracts.IDevicePlugin"))
                    .ToList();

                PluginTypes.Clear();
                foreach (var t in types)
                    PluginTypes.Add(t);
            }
            catch (ReflectionTypeLoadException)
            {
                PluginTypes.Clear();
            }
            catch
            {
                PluginTypes.Clear();
            }
        }

        private void ExecuteMethod()
        {
            if (SelectedPluginType == null || SelectedMethod == null) return;
            try
            {
                var ctor = SelectedPluginType.GetConstructors().OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
                object[] ctorParams = ctor?.GetParameters().Select(p => GetDefaultValue(p.ParameterType)).ToArray() ?? Array.Empty<object>();
                var instance = Activator.CreateInstance(SelectedPluginType, ctorParams);

                var paramValues = SelectedMethod.Parameters
                    .Select(p => ConvertParameter(p.Value, p.ParameterType))
                    .ToArray();

                var result = SelectedMethod.MethodInfo.Invoke(instance, paramValues);
                Result = result?.ToString();
            }
            catch (Exception ex)
            {
                Result = $"Ошибка: {ex.Message}";
            }
        }

        private object GetDefaultValue(Type t)
        {
            if (t == typeof(string)) return string.Empty;
            if (t.IsValueType) return Activator.CreateInstance(t);
            return null;
        }

        private object ConvertParameter(string value, Type targetType)
        {
            if (targetType == typeof(string)) return value ?? "";
            if (string.IsNullOrWhiteSpace(value)) return GetDefaultValue(targetType);
            try
            {
                return Convert.ChangeType(value, targetType);
            }
            catch
            {
                return GetDefaultValue(targetType);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
