using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace New_Game1.Classes
{
    public class Commandments : BaseClass
    {
        Random _left;
        public Commandments(string uri, double width, double height)
            : base(uri)
        {
            _left = new Random();
            New_Image.Width = width; New_Image.Height = height;
            Canvas.SetLeft(New_Image, _left.Next(30, 1200)); Canvas.SetTop(New_Image, 0);
        }


        #region Dring_Down
        public override void Dring_Down()
        {
            double top = Canvas.GetTop(New_Image);
            if (top < 612) Canvas.SetTop(New_Image, top + _speedDringDown);
            if (Commandmentss > 0 && Commandmentss == 71)
            {
                _speedDringDown += 3;
                BaseClass.SpeedEivl += 1;
            }

        }
        #endregion

        #region Sum Gifts
        public override void Sum_Gifts(Canvas canvas)
        {
            if (Commandmentss_Sign)
            {
                Commandmentss++;
                Commandmentss_Sign = false;
                canvas.Children.Remove(New_Image);
            }
        }
        #endregion
    }
}
