using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;

namespace LockMonitorApplication
{
    public class LockMonitorController
	{
		readonly LockView _mainWindow = null;
		readonly ILockFactory _lockFactory = null;
		DispatcherTimer _tickTimer = new DispatcherTimer ();
		LockDataReader _dataReader;
		ILockData _lockData;
		LockAlarmer _alarmer;

        CheckBox _alarmMuter;
        Label _upperLevel;
        Label _lowerLevel;
        Label _flowRate;

		public LockMonitorController (LockView window, ILockFactory lockFactory)
		{
			_lockFactory = lockFactory;
			_mainWindow = window;
            _upperLevel = _mainWindow.upperLevel;
            _lowerLevel = _mainWindow.lowerLevel;
            _flowRate = _mainWindow.flowRate;
            _alarmMuter = _mainWindow.alarmMuter;
		}

		public void RunMonitor ()
		{
			setupComponents ();
			setupUI ();
		}

		void setupUI ()
        {
            _mainWindow.lockSelector.SelectionChanged
                += new System.Windows.Controls.SelectionChangedEventHandler(newLockSelected);

            _mainWindow.upDownUpperLevel.AlarmValue = (int)DefaultSettings.HIGH_UPPER_LEVEL;
            _mainWindow.upDownLowerLevel.AlarmValue = (int)DefaultSettings.HIGH_LOWER_LEVEL;
            _mainWindow.upDownFlowRate.AlarmValue = (int)DefaultSettings.HIGH_FLOW_RATE;

            _mainWindow.upDownUpperLevel.ValueChanged += new EventHandler(limitsChanged);
            _mainWindow.upDownLowerLevel.ValueChanged += new EventHandler(limitsChanged);
            _mainWindow.upDownFlowRate.ValueChanged += new EventHandler(limitsChanged);
		}

		void limitsChanged (object sender, EventArgs e)
		{
            _alarmer.UpperLevelTester.UpperLimit = _mainWindow.upDownUpperLevel.AlarmValue;
            _alarmer.LowerLevelTester.UpperLimit = _mainWindow.upDownLowerLevel.AlarmValue;
            _alarmer.FlowRateTester.UpperLimit = _mainWindow.upDownFlowRate.AlarmValue;
		}

		void setupComponents ()
		{
			_lockData = (LockData)_lockFactory.CreateandReturnObj (LockClassesEnumeration.LockData);
			_dataReader = (LockDataReader)_lockFactory.CreateandReturnObj (LockClassesEnumeration.LockDataReader);
			_alarmer = (LockAlarmer)_lockFactory.CreateandReturnObj (LockClassesEnumeration.LockAlarmer);
            _alarmer.UpperLevelAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.LowerLevelAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.FlowRateAlarm += new EventHandler(soundMutableAlarm);
			_tickTimer.Stop ();
			_tickTimer.Interval = TimeSpan.FromMilliseconds (1000);
			_tickTimer.Tick += new EventHandler (updateReadings);
		}

		void updateReadings (object sender, EventArgs e)
		{            
			_lockData.SetLockData (_dataReader.getData ());
            _upperLevel.Content = _lockData.UpperLevel;
            _lowerLevel.Content = _lockData.LowerLevel;
            _flowRate.Content = _lockData.FlowRate;
			_alarmer.ReadingsTest (_lockData);
		}

		void newLockSelected (object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			_tickTimer.Stop ();
            string fileName = @"..\..\..\" + _mainWindow.lockSelector.SelectedValue + ".csv";
            _dataReader.Connect(fileName);
			_tickTimer.Start ();
		}

		void soundMutableAlarm (object sender, EventArgs e)
		{
            if (_alarmMuter.IsChecked == false)
            {
                _mainWindow.soundMutableAlarm();
            }
		}
	}
}

