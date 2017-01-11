using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using UIKit;

namespace DevSandbox
{
    public class AutoLayoutController : UIViewController
    {
        public UILabel RedLabel     { get; set; }
        public UILabel BlueLabel    { get; set; }
        public UILabel GreenLabel   { get; set; }
        public UILabel YellowLabel  { get; set; }
        public UILabel CyanLabel   { get; set; }
        public UILabel PurpleLabel  { get; set; }
        public UILabel OrangeLabel  { get; set; }
        public UILabel JadeLabel    { get; set; }
        public UILabel BrownLabel   { get; set; }

        public List<UILabel> Labels { get; set; }
        


        public AutoLayoutController()
        {
            RedLabel    = new UILabel { BackgroundColor = UIColor.Red, Text = "Top and Middle"};
            BlueLabel   = new UILabel { BackgroundColor = UIColor.Blue, Text = "Right of Red" };
            GreenLabel  = new UILabel { BackgroundColor = UIColor.Green, Text = "Centered below Blue" };
            YellowLabel = new UILabel { BackgroundColor = UIColor.Yellow, Text = "Below Green" };
            CyanLabel   = new UILabel { BackgroundColor = UIColor.Cyan, Text = "Left of Yellow" };
            PurpleLabel = new UILabel { BackgroundColor = UIColor.Purple, Text = "Right of screen, in line with Cyan" };
            OrangeLabel = new UILabel { BackgroundColor = UIColor.Orange, Text = "At the bottom, in line with Azure" };
            JadeLabel   = new UILabel { BackgroundColor = UIColor.Magenta, Text = "Slightly off center" };
            BrownLabel  = new UILabel { BackgroundColor = UIColor.Brown, Text = "Above Magenta" };

            Labels = new List<UILabel> { RedLabel, BlueLabel, GreenLabel, YellowLabel, CyanLabel, PurpleLabel, OrangeLabel, JadeLabel, BrownLabel };

            View.BackgroundColor = UIColor.White;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // for auto layout to work, iOS needs to be able to figure out he width and height of all elements
            View.AddSubview(RedLabel);

            AppDelegate.Current.NavigationController.HidesBarsOnTap = true;


            foreach (var label in Labels)
            {
                // constrain width and height of all elements
                label.WidthAnchor.ConstraintEqualTo(75).Active = true;
                label.HeightAnchor.ConstraintEqualTo(75).Active = true;
                label.TextColor = UIColor.White;
                label.TranslatesAutoresizingMaskIntoConstraints = false;
            }


            // Constrain the Red Label
            // Constraining the CenterX and TopAnchor lets iOS work out the X and Y
            RedLabel.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            RedLabel.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor).Active = true;


        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            AppDelegate.Current.NavigationController.HidesBarsOnTap = false;
        }
    }
}
