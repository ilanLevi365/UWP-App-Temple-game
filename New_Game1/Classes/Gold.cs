using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace New_Game1.Classes
{
    public class Gold : BaseClass
    {

        public Gold(string uri, double left)
            : base(uri)
        {
            New_Image.Width = 50; New_Image.Height = 50;
            Canvas.SetLeft(New_Image, left); Canvas.SetTop(New_Image, 0);
        }


        #region Dring_Down
        public override void Dring_Down()
        {
            double top = Canvas.GetTop(New_Image);
            if (top < 310) Canvas.SetTop(New_Image, top + _speedDringDown);
        }
        #endregion

        #region Sum_Gifts
        public override void Sum_Gifts(Canvas canvas)
        {
            if (Golds_Sign)
            {
                Golds1 = Golds2;
                Golds_Sign = false;
                canvas.Children.Remove(New_Image);
            }
        }
        #endregion
    }
}
