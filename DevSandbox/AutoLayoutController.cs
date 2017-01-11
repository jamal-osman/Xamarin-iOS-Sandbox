using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using UIKit;

namespace DevSandbox
{
    public class AutoLayoutController : UIViewController
    {
        public UILabel RedLabel { get; set; }
        public UILabel BlueLabel { get; set; }
        public UILabel GreenLabel { get; set; }
        public UILabel YellowLabel { get; set; }
        public UILabel CyanLabel { get; set; }
        public UILabel PurpleLabel { get; set; }
        public UILabel OrangeLabel { get; set; }
        public UILabel MagentaLabel { get; set; }
        public UILabel BrownLabel { get; set; }

        public List<UILabel> Labels { get; set; }



        public AutoLayoutController()
        {
            RedLabel = new UILabel { BackgroundColor = UIColor.Red, Text = "Top and Middle" };
            BlueLabel = new UILabel { BackgroundColor = UIColor.Blue, Text = "Right of Red by 5pt" };
            GreenLabel = new UILabel { BackgroundColor = UIColor.Green, Text = "Centered below Blue, twice as wide" };
            YellowLabel = new UILabel { BackgroundColor = UIColor.Yellow, Text = "Below Green" };
            CyanLabel = new UILabel { BackgroundColor = UIColor.Cyan, Text = "Left of Yellow" };
            PurpleLabel = new UILabel { BackgroundColor = UIColor.Purple, Text = "Right of screen, in line with Cyan" };
            OrangeLabel = new UILabel { BackgroundColor = UIColor.Orange, Text = "At the bottom, in line with Cyan" };
            MagentaLabel = new UILabel { BackgroundColor = UIColor.Magenta, Text = "-20pt off center, below Red" };
            BrownLabel = new UILabel { BackgroundColor = UIColor.Brown, Text = "Above Magenta" };

            Labels = new List<UILabel> { RedLabel, BlueLabel, GreenLabel, YellowLabel, CyanLabel, PurpleLabel, OrangeLabel, MagentaLabel, BrownLabel };

            View.BackgroundColor = UIColor.White;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // for auto layout to work, iOS needs to be able to figure out he width and height of all elements
            View.AddSubviews(Labels.ToArray());

            AppDelegate.Current.NavigationController.HidesBarsOnTap = true;


            foreach (var label in Labels)
            {
                // constrain width and height of all elements
                label.WidthAnchor.ConstraintEqualTo(75).Active = true;
                label.HeightAnchor.ConstraintEqualTo(75).Active = true;
                label.TextColor = UIColor.White;
                label.Font = UIFont.SystemFontOfSize(12);
                label.LineBreakMode = UILineBreakMode.WordWrap;
                label.Lines = 4;
                label.TranslatesAutoresizingMaskIntoConstraints = false;
            }


            // Constraining the CenterX and TopAnchor lets iOS work out the X and Y
            RedLabel.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            RedLabel.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;

            BlueLabel.LeftAnchor.ConstraintEqualTo(RedLabel.RightAnchor, 4).Active = true;
            BlueLabel.TopAnchor.ConstraintEqualTo(RedLabel.TopAnchor).Active = true;

            GreenLabel.LeftAnchor.ConstraintEqualTo(BlueLabel.LeftAnchor).Active = true;
            GreenLabel.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;
            GreenLabel.WidthAnchor.ConstraintEqualTo(BlueLabel.WidthAnchor,2).Active = true;

            YellowLabel.TopAnchor.ConstraintEqualTo(GreenLabel.BottomAnchor).Active = true;
            YellowLabel.LeftAnchor.ConstraintEqualTo(GreenLabel.LeftAnchor).Active = true;

            CyanLabel.RightAnchor.ConstraintEqualTo(YellowLabel.LeftAnchor).Active = true;
            CyanLabel.TopAnchor.ConstraintEqualTo(YellowLabel.TopAnchor).Active = true;

            PurpleLabel.TopAnchor.ConstraintEqualTo(CyanLabel.TopAnchor).Active = true;
            PurpleLabel.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;

            OrangeLabel.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;
            OrangeLabel.LeftAnchor.ConstraintEqualTo(CyanLabel.LeftAnchor).Active = true;

            MagentaLabel.CenterXAnchor.ConstraintEqualTo(RedLabel.CenterXAnchor, -20).Active = true;
            MagentaLabel.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor, -20).Active = true;

            BrownLabel.BottomAnchor.ConstraintEqualTo(MagentaLabel.TopAnchor).Active = true;
            BrownLabel.LeftAnchor.ConstraintEqualTo(MagentaLabel.LeftAnchor).Active = true;


            RedLabel.UserInteractionEnabled = true;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            AppDelegate.Current.NavigationController.HidesBarsOnTap = false;
        }
    }
}
