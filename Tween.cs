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


        public double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180; 
        }

        public double RadiansToDegrees(double radians)
        {
            return radians * 180 / Math.PI; 
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

        public static void MoveTo(UIElement ui, double seconds, double top, double left, Canvas canvas)
        {
            Canvas c = canvas; 
            if (!string.IsNullOrEmpty(sbid))
            {
                c.Resources.Remove(sbid);
            }

            //Canvas canvas = new Canvas();
            //string canvasid = String.Format("canvas{0}", Guid.NewGuid().ToString().Replace("-", ""));
            //root.Resources.Add(canvasid, canvasid);
            DoubleAnimation da1 = new DoubleAnimation();
            DoubleAnimation da2 = new DoubleAnimation();

            //BounceEase bounce = new BounceEase();
            //bounce.Bounciness = 4;
            //da1.EasingFunction = bounce;
            //da2.EasingFunction = bounce;

            CubicEase cubic = new CubicEase();
            da1.EasingFunction = cubic;
            da2.EasingFunction = cubic; 

            Duration d = new Duration(TimeSpan.FromSeconds(seconds));
            da1.Duration = d;
            da2.Duration = d;
            Storyboard sb = new Storyboard();
            Storyboard.SetTarget(da1, ui);
            Storyboard.SetTarget(da2, ui);
            Storyboard.SetTargetProperty(da1, new PropertyPath("(Canvas.Left)"));
            Storyboard.SetTargetProperty(da2, new PropertyPath("(Canvas.Top)"));
            sb.Duration = d;
            sb.Children.Add(da1);
            sb.Children.Add(da2);
            da1.To = left;
            da2.To = top; 
            sbid = Guid.NewGuid().ToString();
            c.Resources.Add(sbid, sb);
            sb.Begin(); 



        }
        public static void Resize(UIElement ui, double seconds, double h, double w, Canvas canvas)
        {
            Canvas c = canvas;
            if (!string.IsNullOrEmpty(sbid))
            {
                c.Resources.Remove(sbid);
            }

            //Canvas canvas = new Canvas();
            //string canvasid = String.Format("canvas{0}", Guid.NewGuid().ToString().Replace("-", ""));
            //root.Resources.Add(canvasid, canvasid);
            DoubleAnimation da1 = new DoubleAnimation();
            DoubleAnimation da2 = new DoubleAnimation();

            //BounceEase bounce = new BounceEase();
            //bounce.Bounciness = 4;
            //da1.EasingFunction = bounce;
            //da2.EasingFunction = bounce;

            CubicEase cubic = new CubicEase();
            da1.EasingFunction = cubic;
            da2.EasingFunction = cubic;

            Duration d = new Duration(TimeSpan.FromSeconds(seconds));
            da1.Duration = d;
            da2.Duration = d;
            Storyboard sb = new Storyboard();
            Storyboard.SetTarget(da1, ui);
            Storyboard.SetTarget(da2, ui);
            Storyboard.SetTargetProperty(da1, new PropertyPath("(Width)"));
            Storyboard.SetTargetProperty(da2, new PropertyPath("(Height)"));
            sb.Duration = d;
            sb.Children.Add(da1);
            sb.Children.Add(da2);
            da1.To = w;
            da2.To = h; 
            sbid = Guid.NewGuid().ToString();
            c.Resources.Add(sbid, sb);
            sb.Begin(); 


        }
    }
}
