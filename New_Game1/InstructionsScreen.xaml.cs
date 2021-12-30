using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace New_Game1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InstructionsScreen : Page
    {
        DispatcherTimer _timer;
        public InstructionsScreen()
        {
            this.InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            _timer.Tick += Timer;
            _timer.Start();
        }

        private void Timer(object sender, object e)
        {
            InstructionsMusic.Play();
        }
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            InstructionsMusic.Stop();
            Frame.Navigate(typeof(PlayerSelection));
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
