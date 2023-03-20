using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Models;

namespace Watchdog.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly TargetPIDModel _targetPIDModel;
        private readonly WatchDog watchdog;

        public string TargetPIDMessage
        {
            get => $"Watching {_targetPIDModel.PID?.ToString() ?? "(none)"}";
        }

        public int? TargetPID
        {
            get => _targetPIDModel.PID;
            set {
                _targetPIDModel.PID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TargetPID)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TargetPIDMessage)));
            }
        }

        public MainWindowViewModel(TargetPIDModel targetPIDModel)
        {
            _targetPIDModel = targetPIDModel;
            watchdog = new WatchDog(this);
        }
    }
}
