using System.ComponentModel;

namespace LightingDevice.Views;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private ComboBox FixtureComboBox;
    private Button TurnOnButton;
    private Button TurnOffButton;
    private Button PlugInButton;
    private TextBox StatusTextBox;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.FixtureComboBox = new ComboBox();
        this.TurnOnButton = new Button();
        this.TurnOffButton = new Button();
        this.PlugInButton = new Button();
        this.StatusTextBox = new TextBox();

        this.SuspendLayout();

        // Настройка ComboBox
        this.FixtureComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        this.FixtureComboBox.Location = new System.Drawing.Point(12, 12);
        this.FixtureComboBox.Size = new System.Drawing.Size(200, 24);

        // Настройка кнопки "Включить"
        this.TurnOnButton.Location = new System.Drawing.Point(12, 12);
        this.TurnOnButton.Name = "TurnOnButton";
        this.TurnOnButton.Size = new System.Drawing.Size(120, 23);
        this.TurnOnButton.TabIndex = 0;
        this.TurnOnButton.Text = "Включить";
        this.TurnOnButton.UseVisualStyleBackColor = true;
        this.TurnOnButton.Click += new EventHandler(this.TurnOnButton_Click);

        // Настройка кнопки "Выкл"
        this.TurnOffButton.Location = new System.Drawing.Point(117, 50);
        this.TurnOffButton.Size = new System.Drawing.Size(95, 30);
        this.TurnOffButton.Text = "Выкл";
        this.TurnOffButton.Click += new EventHandler(this.TurnOffButton_Click);

        // Настройка кнопки "Подключить к сети"
        this.PlugInButton.Location = new System.Drawing.Point(12, 90);
        this.PlugInButton.Size = new System.Drawing.Size(200, 30);
        this.PlugInButton.Text = "Подключить к сети";
        this.PlugInButton.Click += new EventHandler(this.PlugInButton_Click);

        // Настройка TextBox для логов
        this.StatusTextBox.Location = new System.Drawing.Point(12, 130);
        this.StatusTextBox.Multiline = true;
        this.StatusTextBox.ReadOnly = true;
        this.StatusTextBox.ScrollBars = ScrollBars.Vertical;
        this.StatusTextBox.Size = new System.Drawing.Size(400, 200);

        // Настройка формы
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.FixtureComboBox);
        this.Controls.Add(this.TurnOnButton);
        this.Controls.Add(this.TurnOffButton);
        this.Controls.Add(this.PlugInButton);
        this.Controls.Add(this.StatusTextBox);
        this.Name = "MainForm";
        this.Text = "MainForm";
        this.ResumeLayout(false);
    }

    #endregion
}
