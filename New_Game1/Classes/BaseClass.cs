using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace New_Game1.Classes
{
    public abstract class BaseClass
    {
        protected MediaElement _soundGifts;
        protected int _speedDringDown = 8;


        public Image New_Image { get; set; }
        public static int Commandmentss { get; set; }
        public static bool Commandmentss_Sign { get; set; }
        public static int Golds1 { get; set; }
        public static int Golds2 { get; set; }
        public static bool Golds_Sign { get; set; }
        public static int Player { get; set; }
        public static int SpeedEivl { get; set; }
        public static int Medicine { get; set; }


        public BaseClass(string uri)
        {
            New_Image = new Image();
            New_Image.Source = new BitmapImage(new Uri($"ms-appx://{uri}"));
        }


        #region Add_To_Canvas
        public virtual void Add_To_Canvas(Canvas canvas)
        {
            canvas.Children.Add(New_Image);
        }
        #endregion

        #region Dring_Down
        public virtual void Dring_Down() { }
        #endregion

        #region Sum_Gifts
        public virtual void Sum_Gifts(Canvas canvas) { }
        #endregion
    }
}
