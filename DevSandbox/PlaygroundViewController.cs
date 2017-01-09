using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace DevSandbox
{
    public class PlaygroundViewController : UIViewController
    {
        public UIScrollView ScrollContainer { get; set; }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //View.LayoutMargins = new UIEdgeInsets(10, 10, 10, 10);
            View.BackgroundColor = UIColor.White;
            View.ClipsToBounds = true;


            ScrollContainer = new UIScrollView(View.Frame);
            ScrollContainer.BackgroundColor = UIColor.White;
            ScrollContainer.TranslatesAutoresizingMaskIntoConstraints = false;

            var views = new LinkedList<UIView>(
                new List<UIView>{
                    new UITextView
                    {
                        Text = "Text Views (This is a Headline)",
                        BackgroundColor = UIColor.DarkGray,
                        Font = UIFont.PreferredHeadline,
                    },
                    new UITextView
                    {
                        Text = "Subheadline",
                        BackgroundColor = UIColor.DarkGray,
                        Font = UIFont.PreferredSubheadline
                    },
                    new UITextView
                    {
                        Text = "Title 1",
                        Font = UIFont.PreferredTitle1,
                    },
                    new UITextView
                    {
                        Text = "Title 2",
                        Font = UIFont.PreferredTitle2,
                    },
                    new UITextView
                    {
                        Text = "Title 3",
                        Font = UIFont.PreferredTitle3,
                    },
                    new UITextView
                    {
                        Text = "Caption 1",
                        Font = UIFont.PreferredCaption1,
                    },
                    new UITextView
                    {
                        Text = "Caption 2",
                        Font = UIFont.PreferredCaption2,
                    }
                }
            );

            ScrollContainer.AddSubviews(views.ToArray());

            var node = views.First;
            while (node.Next != null)
            {
                var refView = (node.Previous?.Value ?? ScrollContainer);
                UIView subview = node.Value;

                subview.TranslatesAutoresizingMaskIntoConstraints = false;

                //subview.TopAnchor.ConstraintEqualTo(refView.TopAnchor, 5).Active = true;
                //subview.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 5).Active = true;
                //subview.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, 5).Active = true;
                //subview.HeightAnchor.ConstraintEqualTo(80);

                ScrollContainer.AddConstraints(new NSLayoutConstraint[] {
                    NSLayoutConstraint.Create(subview,NSLayoutAttribute.Top,NSLayoutRelation.Equal, refView,  NSLayoutAttribute.Top,1,100),
                    NSLayoutConstraint.Create(subview,NSLayoutAttribute.LeadingMargin,NSLayoutRelation.Equal, ScrollContainer, NSLayoutAttribute.Leading,1,5),
                    NSLayoutConstraint.Create(subview,NSLayoutAttribute.TrailingMargin,NSLayoutRelation.Equal, ScrollContainer ,NSLayoutAttribute.Trailing,1,5),
                    NSLayoutConstraint.Create(subview,NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 80),
                });

                node = node.Next;
            }

            View.Add(ScrollContainer);
            View.AddConstraints(new NSLayoutConstraint[] {
                NSLayoutConstraint.Create(ScrollContainer, NSLayoutAttribute.TopMargin, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top,0,0),
                NSLayoutConstraint.Create(ScrollContainer, NSLayoutAttribute.BottomMargin, NSLayoutRelation.Equal, View, NSLayoutAttribute.BottomMargin,0,0),
                NSLayoutConstraint.Create(ScrollContainer, NSLayoutAttribute.LeadingMargin, NSLayoutRelation.Equal, View, NSLayoutAttribute.Leading,0,0),
                NSLayoutConstraint.Create(ScrollContainer, NSLayoutAttribute.TrailingMargin, NSLayoutRelation.Equal, View, NSLayoutAttribute.Trailing,0,0),
            });

            //ScrollContainer.BackgroundColor = UIColor.White;
            //View.Add(ScrollContainer);
            
        }
    }
}
