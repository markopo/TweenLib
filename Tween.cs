using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TweenLib
{
    public class Tween
    {
        private static string sbid = String.Empty;
      

        public Tween()
        {

        }


        public static void ToggleFade(UIElement ui, double seconds, Grid LayoutRoot)
        {
            Grid root = LayoutRoot; 
            if (!string.IsNullOrEmpty(sbid))
            {
               root.Resources.Remove(sbid);
            }

            double op = (ui.Opacity == 1) ? 0 : 1;
            DoubleAnimation da = new DoubleAnimation();
            Duration d = new Duration(TimeSpan.FromSeconds(seconds));
            da.Duration = d;
            Storyboard sb = new Storyboard();
            Storyboard.SetTarget(da, ui);
            Storyboard.SetTargetProperty(da, new PropertyPath("(Opacity)"));
            sb.Duration = d;
            sb.Children.Add(da);
            da.To = op;
            sbid = Guid.NewGuid().ToString();
            root.Resources.Add(sbid, sb);
            sb.Begin(); 


       }

    }
}
