using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace New_Game1.Classes
{
    class ImgesIn : BaseClass
    {
        public ImgesIn(string uri, double width, double height, double left, double top)
            : base(uri)
        {
            New_Image.Width = width; New_Image.Height = height;
            Canvas.SetLeft(New_Image, left); Canvas.SetTop(New_Image, top);
        }
    }
}
