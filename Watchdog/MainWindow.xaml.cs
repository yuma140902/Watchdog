using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Watchdog.Models;
using Watchdog.ViewModels;

namespace Watchdog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var targetPIDModel = new TargetPIDModel(Environment.GetCommandLineArgs()[1..]);
            var vm = new MainWindowViewModel(targetPIDModel);
            DataContext = vm;
        }
    }
}
