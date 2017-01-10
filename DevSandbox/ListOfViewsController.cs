using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace DevSandbox
{
    public class ListOfViewsController : UIViewController
    {
        public UIScrollView ScrollContainer { get; set; }
        public UIStackView ContentStack { get; set; }
        public List<UIView> Subviews { get; set; }

        public ListOfViewsController(List<UIView> subviews)
        {
            Subviews = subviews;
            ContentStack = new UIStackView();
            ContentStack.BackgroundColor = UIColor.FromRGB(220, 220, 220);
            ContentStack.TranslatesAutoresizingMaskIntoConstraints = false;
            ContentStack.Axis = UILayoutConstraintAxis.Vertical;
            ContentStack.Distribution = UIStackViewDistribution.EqualSpacing;
            ContentStack.Alignment = UIStackViewAlignment.Center;
            ContentStack.Spacing = 8;

            ScrollContainer = new UIScrollView();
            ScrollContainer.BackgroundColor = UIColor.FromRGB(180, 180, 180);
            ScrollContainer.TranslatesAutoresizingMaskIntoConstraints = false;

            View.BackgroundColor = UIColor.White;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ContentStack.AddSubviews(Subviews.ToArray());

            ScrollContainer.Add(ContentStack);

            View.Add(ScrollContainer);


            foreach (UIView subview in Subviews)
            {
                subview.TranslatesAutoresizingMaskIntoConstraints = false;

                subview.HeightAnchor.ConstraintEqualTo(80).Active = true;
                subview.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 8).Active = true;
                subview.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -8).Active = true;

                ContentStack.AddArrangedSubview(subview);
            }

            ContentStack.TopAnchor.ConstraintEqualTo(ScrollContainer.TopAnchor).Active = true;
            ContentStack.BottomAnchor.ConstraintEqualTo(ScrollContainer.BottomAnchor).Active = true;
            ContentStack.LeadingAnchor.ConstraintEqualTo(ScrollContainer.LeadingAnchor).Active = true;
            ContentStack.TrailingAnchor.ConstraintEqualTo(ScrollContainer.TrailingAnchor).Active = true;


            ScrollContainer.TopAnchor.ConstraintEqualTo(TopLayoutGuide.GetTopAnchor()).Active = true;
            ScrollContainer.BottomAnchor.ConstraintEqualTo(BottomLayoutGuide.GetBottomAnchor()).Active = true;
            ScrollContainer.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            ScrollContainer.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;

            ContentStack.WidthAnchor.ConstraintEqualTo(View.WidthAnchor).Active = true;


            // Constraints can also be set like this:

            //ScrollContainer.AddConstraints(new NSLayoutConstraint[] {
            //    NSLayoutConstraint.Create(ContentStack,NSLayoutAttribute.Top,NSLayoutRelation.Equal, ScrollContainer, NSLayoutAttribute.Top,1,0),
            //    NSLayoutConstraint.Create(ContentStack,NSLayoutAttribute.Bottom,NSLayoutRelation.Equal, ScrollContainer ,NSLayoutAttribute.Bottom,1,0),
            //    NSLayoutConstraint.Create(ContentStack,NSLayoutAttribute.Leading,NSLayoutRelation.Equal, ScrollContainer, NSLayoutAttribute.Leading,1,0),
            //    NSLayoutConstraint.Create(ContentStack,NSLayoutAttribute.Trailing,NSLayoutRelation.Equal, ScrollContainer ,NSLayoutAttribute.Trailing,1,0),
            //});

            //View.AddConstraints(new NSLayoutConstraint[] {
            //    NSLayoutConstraint.Create(ScrollContainer,NSLayoutAttribute.Top,NSLayoutRelation.Equal, TopLayoutGuide, NSLayoutAttribute.Top,1,0),
            //    NSLayoutConstraint.Create(ScrollContainer,NSLayoutAttribute.Bottom,NSLayoutRelation.Equal, BottomLayoutGuide, NSLayoutAttribute.Bottom,1,0),
            //    NSLayoutConstraint.Create(ScrollContainer,NSLayoutAttribute.Leading,NSLayoutRelation.Equal, View, NSLayoutAttribute.Leading,1,0),
            //    NSLayoutConstraint.Create(ScrollContainer,NSLayoutAttribute.Trailing,NSLayoutRelation.Equal, View ,NSLayoutAttribute.Trailing,1,0),
            //
            //    NSLayoutConstraint.Create(ContentStack,NSLayoutAttribute.Width,NSLayoutRelation.Equal, View, NSLayoutAttribute.Width,1,0),
            //});
        }
    }
}
