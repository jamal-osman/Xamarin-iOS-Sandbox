using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGraphics;
using UIKit;

namespace DevSandbox
{
    public class GesturesController : ListOfViewsController
    {
        void HandleAction()
        {

        }

        private static UILabel _RedLabel = new UILabel { BackgroundColor = UIColor.Red, Text = "Tap me" };
        private static UILabel _BlueLabel = new UILabel { BackgroundColor = UIColor.Blue, Text = "Long Press me" };
        private static UILabel _GreenLabel = new UILabel { BackgroundColor = UIColor.Green, Text = "Pan me" };
        private static UILabel _PurpleLabel = new UILabel { BackgroundColor = UIColor.Purple, Text = "Pinch me" };
        private static UILabel _YellowLabel = new UILabel { BackgroundColor = UIColor.Yellow, Text = "Swipe me towards =>" };
        private static UILabel _CyanLabel = new UILabel { BackgroundColor = UIColor.Cyan, Text = "Swipe me from the right edge" };


        private static List<UILabel> _Labels = new List<UILabel> {
            _RedLabel, _BlueLabel, _GreenLabel, _PurpleLabel, _YellowLabel, _CyanLabel };

        public GesturesController() : base(_Labels.Cast<UIView>().ToList())
        {
            foreach (var label in _Labels)
            {
                label.UserInteractionEnabled = true;
                label.TextAlignment = UITextAlignment.Center;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var random = new Random();
            _RedLabel.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                _RedLabel.BackgroundColor = UIColor.FromRGB(random.Next(255), random.Next(255), random.Next(255));
            }));

            _BlueLabel.AddGestureRecognizer(new UILongPressGestureRecognizer((rec) =>
            {
                if (rec.State == UIGestureRecognizerState.Recognized)
                    _BlueLabel.BackgroundColor = UIColor.FromRGB(random.Next(255), random.Next(255), random.Next(255));
            }));

            _GreenLabel.AddGestureRecognizer(new UIPanGestureRecognizer((rec) =>
            {
                CGPoint touchPosition = rec.LocationInView(this.View);
                _GreenLabel.Center = new CGPoint(touchPosition.X, _GreenLabel.Center.Y);
            }));

            CGAffineTransform transform = _PurpleLabel.Transform;
            _PurpleLabel.AddGestureRecognizer(new UIPinchGestureRecognizer((async (rec) =>
            {
                if (rec.State == UIGestureRecognizerState.Ended)
                {
                    // reset
                    await Task.Delay(1000);
                    _PurpleLabel.Transform = transform;
                    return;
                }

                rec.View.Transform = CGAffineTransform.MakeScale(rec.Scale, rec.Scale);
                //rec.Scale = 1;
            })));

            CGPoint center = _YellowLabel.Center;
            _YellowLabel.AddGestureRecognizer(new UISwipeGestureRecognizer((rec) =>
            {
                if (rec.State == UIGestureRecognizerState.Recognized)
                    UIView.Animate(0.8, 0, UIViewAnimationOptions.CurveEaseOut | UIViewAnimationOptions.Autoreverse,
                                   () => _YellowLabel.Center = new CGPoint(View.Bounds.Width * 3, _YellowLabel.Center.Y),
                                   () => { this.ContentStack.SetNeedsLayout(); });
            }));

            // find the constraint that creates the 8pt margin on the right, and remove it
            // this is so we can swipe from the right edge while touching the cyan label
            View.Constraints.First(constraint => constraint.FirstItem == _CyanLabel && constraint.Constant == -8).Constant = 0;

            _CyanLabel.AddGestureRecognizer(new UIScreenEdgePanGestureRecognizer((rec) =>
            {

                if (rec.State == UIGestureRecognizerState.Recognized)
                    UIView.Animate(0.8, 0, UIViewAnimationOptions.CurveEaseOut | UIViewAnimationOptions.Autoreverse,
                                   () => _CyanLabel.Center = new CGPoint(View.Bounds.Width * -3, _YellowLabel.Center.Y),
                                   () => { this.ContentStack.SetNeedsLayout(); });
            })
            { Edges = UIRectEdge.Right }
            );
        }
    }
}
