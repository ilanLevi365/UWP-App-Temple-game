using New_Game1.Classes;
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
    public sealed partial class PlayerSelection : Page
    {
        DispatcherTimer _timer;

        public PlayerSelection()
        {
            this.InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            _timer.Tick += Timer;
            _timer.Start();
        }
      
        private void Timer(object sender, object e)
        {
            BackgroundMusic.Play();
        }
     
        private void btnGirlChoice_Click(object sender, RoutedEventArgs e)
        {
            BaseClass.Player = 1;
            BackgroundMusic.Stop();
            Frame.Navigate(typeof(Player));
        }
      
        private void BtnBoylChoice_Click_1(object sender, RoutedEventArgs e)
        {
            BackgroundMusic.Stop();
            Frame.Navigate(typeof(Player));
        }
       
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InstructionsScreen));
        }     
    }
}
