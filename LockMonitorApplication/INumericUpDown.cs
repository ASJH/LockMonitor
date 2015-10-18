using System;
namespace LockMonitorApplication
{
    interface INumericUpDown
    {
        int AlarmValue { get; set; }
        void InitializeComponent();
        event EventHandler ValueChanged;
    }
}
