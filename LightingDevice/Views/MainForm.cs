using System;
using System.Windows.Forms;
using LightingDevice.ViewModels;

namespace LightingDevice.Views
{
    public partial class MainForm : Form
    {
        private readonly MainViewModel _viewModel;

        public MainForm()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
        }

        // Заглушка для обработчика, чтобы не было ошибки компиляции
        private void TurnOnButton_Click(object sender, EventArgs e)
        {
            // Реализация по необходимости
        }

        // Заглушка для обработчика TurnOffButton_Click
        private void TurnOffButton_Click(object sender, EventArgs e)
        {
            // Реализация по необходимости
        }

        // Заглушка для обработчика PlugInButton_Click
        private void PlugInButton_Click(object sender, EventArgs e)
        {
            // Реализация по необходимости
        }
    }
}
