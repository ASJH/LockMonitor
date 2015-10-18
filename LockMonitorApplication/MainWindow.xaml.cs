using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace LockMonitorApplication
{
    /// <summary>
    /// Interaction logic for LockView.xaml
    /// </summary>
    public partial class LockView : Window, ILockView
    {
        SoundPlayer alarm = new SoundPlayer(@"..\..\..\Mutable.wav");
        public LockView()
        {
            InitializeComponent();
            LockFactory factory = new LockFactory();
            LockMonitorController controller = new LockMonitorController(this, factory);
            controller.RunMonitor();
        }

        public void soundMutableAlarm()
        {
            alarm.Stop();
            alarm.Play();
        }
    }
}
