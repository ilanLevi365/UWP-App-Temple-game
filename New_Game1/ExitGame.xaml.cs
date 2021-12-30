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
    public sealed partial class ExitGame : Page
    {
        DispatcherTimer _timer;

        public ExitGame()
        {
            this.InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            _timer.Tick += Timer;
            _timer.Start();
            txtBlThisWorld.Text = BaseClass.Golds1.ToString();
            txtBlNextWorld.Text = BaseClass.Commandmentss.ToString();
        }


        #region Timer
        private void Timer(object sender, object e)
        {
            InstructionsMusic.Play();
        }
        #endregion

        #region btnNewGame_Click
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InstructionsScreen));
        }
        #endregion

        #region btnEndGame_Click
        private void btnEndGame_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            InstructionsMusic.Stop();
            InstructionsMusic.Source = (new Uri($"ms-appx://{"/Assets/BackgroundMusic.m4a"}"));
            InstructionsMusic.Play();
            CanvasEndGameScreen.Children.Remove(btnEndGame);
            CanvasEndGameScreen.Children.Remove(btnNewGame);
            CanvasEndGameScreen.Children.Remove(txtBlNextWorld);
            CanvasEndGameScreen.Children.Remove(txtBlThisWorld);
            CanvasEndGameScreen.Children.Remove(txtBlNextWorld2);
            CanvasEndGameScreen.Children.Remove(txtBlThisWorld2);
            txtBlWage.Text = "תודה רבה! שהשתתפת במשחק , להתראות בפעם הבאה.";

            Windows.UI.Color myColor = Windows.UI.Color.FromArgb((byte)250, (byte)248, (byte)234, (byte)65);// בסוגריים הראשונים אני חושב שזה כמות השקיפות  
            btnExit.BorderBrush = new SolidColorBrush(myColor);
            btnExit.Foreground = new SolidColorBrush(myColor);
            btnExit.FontSize = 36;
            btnExit.Content = "יציאה";
            btnExit.Width = 130; btnExit.Height = 90;
            Canvas.SetLeft(btnExit, 570); Canvas.SetTop(btnExit, 550);
            btnExit.Click += BtnExit_Click;
        }
        #endregion

        #region BtnExit_Click
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        #endregion
    }
}
