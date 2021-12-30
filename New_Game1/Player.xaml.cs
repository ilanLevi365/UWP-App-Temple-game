using New_Game1.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace New_Game1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Player : Page
    {
        Canvas _canvasPlayer;
        DispatcherTimer _timer;
        Commandments _commandments;
        Gold _gold;
        ImgesIn _newPlayer;
        ImgesIn _imgDevil;
        List<string> _keys;
        string _key;
        int _speed = 15;
        int _pane;
        int _RunningTime;
        double _top;
        double _top1;
        bool _gameWorker;
        bool _commandmentsSign1;
        bool _commandmentsSign2;
        bool _gold1;
        bool _pane1;

        public Player()
        {
            this.InitializeComponent();
            _canvasPlayer = CanvasPlayer;
            _imgDevil = new ImgesIn("/Assets/ImgDevil.png", 50, 120, 591, 0);
            _imgDevil.Add_To_Canvas(_canvasPlayer);
            BaseClass.SpeedEivl = 3;
            if (BaseClass.Player == 1) _newPlayer = new ImgesIn("/Assets/ImgGirlBack.png", 123, 147, 560, 542);
            else _newPlayer = new ImgesIn("/Assets/ImgBoyBack.png", 123, 147, 591, 542);
            _newPlayer.Add_To_Canvas(_canvasPlayer);
            BaseClass.Commandmentss = 0;
            BaseClass.Golds1 = 0;
            BaseClass.Medicine = 6;
            _commandments = new Commandments("/Assets/ImgShabbatFeast.jpg", 40, 40);
            _commandments.Add_To_Canvas(_canvasPlayer);
            _gold = new Gold("/Assets/ImgGold.png", 615);
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            _timer.Tick += Timer;
            _timer.Start();
            Window.Current.CoreWindow.KeyDown += User_KeyDown;
            Window.Current.CoreWindow.KeyUp += User_KeyUp;
            _keys = new List<string>();
            PainSound.Stop();
        }


        #region Timer
        private void Timer(object sender, object e)
        {
            Medicine();
            Death();
            Triumph();
            TxtBlCommandmentsNum.Text = BaseClass.Commandmentss.ToString();
            TxtBlGoldsNum.Text = BaseClass.Golds1.ToString();
            TxtBlMedicine.Text = BaseClass.Medicine.ToString();
            Eivl_Move();
            if (BaseClass.Commandmentss == 101) Weather(_canvasPlayer);
            BackgroundMusic.Play();
            if (BaseClass.Commandmentss >= 100) RiverSound.Play();
            else RainSound.Play();
            TxtBlTime.Text = _RunningTime.ToString();
            _RunningTime++;
            User_InKey();
            ReturnDown();
            _commandments.Dring_Down();
            _top = Canvas.GetTop(_commandments.New_Image);
            if (_top > 600)
            {
                BaseClass.Commandmentss_Sign = true;
                _canvasPlayer.Children.Remove(_commandments.New_Image);
                _commandments = new Commandments("/Assets/ImgApplies.jpg", 40, 40);
                Add_Commandments_To_Canvas();
            }
            if (Is_Collide_Commandments(_commandments))
            {
                SoundGifts.Play();
                _commandments.Sum_Gifts(_canvasPlayer);
            }
            if (BaseClass.Commandmentss > 0 && BaseClass.Commandmentss % 10 == 0)
            {
                _gold.Add_To_Canvas(_canvasPlayer);
                BaseClass.Golds2 += 5;
                _gold1 = true;
                BaseClass.Commandmentss++;
            }
            _top1 = Canvas.GetTop(_gold.New_Image);
            if (_top1 == 311)
            {
                _gold1 = false;

            }
            if (_gold1 == true) _gold.Dring_Down();
            BaseClass.Golds_Sign = false;
            if (Is_Collide_Gold(_gold))
            {
                BaseClass.Golds1 = BaseClass.Golds2;
                BaseClass.Golds_Sign = true;
                _gold1 = false;
                SoundGifts.Play();
                _gold.Sum_Gifts(_canvasPlayer);
            }
        }
        #endregion

        #region Weather
        private void Weather(Canvas canvas)
        {
            canvas.Children.Remove(ImgRain);
        }
        #endregion

        #region Player move
        private void User_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            _key = args.VirtualKey.ToString();
            _keys.Add(args.VirtualKey.ToString());
        }
        private void User_KeyUp(CoreWindow sender, KeyEventArgs args)
        {
            _key = "";
            _keys.RemoveAll(key => key == args.VirtualKey.ToString());
        }
        private void User_InKey()
        {
            if (_keys.Contains("Right"))
            {
                double left = Canvas.GetLeft(_newPlayer.New_Image);
                if (_newPlayer.New_Image.ActualWidth + left + _speed <= _canvasPlayer.ActualWidth)
                    Canvas.SetLeft(_newPlayer.New_Image, left + _speed);
            }
            if (_keys.Contains("Left"))
            {
                double left = Canvas.GetLeft(_newPlayer.New_Image);
                if (left - _speed >= 0)
                    Canvas.SetLeft(_newPlayer.New_Image, left - _speed);
            }
            if (_keys.Contains("Up"))
            {
                double up = Canvas.GetTop(_newPlayer.New_Image);
                if (up - _speed >= 160)
                    Canvas.SetTop(_newPlayer.New_Image, up - _speed);
            }
        }
        private void ReturnDown()
        {
            if (_key == "")
            {
                double up = Canvas.GetTop(_newPlayer.New_Image);
                if (up <= 529)
                    Canvas.SetTop(_newPlayer.New_Image, up + _speed);
            }
        }
        private bool EndScreen(FrameworkElement player, double newLeft)
        {
            double canvasWidth = _canvasPlayer.ActualWidth;
            return newLeft + player.ActualWidth > canvasWidth;
        }
        #endregion

        #region Eivl_Move
        private void Eivl_Move()
        {
            double top_P = Canvas.GetTop(_newPlayer.New_Image);
            double left_P = Canvas.GetLeft(_newPlayer.New_Image);
            double top_E = Canvas.GetTop(_imgDevil.New_Image);
            double left_E = Canvas.GetLeft(_imgDevil.New_Image);
            if (top_E < top_P)
            {
                Canvas.SetTop(_imgDevil.New_Image, top_E + BaseClass.SpeedEivl);
            }
            else
            {
                Canvas.SetTop(_imgDevil.New_Image, top_E - BaseClass.SpeedEivl);
            }
            if (left_E < left_P + 5)
            {
                Canvas.SetLeft(_imgDevil.New_Image, left_E + BaseClass.SpeedEivl);
            }
            else
            {
                Canvas.SetLeft(_imgDevil.New_Image, left_E - BaseClass.SpeedEivl);
            }
        }
        #endregion

        #region Pause playing
        private void TimeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_gameWorker == false)
            {
                _timer.Stop();
                RainSound.Play();
                BackgroundMusic.Stop();
                TimeButton.Content = "המשך";
            }
            else
            {
                _timer.Start();
                TimeButton.Content = "עצור";
            }
            _gameWorker = !_gameWorker;
        }
        #endregion

        #region Add_Commandments_To_Canvas
        private void Add_Commandments_To_Canvas()
        {
            if (BaseClass.Player == 1)
            {
                if (_commandmentsSign1 == false && _commandmentsSign2 == false)
                {
                    _commandments.New_Image.Source = new BitmapImage(new Uri($"ms-appx://{"/Assets/ImgShabbatCandles.jpg"}"));
                    _canvasPlayer.Children.Add(_commandments.New_Image);
                    _commandmentsSign1 = true;
                }
                else if (_commandmentsSign1 == true && _commandmentsSign2 == false)
                {
                    _commandments.New_Image.Source = new BitmapImage(new Uri($"ms-appx://{"/Assets/ImgApplies.jpg"}"));
                    _canvasPlayer.Children.Add(_commandments.New_Image);
                    _commandmentsSign2 = true;
                }
                else if (_commandmentsSign1 == true && _commandmentsSign2 == true)
                {
                    _commandments.New_Image.Source = new BitmapImage(new Uri($"ms-appx://{"/Assets/ImgShabbatFeast.jpg"}"));
                    _canvasPlayer.Children.Add(_commandments.New_Image);
                    _commandmentsSign1 = false; _commandmentsSign2 = false;
                }
            }
            else
            {
                if (_commandmentsSign1 == false && _commandmentsSign2 == false)
                {
                    _commandments.New_Image.Source = new BitmapImage(new Uri($"ms-appx://{"/Assets/Imgfringe.jpeg"}"));
                    _canvasPlayer.Children.Add(_commandments.New_Image);
                    _commandmentsSign1 = true;
                }
                else if (_commandmentsSign1 == true && _commandmentsSign2 == false)
                {
                    _commandments.New_Image.Source = new BitmapImage(new Uri($"ms-appx://{"/Assets/Imgtefillin.jpg"}"));
                    _canvasPlayer.Children.Add(_commandments.New_Image);
                    _commandmentsSign2 = true;
                }
                else if (_commandmentsSign1 == true && _commandmentsSign2 == true)
                {
                    _commandments.New_Image.Source = new BitmapImage(new Uri($"ms-appx://{"/Assets/ImgShabbatFeast.jpg"}"));
                    _canvasPlayer.Children.Add(_commandments.New_Image);
                    _commandmentsSign1 = false; _commandmentsSign2 = false;
                }
            }
        }
        #endregion

        #region Btn_End_Game
        private void BtnEndGame_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ExitGame));
        }
        #endregion

        #region Medicine
        private void Medicine()
        {
            if (!Is_Collide_Eivl(_imgDevil)) _pane1 = true;
            if (Is_Collide_Eivl(_imgDevil)) _pane = 1;

            if (_pane1 == true && _pane == 1)
            {
                PainSound.Play();
                BaseClass.Medicine -= 1;
                _pane1 = false;
                _pane = 0;
            }
        }
        #endregion

        #region Death
        private void Death()
        {
            if (BaseClass.Medicine < 0)
            {
                _timer.Stop();
                Frame.Navigate(typeof(ExitGame));
            }
        }
        #endregion

        #region Triumph
        private void Triumph()
        {
            if (BaseClass.Commandmentss == 201)
            {
                _timer.Stop();
                Frame.Navigate(typeof(Triumph));
            }
        }
        #endregion

        #region Is_Collide_Eivl
        private bool Is_Collide_Eivl(BaseClass baseClass)
        {
            if (Canvas.GetLeft(_newPlayer.New_Image) + _newPlayer.New_Image.ActualWidth / 2 < Canvas.GetLeft(baseClass.New_Image) ||
                Canvas.GetLeft(_newPlayer.New_Image) + _newPlayer.New_Image.ActualWidth / 2 > Canvas.GetLeft(baseClass.New_Image) + baseClass.New_Image.ActualWidth)
                return false;
            else if (Canvas.GetTop(_newPlayer.New_Image) + _newPlayer.New_Image.ActualHeight < Canvas.GetTop(baseClass.New_Image) ||
                     Canvas.GetTop(_newPlayer.New_Image) > Canvas.GetTop(baseClass.New_Image) + baseClass.New_Image.ActualHeight)
                return false;
            return true;
        }
        #endregion

        #region Is_Collide_Commandments
        private bool Is_Collide_Commandments(BaseClass baseClass)
        {
            if (Canvas.GetLeft(_newPlayer.New_Image) + _newPlayer.New_Image.ActualWidth / 2 < Canvas.GetLeft(baseClass.New_Image) ||
                Canvas.GetLeft(_newPlayer.New_Image) + _newPlayer.New_Image.ActualWidth / 2 > Canvas.GetLeft(baseClass.New_Image) + baseClass.New_Image.ActualWidth)
                return false;
            else if (Canvas.GetTop(_newPlayer.New_Image) + _newPlayer.New_Image.ActualHeight < Canvas.GetTop(baseClass.New_Image) ||
                     Canvas.GetTop(_newPlayer.New_Image) > Canvas.GetTop(baseClass.New_Image) + baseClass.New_Image.ActualHeight)
                return false;
            return true;
        }
        #endregion

        #region Is_Collide_Gold
        private bool Is_Collide_Gold(BaseClass baseClass)
        {
            if (Canvas.GetLeft(_newPlayer.New_Image) + _newPlayer.New_Image.ActualWidth / 2 < Canvas.GetLeft(baseClass.New_Image) ||
                Canvas.GetLeft(_newPlayer.New_Image) + _newPlayer.New_Image.ActualWidth / 2 > Canvas.GetLeft(baseClass.New_Image) + baseClass.New_Image.ActualWidth)
                return false;
            else if (Canvas.GetTop(_newPlayer.New_Image) + _newPlayer.New_Image.ActualHeight < Canvas.GetTop(baseClass.New_Image) ||
                     Canvas.GetTop(_newPlayer.New_Image) > Canvas.GetTop(baseClass.New_Image) + baseClass.New_Image.ActualHeight)
                return false;
            return true;
        }
        #endregion
    }
}
